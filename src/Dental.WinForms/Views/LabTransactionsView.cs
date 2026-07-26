using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.ViewsStuff.Interfaces.LabTransactions;
using Dental.Domain.Views.LabTransactions;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Helpers;
using Microsoft.Extensions.Logging;

namespace Dental.WinForms.Views;

public partial class LabTransactionsView : UserControl
{
    private readonly IFormFactory _formFactory;
    private readonly ILabTransactionService _labTransactionService;
    private readonly ILabTransactionViewService _labTransactionViewService;
    private readonly ILogger<LabTransactionsView> _logger;
    private bool _isLoading = true;

    private enum GridColumns
    {
        LabName,
        TranDateTime,
        TotalAmount,
        PaidAmount,
        RemainingAmount,
        Treatments
    }
    private GridColumns _currentGridColumn = GridColumns.LabName;

    private static class Constants
    {
        public static class cbSearchBy
        {
            public const string LabName = "إسم المعمل";
            public const string TranDateTime = "تاريخ المعامله";
            public const string TotalAmount = "القيمه الكليه";
            public const string PaidAmount = "القيمه المدفوعه";
            public const string RemainingAmount = "القيمه المتبقيه";
            public const string Treatments = "المشتريات";
        }
    }

    public LabTransactionsView(
        IFormFactory formFactory,
        ILabTransactionService labTransactionService,
        ILabTransactionViewService labTransactionViewService,
        ILogger<LabTransactionsView> logger)
    {
        InitializeComponent();
        _isLoading = true;

        _formFactory = formFactory;
        _labTransactionService = labTransactionService;
        _labTransactionViewService = labTransactionViewService;
        _logger = logger;

        dataGridView.AutoGenerateColumns = false;
        dataGridView.DataSource = null;
        dataGridView.AlternatingRowsDefaultCellStyle = null;
    }

    private void LabTransactionsView_Load(object sender, EventArgs e)
    {
        _isLoading = true;
        Initialize();
        _isLoading = false;
    }

    private void Initialize()
    {
        _currentGridColumn = GridColumns.LabName;
        cbFilterList.Text = Constants.cbSearchBy.LabName;

        dateTimePicker.MaxDate = DateTime.Now;
        dateTimePicker.Value = DateTime.Now.AddSeconds(-1);

        lblSearchAfter.Visible = false;
        dtpSearchAfter.Visible = false;

        txtFilterValue.Clear();
        txtFilterValue.Visible = true;

        rbToday.Checked = false;
        rbThisMonth.Checked = false;
        rbAllTime.Checked = true;

        timerUpdateDateTimePckerMaxDate.Start();
        loadDataTimer.Start();
    }

    private async Task LoadGridAsync(LabTransactionFilterDto? filterDto = null)
    {
        if (_isLoading)
            return;

        Cursor = Cursors.WaitCursor;

        try
        {
            var data = await _labTransactionViewService.GetAsync(filterDto);

            var dataSource = data.Select(x => new
            {
                x.Id,
                x.LabName,

                TranDateTime = x.TranDateTime.HasValue ? DateTimeHelper.GetArabicDateTime(x.TranDateTime.Value) : string.Empty,

                TotalAmount = $"{x.TotalAmount:F2}",
                PaidAmount = $"{x.PaidAmount:F2}",
                RemainingAmount = $"{x.RemainingAmount:F2}",

                x.Treatments
            }).ToList();

            dataGridView.DataSource = dataSource;

            await LoadCardsAsync(data);
        }
        catch (Exception ex)
        {
            MessageBoxExtensions.ShowError($"حدث خطأ أثناء تحميل البيانات. {ex.Message}");
            _logger.LogError(ex, "Error loading lab transactions grid.");
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private async Task LoadCardsAsync(List<LabTransactionFilterDto> data)
    {
        lblTransCount.Text = data.Count.ToString();
        lblSumOfTotalAmount.Text = $"{data.Sum(x => x.TotalAmount):F2}";
        lblSumOfPaidAmount.Text = $"{data.Sum(x => x.PaidAmount):F2}";
        lblSumOfRemainedAmount.Text = $"{data.Sum(x => x.RemainingAmount):F2}";
    }

    private LabTransactionFilterDto? GetFilterDto()
    {
        var filterDto = new LabTransactionFilterDto();
        switch (_currentGridColumn)
        {
            case GridColumns.LabName:
                if (!string.IsNullOrWhiteSpace(txtFilterValue.Text))
                {
                    filterDto.LabName = txtFilterValue.Text.Trim();
                }
                break;
            case GridColumns.TranDateTime:
                if (dateTimePicker.Visible)
                    filterDto.TranDateTime = dateTimePicker.Value.Date;
                break;
            case GridColumns.TotalAmount:
                if (decimal.TryParse(txtFilterValue.Text, out decimal totalAmount))
                {
                    filterDto.TotalAmount = totalAmount;
                }
                break;
            case GridColumns.PaidAmount:
                if (decimal.TryParse(txtFilterValue.Text, out decimal paidAmount))
                {
                    filterDto.PaidAmount = paidAmount;
                }
                break;
            case GridColumns.RemainingAmount:
                if (decimal.TryParse(txtFilterValue.Text, out decimal remainingAmount))
                {
                    filterDto.RemainingAmount = remainingAmount;
                }
                break;
            case GridColumns.Treatments:
                if (!string.IsNullOrWhiteSpace(txtFilterValue.Text))
                {
                    filterDto.Treatments = txtFilterValue.Text.Trim();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException($"Unexpected grid column: {_currentGridColumn}");
        }

        if (rbAllTime.Checked)
        {
            filterDto.GetAfter = null;
        }
        else
        {
            filterDto.GetAfter = dtpSearchAfter.Value.Date;
        }

        return filterDto;
    }

    private new void Refresh()
    {
        _isLoading = true;
        Initialize();
        _isLoading = false;
    }

    private void timerUpdateDateTimePckerMaxDate_Tick(object sender, EventArgs e)
    {
        dateTimePicker.MaxDate = DateTime.Now;
    }

    private async void loadDataTimer_Tick(object sender, EventArgs e)
    {
        loadDataTimer.Stop();
        await LoadGridAsync();
    }

    private async void cbFilterList_SelectedIndexChanged(object sender, EventArgs e)
    {
        _currentGridColumn = cbFilterList.Text switch
        {
            Constants.cbSearchBy.LabName => GridColumns.LabName,
            Constants.cbSearchBy.TranDateTime => GridColumns.TranDateTime,
            Constants.cbSearchBy.TotalAmount => GridColumns.TotalAmount,
            Constants.cbSearchBy.PaidAmount => GridColumns.PaidAmount,
            Constants.cbSearchBy.RemainingAmount => GridColumns.RemainingAmount,
            Constants.cbSearchBy.Treatments => GridColumns.Treatments,
            _ => throw new ArgumentOutOfRangeException(
                $"Unexpected filter value: {cbFilterList.Text}"),
        };

        txtFilterValue.Visible = _currentGridColumn != GridColumns.TranDateTime;
        dateTimePicker.Visible = _currentGridColumn == GridColumns.TranDateTime;

        if (_currentGridColumn != GridColumns.TranDateTime)
        {
            txtFilterValue.Clear();
            txtFilterValue.Focus();
            EnableSearchAfter();
        }
        else
        {
            dateTimePicker.Value = DateTime.Now.AddSeconds(-1);
            dataGridView.Focus();
            DisableSearchAfter();
        }

        if (rbAllTime.Checked)
        {
            lblSearchAfter.Visible = false;
            dtpSearchAfter.Visible = false;
        }

        await LoadGridAsync(GetFilterDto());
    }

    private async void txtFilterValue_TextChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(GetFilterDto());
    }

    private async void dateTimePicker_ValueChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(GetFilterDto());
    }

    private void RadioButtonsFilterPeriods_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is RadioButton radioButton && radioButton.Checked)
        {
            dtpSearchAfter.Visible = true;
            lblSearchAfter.Visible = true;

            if (radioButton == rbToday)
            {
                dtpSearchAfter.Value = DateTime.Now.Date;
            }
            else if (radioButton == rbThisWeek)
            {
                dtpSearchAfter.Value = DateTime.Today.Date.StartOfWeek();
            }
            else if (radioButton == rbThisMonth)
            {
                dtpSearchAfter.Value = DateTime.Today.Date.StartOfMonth();
            }
            else if (radioButton == rbAllTime)
            {
                dtpSearchAfter.Visible = false;
                lblSearchAfter.Visible = false;
                dtpSearchAfter.Value = dtpSearchAfter.MinDate.Date;
            }
        }
    }

    private void DisableSearchAfter()
    {
        dtpSearchAfter.Visible = false;
        lblSearchAfter.Visible = false;
        pnlSearchAtRadioButtons.Visible = false;
    }

    private void EnableSearchAfter()
    {
        dtpSearchAfter.Visible = true;
        lblSearchAfter.Visible = true;
        pnlSearchAtRadioButtons.Visible = true;
    }

    private async void dtpSearchAfter_ValueChanged(object sender, EventArgs e)
    {
        await LoadGridAsync(GetFilterDto());
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        Refresh();
    }

    private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (_currentGridColumn is GridColumns.TotalAmount
            or GridColumns.PaidAmount
            or GridColumns.RemainingAmount)
        {
            // Allow only digits, control characters (like backspace), and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox)?.Text.Contains('.') == true)
            {
                e.Handled = true;
            }
        }
    }

    private async void btnNewTran_Click(object sender, EventArgs e)
    {
        using var frm = _formFactory.Create_frmAddEditLabTransaction();
        await frm.ShowDialogAsync();
        Refresh();
    }

    private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e is { Button: MouseButtons.Right, RowIndex: >= 0, ColumnIndex: >= 0 } &&
            e.RowIndex < dataGridView.Rows.Count)
        {
            dataGridView.ClearSelection();
            dataGridView.Rows[e.RowIndex].Selected = true;
            dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }
    }

    private async void tsmiEdit_Click(object sender, EventArgs e)
    {
        var tranId = SelectedTranId;
        if (!tranId.HasValue)
            return;

        using var frm = _formFactory.Create_frmAddEditLabTransaction(tranId.Value);
        await frm.ShowDialogAsync();
        Refresh();
    }

    private void tsmiAdd_Click(object sender, EventArgs e)
    {
        btnNewTran_Click(sender, e);
    }

    private async void tsmiDelete_Click(object sender, EventArgs e)
    {
        var tranId = SelectedTranId;
        if (tranId is not > 0)
            return;

        var result = MessageBoxExtensions.ShowQuestion("هل أنت متأكد من حذف المعامله؟", "تأكيد");
        if (result != DialogResult.Yes)
            return;

        Cursor = Cursors.WaitCursor;

        try
        {
            var deleteResult = await _labTransactionService.DeleteAsync(tranId.Value);
            if (deleteResult.IsFailure)
            {
                if (deleteResult.Error.Code == "NotFound")
                {
                    MessageBoxExtensions.ShowWarning("المعامله غير موجوده أو تم حذفها مسبقاً.");
                }
                else
                {
                    MessageBoxExtensions.ShowError($"حدث خطأ أثناء حذف المعامله. {deleteResult.Error.Message}");
                    _logger.LogError("Error deleting lab transaction with ID {TranId}. Error: {ErrorMessage}", tranId.Value, deleteResult.Error.Message);
                }

                return;
            }

            MessageBoxExtensions.ShowInfo("تم حذف المعامله بنجاح.");
            Refresh();
        }
        finally
        {
            Cursor = Cursors.Default;
        }
    }

    private void tsmiCopyTreatments_Click(object sender, EventArgs e)
    {
        var treatments = SelectedTranTreatments;

        if (!string.IsNullOrWhiteSpace(treatments))
            Clipboard.SetText(treatments, TextDataFormat.Text);
    }

    private void tsmiRefresh_Click(object sender, EventArgs e)
    {
        Refresh();
    }

    private int? SelectedTranId
    {
        get
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index;
            if (currentRowIndex is >= 0 && currentRowIndex < dataGridView.Rows.Count)
            {
                var cellValue = dataGridView.Rows[currentRowIndex.Value]
                    .Cells[nameof(colId)].Value;

                if (cellValue is int id)
                    return id;
            }

            return null;
        }
    }

    private string? SelectedTranTreatments
    {
        get
        {
            var currentRowIndex = dataGridView.CurrentRow?.Index;
            if (currentRowIndex is >= 0 && currentRowIndex < dataGridView.Rows.Count)
            {
                var cellValue = dataGridView.Rows[currentRowIndex.Value]
                    .Cells[nameof(colTreatments)].Value;
                if (cellValue is string treatments)
                    return treatments;
            }
            return null;
        }
    }
}