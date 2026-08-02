using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.ViewsStuff.Interfaces.Visits;
using Dental.Domain.Shared;
using Dental.Domain.Views.Visit;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Forms;
using Dental.WinForms.Helpers;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Dental.WinForms.Views;

public partial class VisitsView : UserControl
{
    private readonly IFormFactory _formFactory;
    private readonly ILogger<VisitsView> _logger;
    private readonly IVisitViewService _visitViewService;
    private readonly IVisitService _visitService;

    private int _selectedRowIndex = -1;
    private bool _isLoading = true;

    private Stopwatch _lastFilteringSince = new();


    private enum GridColumns
    {
        VisitId,
        AppointmentId,
        PatientName,
        VisitDateTime,
        VisitTreatments,
        TotalAmount,
        TotalPaidAmounts,
        DiscountAmount,
        RemainedAmount
    }
    private GridColumns _currentFilterColumn = GridColumns.PatientName;

    public VisitsView(
        IFormFactory formFactory,
        ILogger<VisitsView> logger,
        IVisitViewService visitViewService,
        IVisitService visitService)
    {
        InitializeComponent();

        _formFactory = formFactory;
        _logger = logger;
        _visitViewService = visitViewService;
        _visitService = visitService;
    }


    private async void VisitView_Load(object sender, EventArgs e)
    {
        try
        {
            await InitializeViewAsync();
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

        dtpVisitDateTime.MaxDate = DateTime.Now;
        dtpSearchAfter.MaxDate = DateTime.Now;
        // Set to one second before now to avoid future date issues
        dtpVisitDateTime.Value = DateTime.Now.AddSeconds(-1);

        lblSearchAfter.Visible = false;
        dtpSearchAfter.Visible = false;

        txtFilterValue.Clear();
        txtFilterValue.Visible = true;

        dataGridView.AlternatingRowsDefaultCellStyle = null;

        rbToday.Checked = false;
        rbThisMonth.Checked = false;
        rbAllTime.Checked = true;

        timerUpdateDateTimePckerMaxDate.Start();
        LoadDataFirstTimeTimer.Start();
    }

    public async Task LoadGridAsync(VisitView? filterDTO)
    {
        Cursor = Cursors.WaitCursor;

        var view = await _visitViewService.GetAsync(filterDTO);
        var result = view
            .Select(v => new
            {
                v.VisitId,
                v.AppointmentId,
                v.PatientId,
                v.PatientName,
                v.VisitTreatmentsNames,

                VisitDateTime = v.VisitDateTime is not null
                    ? DateTimeHelper.GetArabicDateTime(v.VisitDateTime.Value)
                    : null,

                TotalAmount = v.TotalAmount.HasValue ?
                $"{v.TotalAmount.Value:F2}"
                : null,

                TotalPaidAmount = v.SumOfPaidAmounts.HasValue ?
                    $"{v.SumOfPaidAmounts.Value:F2}"
                    : null,

                DiscountAmount =
                    v.DiscountAmount.HasValue ?
                    $"{v.DiscountAmount.Value:F2}"
                    : null,

                RemainedAmount = v.RemainedAmount.HasValue ?
                    $"{v.RemainedAmount.Value:F2}"
                    : null
            })
            .ToList();

        dataGridView.DataSource = result;

        Cursor = Cursors.Default;

        LoadCards(view);
        _lastFilteringSince = Stopwatch.StartNew();
    }

    private void LoadCards(List<VisitView> view)
    {
        lblTotalVisits.Text = view.Count.ToString();

        lblSumOfTotalAmount.Text =
            view.Sum(v => v.TotalAmount ?? 0).ToString("F2");

        lblSumOfPaidAmounts.Text =
            view.Sum(v => v.SumOfPaidAmounts ?? 0).ToString("F2");

        lblSumOfDiscountAmount.Text =
            view.Sum(v => v.DiscountAmount ?? 0).ToString("F2");

        lblSumOfRemainedAmount.Text =
            view.Sum(v => v.RemainedAmount ?? 0).ToString("F2");
    }

    private async void btnAddWalkInVisit_Click(object sender, EventArgs e)
    {
        Cursor = Cursors.WaitCursor;

        using var frm = _formFactory.Create_frmAddEditVisit(Forms.frmAddEditVisit.VisitType.WalkIn);
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
        dtpSearchAfter.Visible = true;
        lblSearchAfter.Visible = true;

        if (rbToday.Checked)
            dtpSearchAfter.Value = DateTime.Today.Date.ToLocalTime();
        else if (rbThisWeek.Checked)
            dtpSearchAfter.Value = DateTime.Today.Date.StartOfWeek().ToLocalTime();
        else if (rbThisMonth.Checked)
            dtpSearchAfter.Value = DateTime.Today.Date.StartOfMonth().ToLocalTime();
        else if (rbAllTime.Checked)
        {
            dtpSearchAfter.Visible = false;
            lblSearchAfter.Visible = false;
            dtpSearchAfter.Value = dtpSearchAfter.MinDate.Date;
        }
    }

    private void txtFilterValue_TextChanged(object sender, EventArgs e)
    {
        filterTimer.Start();
    }

    private async Task ApplyRowFilteringAsync()
    {
        if (_isLoading || _lastFilteringSince.ElapsedMilliseconds < 300)
            return;

        await LoadGridAsync(GetFilterDto());
    }

    private VisitView? GetFilterDto()
    {
        var filterValue = txtFilterValue.Text;
        VisitView? view = null;

        switch (_currentFilterColumn)
        {
            case GridColumns.VisitId:
                if (int.TryParse(filterValue, out int visitId))
                    view = new VisitView { VisitId = visitId };
                break;

            case GridColumns.AppointmentId:
                if (int.TryParse(filterValue, out int appointmentId))
                    view = new VisitView { AppointmentId = appointmentId };
                break;

            case GridColumns.PatientName:
                view = new VisitView { PatientName = filterValue };
                break;

            case GridColumns.VisitTreatments:
                view = new VisitView { VisitTreatmentsNames = filterValue };
                break;

            case GridColumns.TotalAmount:
                if (decimal.TryParse(filterValue, out var totalAmount))
                    view = new VisitView { TotalAmount = totalAmount };
                break;

            case GridColumns.TotalPaidAmounts:
                if (decimal.TryParse(filterValue, out var paidAmount))
                    view = new VisitView { SumOfPaidAmounts = paidAmount };
                break;

            case GridColumns.DiscountAmount:
                if (decimal.TryParse(filterValue, out var discountAmount))
                    view = new VisitView { DiscountAmount = discountAmount };
                break;

            case GridColumns.RemainedAmount:
                if (decimal.TryParse(filterValue, out var remainedAmount))
                    view = new VisitView { RemainedAmount = remainedAmount };
                break;
        }

        if (dtpSearchAfter.Visible)
        {
            if (view is not null)
                view.GetViewsAfterDateTime = dtpSearchAfter.Value.Date;
            else
                view = new VisitView { GetViewsAfterDateTime = dtpSearchAfter.Value.Date };

            return view;
        }

        if (_currentFilterColumn == GridColumns.VisitDateTime && dtpVisitDateTime.Visible)
        {
            if (view is not null)
                view.VisitDateTime = dtpVisitDateTime.Value.Date;
            else
                view = new VisitView { VisitDateTime = dtpVisitDateTime.Value.Date };

            return view;
        }

        if (pnlSearchAtRadioButtons.Visible && rbAllTime.Checked)
            view?.GetViewsAfterDateTime = null;


        return view;
    }

    private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (_currentFilterColumn
            is GridColumns.TotalPaidAmounts
            or GridColumns.DiscountAmount
            or GridColumns.RemainedAmount
            or GridColumns.TotalAmount)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && txtFilterValue.Text.Contains('.'))
            {
                e.Handled = true;
                return;
            }
        }

        if (_currentFilterColumn
            is GridColumns.VisitId
            or GridColumns.AppointmentId)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

    private async void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*

         اسم المريض
        تاريخ الزياره
        الخدمات المقدمه
        مجموع المبالغ المدفوعه
        المبلغ المدفوع
        مبلغ الخصم
        المبلغ المتبقي

         */

        _currentFilterColumn = cbFilterList.Text switch
        {
            "رقم الزياره" => GridColumns.VisitId,
            "رقم الحجز" => GridColumns.AppointmentId,
            "اسم المريض" => GridColumns.PatientName,
            "تاريخ الزياره" => GridColumns.VisitDateTime,
            "الخدمات المقدمه" => GridColumns.VisitTreatments,
            "مجموع المبالغ المدفوعه" => GridColumns.TotalAmount,
            "المبلغ المدفوع" => GridColumns.TotalPaidAmounts,
            "مبلغ الخصم" => GridColumns.DiscountAmount,
            "المبلغ المتبقي" => GridColumns.RemainedAmount,

            _ => throw new InvalidOperationException("Unknown filter column")
        };

        if (_currentFilterColumn is GridColumns.VisitDateTime)
        {
            txtFilterValue.Visible = false;
            dtpVisitDateTime.Visible = true;
            dtpVisitDateTime.Focus();

            DisableSearchAfter();
        }
        else
        {
            txtFilterValue.Visible = true;
            txtFilterValue.Focus();
            dtpVisitDateTime.Visible = false;

            EnableSearchAfter();

            if (rbAllTime.Checked)
            {
                lblSearchAfter.Visible = false;
                dtpSearchAfter.Visible = false;
            }

        }

        if (!string.IsNullOrEmpty(txtFilterValue.Text))
            txtFilterValue.Clear();
        else
            await ApplyRowFilteringAsync();
    }

    private void EnableSearchAfter()
    {
        dtpSearchAfter.Visible = true;
        lblSearchAfter.Visible = true;
        pnlSearchAtRadioButtons.Visible = true;
    }

    private void DisableSearchAfter()
    {
        dtpSearchAfter.Visible = false;
        lblSearchAfter.Visible = false;
        pnlSearchAtRadioButtons.Visible = false;
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        dtpSearchAfter.MaxDate = DateTime.Now;
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

    private async void filterTimer_Tick(object sender, EventArgs e)
    {
        filterTimer.Stop();
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
        Cursor = Cursors.WaitCursor;

        int? selectedVisitId = SelectedVisitId;

        if (!selectedVisitId.HasValue)
            return;


        using var frm = _formFactory.Create_frmAddEditVisit(selectedVisitId.Value);
        await frm.ShowDialogAsync();

        await Refresh();

        Cursor = Cursors.Default;
    }

    private new async Task Refresh()
    {
        Cursor = Cursors.WaitCursor;

        _isLoading = true;
        base.Refresh();
        await InitializeViewAsync();
        _isLoading = false;

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
            "هل انت متأكد من حذف جميع بيانات الزياره؟",
            "تحذير",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2,
            MessageBoxOptions.RtlReading) == DialogResult.Yes)
        {
            var deleteResult = await _visitService.DeleteAsync(selectedVisitId.Value);
            if (deleteResult.IsFailure)
            {
                HandelDeleteResult(deleteResult.Error);
            }
            else
            {
                MessageBoxExtensions.ShowInfo("تم حذف الزياره بنجاح.", "تم الحذف");
                await Refresh();
            }
        }
    }

    private void HandelDeleteResult(Error error)
    {
        switch (error.Code)
        {
            case "InvalidId":
                MessageBoxExtensions.ShowError("يرجي تحديد زياره صالحه.", "خطأ");
                break;

            case "NotFound":
                MessageBoxExtensions.ShowError("الزياره غير موجوده.", "خطأ");
                break;

            default:
                MessageBoxExtensions.ShowError("يرجي تحديد زياره صالحه", "خطأ");
                break;
        }
    }

    private void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        var currentRowIndex = dataGridView.CurrentRow?.Index;
        if (!currentRowIndex.HasValue
            || currentRowIndex.Value < 0
            || currentRowIndex.Value >= dataGridView.Rows.Count)
            return;

        _selectedRowIndex = currentRowIndex.Value;
        cmsEdit_Click(sender, e);
    }

    private async void cmsShowPatientDetails_Click(object sender, EventArgs e)
    {
        var patientId = SelectedPatientId;
        if (!patientId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAddEditPatient(patientId.Value);
        await frm.ShowDialogAsync();
    }

    private async void cmsShowAppointmentDetails_Click(object sender, EventArgs e)
    {
        var appointmentId = SelectedAppointmentId;
        if (!appointmentId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAppointmentInfo(appointmentId.Value);
        await frm.ShowDialogAsync();
    }

    private async void btnCreatePreAppointmentVisit_Click(object sender, EventArgs e)
    {
        using var frm = _formFactory.Create_frmAddEditVisit(Forms.frmAddEditVisit.VisitType.PreAppointment);
        await frm.ShowDialogAsync();
        await Refresh();
    }

    private async void LoadDataFirstTimeTimer_Tick(object sender, EventArgs e)
    {
        LoadDataFirstTimeTimer.Stop();
        await LoadGridAsync(null!);
    }

    private async void tsmiAddNewRadiographToTheSameVisit_Click(object sender, EventArgs e)
    {
        var visitId = SelectedVisitId;
        if (visitId is not > 0)
            return;

        using var frm = _formFactory.Create_frmAddEditVisitRadioghraph();
        frm.VisitId = visitId.Value;
        await frm.ShowDialogAsync();
    }

    private async void tsmiAddNewVisitToTheSamePatient_Click(object sender, EventArgs e)
    {
        var visitId = SelectedPatientId;
        if (visitId is not > 0)
            return;

        using var frm = _formFactory.Create_frmAddEditVisit(frmAddEditVisit.VisitType.WalkIn);
        frm.Id = visitId.Value;
        await frm.ShowDialogAsync();
    }

    private int? SelectedAppointmentId
    {
        get
        {
            if (_selectedRowIndex == -1 || _selectedRowIndex >= dataGridView.Rows.Count)
                return null;

            var cellValue =
                dataGridView.Rows[_selectedRowIndex].Cells[nameof(colAppointmentId)].Value;

            if (int.TryParse(cellValue?.ToString(), out var appointmentId))
                return appointmentId;

            return null;
        }
    }

    private int? SelectedVisitId
    {
        get
        {
            if (_selectedRowIndex == -1 || _selectedRowIndex >= dataGridView.Rows.Count)
                return null;

            var cellValue =
                dataGridView.Rows[_selectedRowIndex].Cells[nameof(colVisitId)].Value;

            if (int.TryParse(cellValue?.ToString(), out var visitId))
                return visitId;

            return null;
        }
    }

    private int? SelectedPatientId
    {
        get
        {
            if (_selectedRowIndex == -1 || _selectedRowIndex >= dataGridView.Rows.Count)
                return null;

            var cellValue =
                dataGridView.Rows[_selectedRowIndex].Cells[nameof(colPatientId)].Value;

            if (int.TryParse(cellValue?.ToString(), out var patientId))
                return patientId;

            return null;
        }
    }
}