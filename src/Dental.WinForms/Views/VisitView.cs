using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.ViewsStuff.Interfaces;
using Dental.Domain.Shared;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Helpers;
using Microsoft.Extensions.Logging;

namespace Dental.WinForms.Views;

public partial class VisitView : UserControl
{
    private readonly IFormFactory _formFactory;
    private readonly ILogger<VisitView> _logger;
    private readonly IVisitViewService _visitViewService;
    private readonly IVisitSummaryService _visitSummaryService;
    private readonly IVisitService _visitService;

    private int _selectedRowIndex = -1;
    private bool _isLoading = true;


    private enum GridColumns
    {
        PatientName,
        VisitDateTime,
        VisitTreatments,
        TotalAmount,
        PaidAmount,
        DiscountAmount,
        RemainedAmount
    }
    private GridColumns _currentFilterColumn = GridColumns.PatientName;

    public VisitView(
        IFormFactory formFactory,
        ILogger<VisitView> logger,
        IVisitViewService visitViewService,
        IVisitSummaryService visitSummaryService,
        IVisitService visitService)
    {
        InitializeComponent();

        _formFactory = formFactory;
        _logger = logger;
        _visitViewService = visitViewService;
        _visitSummaryService = visitSummaryService;
        _visitService = visitService;
    }


    private async void VisitView_Load(object sender, EventArgs e)
    {
        try
        {
            await InitializeViewAsync();
            await LoadGridAsync(null);
            await LoadCardsAsync(GetCardsPeriod());

            _isLoading = false;
        }
        catch (Exception ex)
        {
            _logger.LogError("An error occurred while loading the VisitView: {Message}", ex.Message);
            MessageBoxExtensions.ShowError("حدث خطأ، يرجي التواصل مع المطور.");
        }
    }

    public async Task InitializeViewAsync()
    {
        cbFilterList.Text = "اسم المريض";
        _currentFilterColumn = GridColumns.PatientName;

        dateTimePicker.Value = DateTime.Now.AddSeconds(-10);
        dateTimePicker.Visible = false;

        txtFilterValue.Clear();
        txtFilterValue.Visible = true;


        dataGridView.AlternatingRowsDefaultCellStyle = null;

        timerUpdateDateTimePckerMaxDate.Start();
        filterTime.Start();
    }

    public async Task LoadGridAsync(Domain.Views.VisitView? filterDTO)
    {
        Cursor = Cursors.WaitCursor;

        var view = await _visitViewService.GetAsync(filterDTO);

        var result = view
            .Select(v => new
            {
                v.VisitId,
                v.AppointmentId,
                v.PatientName,
                v.VisitTreatmentsNames,
                VisitDateTime = v.VisitDateTime is not null
                    ? DateTimeHelper.GetArabicDateTime(v.VisitDateTime.Value)
                    : null,
                v.TotalAmount,
                v.PaidAmount,
                v.DiscountAmount,
                v.RemainedAmount
            })
            .ToList();

        dataGridView.DataSource = result;

        Cursor = Cursors.Default;
    }

    public async Task LoadCardsAsync(DateTime? dateTime)
    {
        Cursor = Cursors.WaitCursor;

        var summary = await _visitSummaryService.GetAsync(dateTime);

        lblTotalVisits.Text = summary.TotalVisitsCount.ToString();
        lblTotalPaidAmount.Text = summary.TotalVisitsPaidAmount.ToString();
        lblTotalDiscountAmount.Text = summary.TotalVisitsDiscountAmount.ToString();
        lblTotalRemainedAmount.Text = summary.TotalVisitsRemainedAmount.ToString();

        Cursor = Cursors.Default;
    }

    public DateTime? GetCardsPeriod()
    {
        if (rbToday.Checked)
            return DateTime.Today.ToLocalTime();

        if (rbThisWeek.Checked)
            return DateTime.Today.AddDays(-7).ToLocalTime();

        if (rbThisMonth.Checked)
            return DateTime.Today.AddMonths(-1).ToLocalTime();

        //if (rbToday.Checked)
        return null;
    }

    private async void btnAddVisit_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;

        using var frm = _formFactory.Create_frmAddUpdateVisit();
        await frm.ShowDialogAsync();

        await Refresh();

        Cursor = Cursors.Default;
    }

    private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        e.ThrowException = false;
    }

    private async void RadioButtonsDateTimeFiltering_CheckedChanged(object sender, EventArgs e)
    {
        await LoadCardsAsync(GetCardsPeriod());
    }

    private async void txtFilterValue_TextChanged(object sender, EventArgs e)
    {
        filterTime.Stop();
        filterTime.Start();
    }

    private async Task ApplyRowFilteringAsync()
    {
        if (_isLoading)
            return;

        await LoadGridAsync(GetFilterDTO());
    }

    private Domain.Views.VisitView? GetFilterDTO()
    {
        if (!ValidateFilterValue())
            return null;

        var filterValue = txtFilterValue.Text;

        Domain.Views.VisitView? view = new();

        switch (_currentFilterColumn)
        {
            case GridColumns.PatientName:
                view.PatientName = filterValue;
                break;

            case GridColumns.VisitDateTime:
                view.VisitDateTime = dateTimePicker.Value;
                break;

            case GridColumns.VisitTreatments:
                view.VisitTreatmentsNames = filterValue;
                break;

            case GridColumns.TotalAmount:
                view.TotalAmount = decimal.Parse(filterValue); // Validated before
                break;

            case GridColumns.PaidAmount:
                view.PaidAmount = decimal.Parse(filterValue); // Validated before
                break;

            case GridColumns.DiscountAmount:
                view.DiscountAmount = decimal.Parse(filterValue); // Validated before
                break;

            case GridColumns.RemainedAmount:
                view.RemainedAmount = decimal.Parse(filterValue); // Validated before
                break;

            default:
                view = null;
                break;
        }

        return view;
    }

    private bool ValidateFilterValue()
    {
        /*
         
        PatientName, 
        VisitDateTime, 
        VisitTreatments, 
        TotalAmount, 
        PaidAmount,
        DiscountAmount,
        RemainedAmount
 

         */

        if (!txtFilterValue.Visible)
            return true;

        if (_currentFilterColumn
            is GridColumns.PatientName
            or GridColumns.VisitTreatments
            || (_currentFilterColumn == GridColumns.VisitDateTime && dateTimePicker.Visible))
        {
            return true;
        }

        if (_currentFilterColumn
            is GridColumns.TotalAmount
            or GridColumns.PaidAmount
            or GridColumns.DiscountAmount
            or GridColumns.RemainedAmount)
        {
            return txtFilterValueHasValidNumber;
        }

        if (string.IsNullOrWhiteSpace(txtFilterValue.Text) && txtFilterValue.Visible)
            return true;

        return false;
    }

    private bool txtFilterValueHasValidNumber
    {
        get =>
            decimal.TryParse(txtFilterValue.Text, out _);
    }

    private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (_currentFilterColumn is GridColumns.PaidAmount or GridColumns.DiscountAmount or GridColumns.RemainedAmount or GridColumns.TotalAmount)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
            else if (e.KeyChar == '.' && txtFilterValue.Text.Contains('.'))
            {
                e.Handled = true;
                return;
            }
        }
    }

    private async void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*

         اسم المريض
        تاريخ الزياره
        الخدمات المقدمه
        المبلغ الكلي
        المبلغ المدفوع
        مبلغ الخصم
        المبلغ المتبقي

         */

        _currentFilterColumn = cbFilterList.Text switch
        {
            "اسم المريض" => GridColumns.PatientName,
            "تاريخ الزياره" => GridColumns.VisitDateTime,
            "الخدمات المقدمه" => GridColumns.VisitTreatments,
            "المبلغ الكلي" => GridColumns.TotalAmount,
            "المبلغ المدفوع" => GridColumns.PaidAmount,
            "مبلغ الخصم" => GridColumns.DiscountAmount,
            "المبلغ المتبقي" => GridColumns.RemainedAmount,

            _ => throw new InvalidOperationException("Unknown filter column")
        };

        if (_currentFilterColumn is GridColumns.VisitDateTime)
        {
            txtFilterValue.Visible = false;
            dateTimePicker.Visible = true;
            dateTimePicker.Focus();
        }
        else
        {
            txtFilterValue.Visible = true;
            txtFilterValue.Focus();
            dateTimePicker.Visible = false;
        }

        if (!string.IsNullOrEmpty(txtFilterValue.Text))
            txtFilterValue.Clear();
        else
            await ApplyRowFilteringAsync();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        dateTimePicker.MaxDate = DateTime.Now;
    }

    private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right || e.RowIndex < 0 || e.RowIndex >= dataGridView.Rows.Count)
            return;

        dataGridView.ClearSelection();
        dataGridView.Rows[e.RowIndex].Selected = true;
        dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[3];

        _selectedRowIndex = e.RowIndex;
    }

    private async void filterTime_Tick(object sender, EventArgs e)
    {
        filterTime.Stop();
        await ApplyRowFilteringAsync();
    }

    private async void dateTimePicker_ValueChanged(object sender, EventArgs e)
    {
        await ApplyRowFilteringAsync();
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await Refresh();
    }

    private async void cmsEdit_Click(object sender, EventArgs e)
    {
        int? selectedVisitId = SelectedVisitId;
        int selectedRowIndex = _selectedRowIndex;

        if (!selectedVisitId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAddUpdateVisit(selectedVisitId.Value);
        await frm.ShowDialogAsync();

        await Refresh();
    }

    private new async Task Refresh()
    {
        _isLoading = true;
        Cursor = Cursors.WaitCursor;

        base.Refresh();

        await InitializeViewAsync();
        await LoadGridAsync(null);
        await LoadCardsAsync(GetCardsPeriod());

        Cursor = Cursors.Default;
        _isLoading = false;
    }

    private async void cmsAdd_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;

        using var frm = _formFactory.Create_frmAddUpdateVisit();
        await frm.ShowDialogAsync();

        await Refresh();

        Cursor = Cursors.Default;
    }

    private async void cmsRefreshGrid_Click(object sender, EventArgs e)
    {
        await Refresh();
    }

    private async void cmsDelete_Click(object sender, EventArgs e)
    {
        int? selectedVisitId = SelectedVisitId;

        if (!selectedVisitId.HasValue)
            return;

        if (MessageBox.Show(
            "هل انت متأكد من حذف جميع بيانات الزياره؟\nهذا الفعل لا يمكن التراجع عنه.",
            "تحذير",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
        {
            var deleteResult = await _visitService.DeleteAsync(selectedVisitId.Value);
            if (deleteResult.IsFailure)
            {
                HandelDeleteResult(deleteResult.Error);
            }
            else
            {
                MessageBoxExtensions.ShowInformation("تم حذف الزياره بنجاح.", "تم الحذف");
                await Refresh();
            }
        }
    }

    private void HandelDeleteResult(Error error)
    {
        switch (error.Code)
        {
            case "InvalidId":
                MessageBox.Show("يرجي تحديد زياره صالحه.", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                break;

            case "NotFound":
                MessageBoxExtensions.ShowError("الزياره غير موجوده.", "خطأ");
                break;

            default:
                MessageBoxExtensions.ShowError("يرجي تحديد زياره صالحه");
                break;
        }
    }

    private int? SelectedVisitId
    {
        get
        {
            if (_selectedRowIndex == -1 || _selectedRowIndex >= dataGridView.Rows.Count)
                return null;

            var cellValue = dataGridView.Rows[_selectedRowIndex].Cells[nameof(colVisitId)].Value;

            if (cellValue is null)
                return null;

            if (int.TryParse(cellValue?.ToString(), out var visitId))
                return visitId;

            return null;
        }
    }
}