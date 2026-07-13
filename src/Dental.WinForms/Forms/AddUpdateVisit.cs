using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Treatment;
using Dental.Application.DTOs.Visit;
using Dental.Application.DTOs.VisitToothNumber;
using Dental.Application.Errors;
using Dental.Application.ViewsStuff.Interfaces;
using Dental.Domain.Shared;
using Dental.Domain.Views;
using Dental.WinForms.Extensions;
using Dental.WinForms.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;

namespace Dental.WinForms.Forms;

public partial class frmAddUpdateVisit : Form
{
    private readonly ITreatmentService _treatmentService;
    private readonly ILogger<frmAddUpdateVisit> _logger;
    private readonly IVisitService _visitService;
    private readonly IVisitTreatmentService _visitToothTreatmentService;
    private readonly IVisitToothTreatmentsViewService _viewService;
    private readonly int _visitId;
    private int _selectedRowIndex = -1;
    private List<TreatmentResponseDto> _treatments;

    private enum Mode { Add, Update }
    private Mode _mode = Mode.Add;

    public frmAddUpdateVisit(
        ITreatmentService treatmentService,
        IVisitService visitService,
        IVisitTreatmentService visitToothTreatmentService,
        IVisitToothTreatmentsViewService viewService,
        ILogger<frmAddUpdateVisit> logger)
    {
        InitializeComponent();

        _treatmentService = treatmentService;
        _visitService = visitService;
        _visitToothTreatmentService = visitToothTreatmentService;
        _viewService = viewService;
        _logger = logger;
        _mode = Mode.Add;
    }

    public frmAddUpdateVisit(
        int visitId,
        ITreatmentService treatmentService,
        IVisitService visitService,
        IVisitTreatmentService visitToothTreatmentService,
        IVisitToothTreatmentsViewService viewService,
        ILogger<frmAddUpdateVisit> logger)
        : this(treatmentService,
              visitService,
              visitToothTreatmentService,
              viewService,
              logger)
    {
        _visitId = visitId;
        _mode = Mode.Update;
    }


    private async void AddUpdateVisit_Load(object sender, EventArgs e)
    {
        await InitializeAsync();

        if (_mode == Mode.Update)
            await LoadUi();
    }

    private async Task InitializeAsync()
    {
        try
        {
            InitializeFormTexts();
            await LoadDataGrid();

            if (_mode == Mode.Add)
            {
                InitializeDataGridDefaultValues();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex, "Error occurred while initializing visit data. Error Occurred in {ClassName}", nameof(frmAddUpdateVisit));

            MessageBoxExtensions.ShowError(
                "حدث خطأ أثناء تهيئة بيانات الزياره برجاء التواصل مع المطور.");
        }
    }

    private async Task LoadDataGrid()
    {
        var treatments = await _treatmentService.GetAllAsync();

        // Bind treatment name to the combo box
        colTreatmentName.DisplayMember = "Name";
        colTreatmentName.ValueMember = "Name";
        colTreatmentName.DataSource = treatments.Value;

        _treatments = treatments.Value;
    }

    private void InitializeFormTexts()
    {
        this.Text = _mode == Mode.Add ? "اضافة زياره" : "تعديل زياره";
        lblTitile.Text = _mode == Mode.Add ? "اضافة زياره جديده" : "تعديل بيانات زياره";
        lblVisitDateTime.Text = DateTimeHelper.GetArabicDateTime(DateTime.Now);
        dateTimePicker.Format = DateTimePickerFormat.Custom;
    }

    private async Task LoadUi()
    {
        var visit = await LoadVisitUi();

        if (visit != null)
            await LoadVisitToothTreatmentsUi(visit);
    }

    private async Task LoadVisitToothTreatmentsUi(VisitResponseDto visit)
    {
        var viewResult = await _viewService.GetAsync(_visitId);
        if (!HandelVisitToothTreatmentViewResult(viewResult))
            return;

        int currentRowIndex = 0;

        foreach (var view in viewResult.Value)
        {
            AssignViewToRowCells(view, currentRowIndex);
            currentRowIndex++;
        }

        decimal totalPrice = UpdateTotalPrice();
        decimal remainingAmount =
            totalPrice - (visit.PaidAmount.Value + visit.DiscountAmount.Value);

        txtRemainingAmount.Text = remainingAmount.ToString();
    }

    private void AssignViewToRowCells(VisitTreatmentsView view, int currentRowIndex)
    {
        // ToothNumber
        ((DataGridViewComboBoxCell)dataGridView.Rows[currentRowIndex].Cells[nameof(colToothNumber)])
            .Value = view.ToothNumber;

        // TreatmentName
        ((DataGridViewComboBoxCell)dataGridView.Rows[currentRowIndex].Cells[nameof(colTreatmentName)])
            .Value = view.Name;

        // Price
        ((DataGridViewComboBoxCell)dataGridView.Rows[currentRowIndex]
            .Cells[nameof(colTreatmentPrice)]).Value = view.Price;

        // Notes
        ((DataGridViewComboBoxCell)dataGridView.Rows[currentRowIndex]
            .Cells[nameof(colNotes)]).Value = view.Notes;
    }

    private bool HandelVisitToothTreatmentViewResult(
        Result<List<VisitTreatmentsView>> viewResult)
    {
        if (viewResult.IsFailure)
        {
            if (viewResult.Error == ServiceErrors.InvalidId)
            {
                MessageBoxExtensions.ShowError($"رقم الزياره {_visitId} غير صالح");
            }

            return false;
        }

        if (!viewResult.Value.Any())
        {
            MessageBoxExtensions.ShowWarning($"لا يوجد خدمات مقدمه في هذه الزياره.");
        }

        return true;
    }

    private bool HandelVisitResult(Result<VisitResponseDto> visitResult)
    {
        if (visitResult.IsFailure)
        {
            if (visitResult.Error == ServiceErrors.InvalidId)
            {
                MessageBoxExtensions.ShowError("رقم الزياره غير صحيح.");
            }
            else if (visitResult.Error == ServiceErrors.NotFound)
            {
                MessageBoxExtensions.ShowError($"الزياره رقم {_visitId} غير موجوده.");
            }

            return false;
        }

        return true;
    }

    private async Task<VisitResponseDto?> LoadVisitUi()
    {
        var visitResult = await _visitService.GetByIdAsync(_visitId);

        if (!HandelVisitResult(visitResult))
            return null;

        txtAppointmentId.Text = visitResult.Value.AppointmentId?.Value.ToString() ?? string.Empty;
        txtPaidAmount.Text = visitResult.Value.PaidAmount.ToString();
        txtDiscountAmount.Text = visitResult.Value.DiscountAmount.ToString();
        lblVisitDateTime.Text = DateTimeHelper.GetArabicDateTime(visitResult.Value.VisitDateTime);
        dateTimePicker.Value = visitResult.Value.VisitDateTime;
        txtNotes.Text = visitResult.Value.Notes ?? string.Empty;

        return visitResult.Value;
    }

    private void DataGridViewCellValueChanged(
        object sender, DataGridViewCellEventArgs e)
    {
        if (e is { ColumnIndex: 1, RowIndex: >= 0 } && e.RowIndex < dataGridView.Rows.Count)
        {
            AssignPriceToSelectedTreatment(e);
            UpdateTotalPrice();
        }
    }

    private decimal UpdateTotalPrice()
    {
        //decimal currentPrice = decimal.Parse(lblTotalPrice.Text);

        //decimal newPrice =
        //    (dataGridView.Rows.Cast<DataGridViewRow>()
        //        .Where(row => !row.IsNewRow)
        //        .Sum(row => GetTreatmentPriceFromGrid(row.Index))) + currentPrice;

        //lblTotalPrice.Text = newPrice.ToString();

        int rowsCount = dataGridView.Rows.Count;
        decimal sum = 0;
        for (int i = 0; i < rowsCount; i++)
        {
            decimal? rowTreatmentPrice = GetTreatmentPriceFromGrid(i);

            if (rowTreatmentPrice.HasValue)
                sum += rowTreatmentPrice.Value;
        }

        lblTotalPrice.Text = sum.ToString();
        return sum;
    }

    private void AssignPriceToSelectedTreatment(
        DataGridViewCellEventArgs e)
    {
        var selectedTreatmentName = dataGridView.Rows[e.RowIndex]
                .Cells[nameof(colTreatmentName)]
                .Value!
                .ToString();

        var selectedTreatmentPrice =
            _treatments.First(t => t.Name == selectedTreatmentName)
                .Price;

        dataGridView.Rows[e.RowIndex].Cells[nameof(colTreatmentPrice)].Value =
            selectedTreatmentPrice.ToString();
    }

    private string? SelectedTreatmentName
    {
        get
        {
            return dataGridView.Rows[_selectedRowIndex]
                .Cells[nameof(colTreatmentName)]
                .Value?.ToString();
        }
    }

    private int? SelectedTreatmentId
    {
        get
        {
            return _treatments
            .Where(t => t.Name == SelectedTreatmentName)
            .FirstOrDefault()
            ?.Id;
        }
    }

    private decimal? GetTreatmentPriceFromGrid(int rowIndex)
    {
        if (rowIndex < 0
            || rowIndex >= dataGridView.Rows.Count
            || rowIndex == dataGridView.NewRowIndex)
            return null;


        var cellValue = dataGridView.Rows[rowIndex]
            .Cells[nameof(colTreatmentPrice)]
            .Value;

        if (cellValue == null)
            return null;

        if (decimal.TryParse(cellValue.ToString(), out decimal price))
            return price;

        return null;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        if (!Validate(out bool areYouShowMessageIsShown))
            return;

        if (!MakeSure((areYouShowMessageIsShown)))
            return;


    }

    private bool MakeSure(bool areYouShowMessageIsShown)
    {
        if (!areYouShowMessageIsShown)
        {
            if (MessageBoxExtensions.ShowQuestion(
                    "هل انت متأكد من تسجيل الزياره؟.", "تأكيد") == DialogResult.No)
            {
                return false;
            }
        }

        if (dateTimePicker.Value > DateTime.Now)
        {
            if (MessageBoxExtensions.ShowQuestion("هل انت متأكد من جعل تاريخ الزياره في المستقبل؟") == DialogResult.No)
            {
                return false;
            }
        }

        return true;
    }

    private bool Validate(out bool areYouShowMessageIsShown)
    {
        areYouShowMessageIsShown = false;

        if (!ValidateTextboxes(out bool appointmentIdIsEmptyFlag))
            return false;

        if (!ValidateDataGrid())
            return false;

        if (appointmentIdIsEmptyFlag)
        {
            if (MessageBoxExtensions.ShowQuestion(
                    "هل تريد تسجيل زياره من غير ميعاد مسبق؟") == DialogResult.No)
            {
                areYouShowMessageIsShown = true;
                txtAppointmentId.Focus();
                return false;
            }

            areYouShowMessageIsShown = true;
        }

        return true;
    }

    private bool ValidateDataGrid()
    {
        if (!ValidateColumnCellsValues(nameof(colToothNumber), "يرجي اختيار رقم السن"))
            return false;

        if (!ValidateColumnCellsValues(nameof(colTreatmentName), "يرجي اختيار الخدمه المقدمه"))
            return false;

        return true;
    }

    private bool ValidateColumnCellsValues(string columnName, string errorMessage)
    {
        int cellsCount = dataGridView.Rows.Count;
        int newRowIndex = dataGridView.NewRowIndex;

        for (int i = 0; i < cellsCount; i++)
        {
            if (i != newRowIndex)
            {
                var cellValue = dataGridView.Rows[i].Cells[columnName].Value;
                if (cellValue == null)
                {
                    MessageBoxExtensions.ShowWarning($"{errorMessage} في الصف رقم {i + 1}.",
                        "تنبيه");

                    return false;
                }
            }

        }

        return true;
    }

    private bool ValidateTextboxes(out bool appointmentIdIsEmptyFlag)
    {
        appointmentIdIsEmptyFlag = false;

        // ========================== Appointment Id ==========================
        if (string.IsNullOrWhiteSpace(txtAppointmentId.Text))
        {
            appointmentIdIsEmptyFlag = true;
        }
        else if (!int.TryParse(txtAppointmentId.Text, out int appointmentId))
        {
            MessageBoxExtensions.ShowError("قيمة رقم الحجز غير صالحه.");
            return false;
        }
        else if (appointmentId <= 0)
        {
            MessageBoxExtensions.ShowError("قيمة رقم الحجز يجب ان تكون موجبه او فارغه.");
            return false;
        }

        if (GetTotalPriceFromLabel() is null or <= 0)
        {
            MessageBoxExtensions.ShowWarning("المبلغ الكلي لا يجب ان يكون قيمه سالبه.");
            return false;
        }

        // ========================== Paid Amount ==========================
        if (!decimal.TryParse(txtPaidAmount.Text, out decimal paidAmount))
        {
            MessageBoxExtensions.ShowError("قيمة المبلغ المدفوع غير صالحه.");
            return false;
        }
        else if (paidAmount < 0)
        {
            MessageBoxExtensions.ShowError("القيمه الموجبه لا يجب ان تكون سالبه.");
            return false;
        }

        // ========================== Discount Amount ==========================
        if (string.IsNullOrWhiteSpace(txtDiscountAmount.Text.ToString()))
        {
            // Do Nothing
            // This condition exists to do not check the next condition
        }
        else if (!decimal.TryParse(txtDiscountAmount.Text, out decimal discountAmount))
        {
            MessageBoxExtensions.ShowError("قيمة مبلغ الخصم غير صالحه.");
            return false;
        }
        else if (discountAmount < 0)
        {
            MessageBoxExtensions.ShowError("قيمة الخصم لا يجب ان تكون سالبه.");
            return false;
        }

        // ========================== Remaining Amount txtRemainingAmount
        if (string.IsNullOrWhiteSpace(txtRemainingAmount.Text))
        {
            // Do Nothing
            // This condition exists to do not check the next  condition
        }
        else if (!decimal.TryParse(txtRemainingAmount.Text, out decimal remainingAmount))
        {
            MessageBoxExtensions.ShowError("القيمه المتبقيه غير صالحه.");
            return false;
        }
        else if (remainingAmount < 0)
        {
            MessageBoxExtensions.ShowError("القيمه المتبقيه لا يجب ان تكون سالبه.");
            return false;
        }

        return true;
    }

    private void InitializeDataGridDefaultValues()
    {
        dataGridView.DataError += (_, _) => { };
        dataGridView.Rows.Add();

        // Add 1 as a default value for ToothNumber
        ((DataGridViewComboBoxCell)(dataGridView.Rows[0].Cells[nameof(colToothNumber)]))
            .Value = "1";

        // Add First Value of treatments names as a default value
        ((DataGridViewComboBoxCell)(dataGridView.Rows[0].Cells[nameof(colTreatmentName)]))
            .Value = _treatments.FirstOrDefault()?.Name ?? string.Empty;

        // Add First value of treatments prices as a default value
        var firstValuePrice = _treatments.FirstOrDefault()?.Price;
        ((DataGridViewTextBoxCell)(dataGridView.Rows[0].Cells[nameof(colTreatmentPrice)])).Value =
            firstValuePrice == null ? string.Empty : firstValuePrice;

        // Set the current only price to the lblPrice
        lblTotalPrice.Text = firstValuePrice.ToString();

        // First row height
        dataGridView.Rows[1].Height = 35;
    }

    private void dataGridView_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hit = dataGridView.HitTest(e.X, e.Y);
            if (hit.RowIndex >= 0)
            {
                _selectedRowIndex = hit.RowIndex;
                dataGridView.ClearSelection();
                dataGridView.Rows[_selectedRowIndex].Selected = true;
            }
        }
    }

    private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
        if (_selectedRowIndex < 0 || _selectedRowIndex > dataGridView.Rows.Count)
            e.Cancel = true;
    }

    private void cmsDelete_Click(object sender, EventArgs e)
    {
        DeleteRow(_selectedRowIndex);
    }

    private void DeleteRow(int index)
    {
        if (index < 0 || index > dataGridView.Rows.Count)
            return;

        if (dataGridView.Rows.Count is 1)
        {
            MessageBox.Show("يجب ان يكون هناك صف واحد علي الأقل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return;
        }

        if (!dataGridView.Rows[index].IsNewRow)
        {
            dataGridView.Rows.RemoveAt(index);
        }
        else
        {
            MessageBox.Show("لا يمكن حذف الصف الفارغ. هذا الصف غير مؤثر يمكنك تجاهله.", "خطأ", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void cmsEdit_Click(object sender, EventArgs e)
    {
        int? selectedTreatmentId = SelectedTreatmentId;

        if (selectedTreatmentId != null)
        {
            var frm = new frmAddEditTreatment((int)selectedTreatmentId!);
            frm.ShowDialog();
        }
    }

    private void txtAppointmentId_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
    }

    private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            e.Handled = true;

        if (e.KeyChar == '.' && txtPaidAmount.Text.Contains('.'))
            e.Handled = true;
    }

    private void txtMoney_TextChanged(object sender, EventArgs e)
    {
        decimal totalAmount = GetTotalPriceFromLabel() ?? 0;
        decimal paidAmount = GetPaidAmountFromTextbox() ?? 0;
        decimal discountAmount = GetDiscountPriceFromTextbox() ?? 0;

        decimal remainingAmount = totalAmount - (paidAmount + discountAmount);

        txtRemainingAmount.Text = remainingAmount.ToString();
    }

    private decimal? GetTotalPriceFromLabel()
    {
        var stringValue = lblTotalPrice.Text;

        if (string.IsNullOrWhiteSpace(stringValue))
            return null;

        if (decimal.TryParse(stringValue, out decimal decimalValue))
            return decimalValue;

        return null;
    }

    private decimal? GetPaidAmountFromTextbox()
    {
        var stringValue = txtPaidAmount.Text;

        if (string.IsNullOrWhiteSpace(stringValue))
            return null;

        if (decimal.TryParse(stringValue, out decimal decimalValue))
            return decimalValue;

        return null;
    }

    private decimal? GetDiscountPriceFromTextbox()
    {
        var stringValue = txtDiscountAmount.Text;

        if (string.IsNullOrWhiteSpace(stringValue))
            return null;

        if (decimal.TryParse(stringValue, out decimal decimalValue))
            return decimalValue;

        return null;
    }

    private void dateTimePicker_ValueChanged(object sender, EventArgs e)
    {
        lblVisitDateTime.Text = DateTimeHelper.GetArabicDateTime(dateTimePicker.Value);
    }
}