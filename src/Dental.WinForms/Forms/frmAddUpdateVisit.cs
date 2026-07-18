using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Treatment;
using Dental.Application.DTOs.Visit;
using Dental.Application.DTOs.VisitToothNumber;
using Dental.Application.Errors;
using Dental.Application.ViewsStuff.Interfaces;
using Dental.Domain.Shared;
using Dental.Domain.Views;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Helpers;
using Microsoft.Extensions.Logging;

namespace Dental.WinForms.Forms;

public partial class frmAddUpdateVisit : Form
{
    private readonly ITreatmentService _treatmentService;
    private readonly ILogger<frmAddUpdateVisit> _logger;
    private readonly IVisitService _visitService;
    private readonly IVisitTreatmentService _visitTreatmentService;
    private readonly IVisitToothTreatmentsViewService _viewService;
    private readonly IFormFactory _formFactory;
    private readonly int _visitId;
    private int _selectedRowIndex = -1;
    private List<TreatmentResponseDto> _treatments = [];

    private enum Mode { Add, Update }
    private Mode _mode = Mode.Add;

    public frmAddUpdateVisit(
        ITreatmentService treatmentService,
        IVisitService visitService,
        IVisitTreatmentService visitToothTreatmentService,
        IVisitToothTreatmentsViewService viewService,
        ILogger<frmAddUpdateVisit> logger,
        IFormFactory formFactory)
    {
        InitializeComponent();

        _treatmentService = treatmentService;
        _visitService = visitService;
        _visitTreatmentService = visitToothTreatmentService;
        _viewService = viewService;
        _logger = logger;
        _formFactory = formFactory;
        _mode = Mode.Add;
    }

    public frmAddUpdateVisit(
        int visitId,
        ITreatmentService treatmentService,
        IVisitService visitService,
        IVisitTreatmentService visitToothTreatmentService,
        IVisitToothTreatmentsViewService viewService,
        ILogger<frmAddUpdateVisit> logger,
        IFormFactory formFactory)
        : this(treatmentService,
              visitService,
              visitToothTreatmentService,
              viewService,
              logger,
              formFactory)
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
            dataGridView.DataError += (_, _) => { };
            //dataGridView.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
            //dataGridView.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            //dataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

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
        colTreatmentName.DataSource = treatments;

        _treatments = treatments;
    }

    private void InitializeFormTexts()
    {
        Text = _mode == Mode.Add ? "اضافة زياره" : "تعديل زياره";
        lblTitile.Text = _mode == Mode.Add ? "اضافة زياره جديده" : "تعديل بيانات زياره";
        lblVisitDateTime.Text = DateTimeHelper.GetArabicDateTime(DateTime.Now);
        dateTimePicker.MaxDate = DateTime.Now;
    }

    private async Task LoadUi()
    {
        var visit = await LoadVisitUi();

        if (visit != null)
        {
            await LoadVisitToothTreatmentsUi(visit);

            if (dataGridView.Rows.Count - 1 > 0)
                dataGridView.Rows[1].Height = 35;
        }
    }

    private async Task LoadVisitToothTreatmentsUi(VisitResponseDto visit)
    {
        var viewResult = await _viewService.GetAsync(_visitId);
        if (!HandelGetVisitToothTreatmentViewResult(viewResult))
            return;

        // Clear the gird first
        dataGridView.Rows.Clear();

        var viewsCount = viewResult.Value.Count;

        if (viewsCount > 0)
        {
            // Fill the grid with empty rows same as views count
            dataGridView.Rows.Add(viewsCount);
        }

        for (int i = 0; i < viewsCount; i++)
        {
            AssignViewToRowCells(viewResult.Value[i], i);
        }

        decimal totalPrice = UpdateTotalPrice();
        decimal remainingAmount =
            totalPrice - (visit.PaidAmount + visit.DiscountAmount);

        txtRemainingAmount.Text = remainingAmount.ToString();
    }

    private void AssignViewToRowCells(VisitTreatmentsView view, int currentRowIndex)
    {
        // ToothNumber
        ((DataGridViewComboBoxCell)dataGridView.Rows[currentRowIndex]
            .Cells[nameof(colToothNumber)]).Value = (view.ToothNumber.ToString());

        // TreatmentName
        ((DataGridViewComboBoxCell)dataGridView.Rows[currentRowIndex]
            .Cells[nameof(colTreatmentName)]).Value = view.Name;

        // Price
        ((DataGridViewTextBoxCell)dataGridView.Rows[currentRowIndex]
            .Cells[nameof(colTreatmentPrice)]).Value = view.Price;

        // Notes
        ((DataGridViewTextBoxCell)dataGridView.Rows[currentRowIndex]
            .Cells[nameof(colNotes)]).Value = view.Notes;
    }

    private bool HandelGetVisitToothTreatmentViewResult(
        Result<List<VisitTreatmentsView>> viewResult)
    {
        if (viewResult.IsFailure)
        {
            if (viewResult.Error == ServiceErrors.InvalidId)
            {
                MessageBoxExtensions.ShowError($"رقم الزياره {_visitId} غير صالح");
            }
            else
            {
                MessageBoxExtensions.ShowError("حدث خطأ أثناء تحميل بيانات الزياره.");
            }

            return false;
        }

        return true;
    }

    private bool HandelGetVisitResult(Result<VisitResponseDto> visitResult)
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
            else
            {
                MessageBoxExtensions.ShowError("حدث خطأ اثناء تحميل بيانات الزياره.");
            }

            return false;
        }

        return true;
    }

    private async Task<VisitResponseDto?> LoadVisitUi()
    {
        var visitResult = await _visitService.GetByIdAsync(_visitId);
        if (!HandelGetVisitResult(visitResult))
        {
            Close();
            return null;
        }

        txtAppointmentId.Text = visitResult.Value.AppointmentId?.ToString() ?? string.Empty;
        txtPatientName.Text = visitResult.Value.PatientName?.ToString() ?? string.Empty;
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
                .Value?
                .ToString() ?? null;

        if (string.IsNullOrWhiteSpace(selectedTreatmentName))
            return;

        var selectedTreatmentPrice =
            _treatments.FirstOrDefault(t => t.Name == selectedTreatmentName)
                ?.Price;

        if (!selectedTreatmentPrice.HasValue)
            return;

        dataGridView.Rows[e.RowIndex].Cells[nameof(colTreatmentPrice)].Value =
            selectedTreatmentPrice.ToString();
    }

    private string? SelectedTreatmentName
    {
        get
        {
            if (_selectedRowIndex < 0 || _selectedRowIndex >= dataGridView.Rows.Count)
                return null;

            return dataGridView.Rows[_selectedRowIndex]
                .Cells[nameof(colTreatmentName)]
                .Value?.ToString();
        }
    }

    private int? SelectedTreatmentId
    {
        get
        {
            var selectedTreatmentName = SelectedTreatmentName;

            if (string.IsNullOrWhiteSpace(selectedTreatmentName))
                return null;

            return _treatments
                .Where(t => t.Name == selectedTreatmentName)
                .FirstOrDefault()?.Id;
        }
    }

    private decimal? GetTreatmentPriceFromGrid(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= dataGridView.Rows.Count)
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

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!Validate())
            return;

        if (!MakeSure())
            return;

        VisitRequestDto? visitDto = GetVisitDtoFromUi();
        if (visitDto is null)
            return;

        if (_mode == Mode.Add)
            await CreateVisitAndTreatmentsAsync(visitDto);
        else
            await UpdateVisitAndTreatmentsAsync(visitDto);
    }

    private async Task CreateVisitAndTreatmentsAsync(VisitRequestDto visitDto)
    {
        var addVisitResult = await _visitService.CreateAsync(visitDto);
        if (addVisitResult.IsFailure)
        {
            HandelCreateAndUpdateVisitResult(addVisitResult.Error);
            return;
        }

        var visitTreatments = GetVisitTreatmentsFromUi(addVisitResult.Value);
        if (visitTreatments is null)
            return;

        var addVisitTreatmentsResult =
            await _visitTreatmentService.CreateManyAsync(visitTreatments.ToArray());
        if (addVisitTreatmentsResult.IsFailure)
        {
            HandelCreateUpdateVisitTreatmentsResult(addVisitTreatmentsResult.Error);
            return;
        }

        if (MessageBox.Show(
            "تم حفظ بيانات الزياره بنجاح. هل تود تسجيل الوصفه الطبيه؟", "تم الحفظ",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            using var frm = _formFactory.Create_frmAddEditPrescription(addVisitResult.Value);
            Hide();
            await frm.ShowDialogAsync();
            Close();
        }
        else
        {
            Close();
        }
    }

    private async Task UpdateVisitAndTreatmentsAsync(VisitRequestDto visitDto)
    {
        var updateVisitResult = await _visitService.UpdateAsync(_visitId, visitDto);
        if (updateVisitResult.IsFailure)
        {
            HandelCreateAndUpdateVisitResult(updateVisitResult.Error);
            return;
        }

        var visitTreatments = GetVisitTreatmentsFromUi(_visitId);
        if (visitTreatments is null)
            return;

        var updateVisitTreatmentsResult =
            await _visitTreatmentService.SetAllVisitTreatmentsAsync(
                _visitId, visitTreatments.ToArray());

        if (updateVisitTreatmentsResult.IsFailure)
        {
            HandelCreateUpdateVisitTreatmentsResult(updateVisitTreatmentsResult.Error);
            return;
        }

        MessageBox.Show(
            "تم تعديل بيانات الزياره بنجاح.", "تم التعديل",
            MessageBoxButtons.OK, MessageBoxIcon.Information);

        Close();
    }

    private void HandelCreateUpdateVisitTreatmentsResult(Error addVisitTreatmentsResult)
    {
        switch (addVisitTreatmentsResult.Code)
        {
            case "Treatment.DuplicateTreatmentForTheSameTooth":
                MessageBoxExtensions.ShowError("لا يمكن ان يتم تقديم نفس الخدمه اكثر من مره لنفس السن.");
                break;

            case "Notes.TooLong":
                MessageBoxExtensions.ShowError("ملاحظات الخدمه طويله جدا.");
                break;

            default:
                MessageBoxExtensions.ShowError("بيانات غير صحيحه.");
                break;
        }
    }

    private void HandelCreateAndUpdateVisitResult(Error addVisitResultError)
    {
        switch (addVisitResultError.Code)
        {
            case "Notes.TooLong":
                MessageBoxExtensions.ShowError("ملاحظات الزياره طويله جدا");
                break;

            case "PatientName.TooLong":
                MessageBoxExtensions.ShowError($"اسم المريض طويل جدا.");
                break;

            case "Appointment.NotFound":
                MessageBoxExtensions.ShowError("رقم الحجز غير موجود.");
                break;

            case "Visit.DuplicatedAppointmentId":
            case "AppointmentStatus.CannotBeCompletedWhenAlreadyCompleted":
                MessageBoxExtensions.ShowError("رقم الحجز مستخدم في زياره اخري.");
                break;

            case "Status.CannotBeCompletedWhenCanceled":
                MessageBoxExtensions.ShowError("تم الغاء الحجز صاحب الرقم المُعطي.");
                break;

            default:
                MessageBoxExtensions.ShowError("بيانات غير صحيحه.");
                break;
        }
    }

    private List<VisitTreatmentRequestDto>? GetVisitTreatmentsFromUi(int visitId)
    {
        List<VisitTreatmentRequestDto> visitTreatments = [];
        int rowsCount = dataGridView.Rows.Count;
        int newRowIndex = dataGridView.NewRowIndex;

        for (int i = 0; i < rowsCount; i++)
        {
            if (i == newRowIndex)
                continue;

            var visitTreatment = GetVisitTreatmentFromUi(i, visitId);

            if (visitTreatment is null)
                return null;

            visitTreatments.Add(visitTreatment);
        }

        return visitTreatments;
    }

    private VisitTreatmentRequestDto? GetVisitTreatmentFromUi(int rowIndex, int visitId)
    {
        var toothNumber = GetToothNumberFromDataGrid(rowIndex);
        if (!toothNumber.HasValue)
        {
            MessageBoxExtensions.ShowError("هناك رقم سن غير صالح.");
            return null;
        }

        var treatmentId = GetTreatmentIdFromDataGrid(rowIndex);
        if (!treatmentId.HasValue)
        {
            MessageBoxExtensions.ShowError("هناك اسم خدمه غير صالح.");
            return null;
        }

        return new VisitTreatmentRequestDto
        {
            ToothNumber = toothNumber.Value,
            TreatmentId = treatmentId.Value,
            VisitId = visitId,
            Notes = GetTreatmentNotesFromDataGrid(rowIndex)
        };
    }

    private string? GetTreatmentNotesFromDataGrid(int rowIndex)
    {
        if (rowIndex < 0
            || rowIndex >= dataGridView.Rows.Count
            || rowIndex == dataGridView.NewRowIndex)
            return null;

        var cellValue = dataGridView.Rows[rowIndex].Cells[nameof(colNotes)].Value;

        if (cellValue is null)
            return null;

        return cellValue as string;
    }

    private int? GetTreatmentIdFromDataGrid(int rowIndex)
    {
        if (rowIndex < 0
            || rowIndex >= dataGridView.Rows.Count
            || rowIndex == dataGridView.NewRowIndex)
            return null;

        var cellValue = dataGridView.Rows[rowIndex].Cells[nameof(colTreatmentName)].Value;

        if (cellValue is null)
            return null;

        var stringCellValue = cellValue as string;

        int? treatmentId = _treatments
                            .FirstOrDefault(t => t.Name == stringCellValue)?.Id;

        if (treatmentId is null)
            return null;

        return treatmentId;
    }

    private byte? GetToothNumberFromDataGrid(int rowIndex)
    {
        if (rowIndex < 0
            || rowIndex >= dataGridView.Rows.Count
            || rowIndex == dataGridView.NewRowIndex)
            return null;

        var cellValue = dataGridView.Rows[rowIndex].Cells[nameof(colToothNumber)].Value;

        if (cellValue is null)
            return null;

        if (byte.TryParse(cellValue.ToString(), out var toothNumber))
            return toothNumber;

        return null;
    }

    private VisitRequestDto? GetVisitDtoFromUi()
    {
        var paidAmount = GetPaidAmountFromTextbox();
        if (!paidAmount.HasValue)
        {
            MessageBoxExtensions.ShowError("القيمه المدفوعه غير صالحه.");
            return null;
        }

        return new VisitRequestDto
        {
            AppointmentId = GetAppointmentIdFromUi(),
            PatientName = txtPatientName.Text,
            PaidAmount = paidAmount.Value, // Validated before, shouldn't be null.
            DiscountAmount = GetDiscountPriceFromTextbox() ?? 0,
            VisitDateTime = dateTimePicker.Value,
            Notes = txtNotes.Text,
        };
    }

    private int? GetAppointmentIdFromUi()
    {
        if (int.TryParse(txtAppointmentId.Text, out int appointmentId))
            return appointmentId;

        return null;
    }

    private bool MakeSure()
    {
        string message = _mode == Mode.Add ?
            "هل انت متأكد من تسجيل الزيارة؟" : "هل انت متأكد من تعديل الزيارة؟";

        if (MessageBoxExtensions.ShowQuestion(
                message, "تأكيد") == DialogResult.No)
        {
            return false;
        }

        return true;
    }

    private new bool Validate()
    {
        if (!ValidateTextboxes())
            return false;

        if (!ValidateDataGrid())
            return false;

        return true;
    }

    private bool ValidateDataGrid()
    {
        if (!ValidateColumnCellsValues(nameof(colToothNumber), "يرجي اختيار رقم السن"))
            return false;

        if (!ValidateColumnCellsValues(nameof(colTreatmentName), "يرجي اختيار الخدمه المقدمه"))
            return false;

        if (!ValidateToothTreatmentsDuplication())
            return false;

        if (!ValidateGridRowValues())
            return false;

        return true;
    }

    private bool ValidateGridRowValues()
    {
        int rowsCount = dataGridView.Rows.Count;
        int newRowIndex = dataGridView.NewRowIndex;

        for (int i = 0; i < rowsCount; i++)
        {
            if (i == newRowIndex)
                continue;

            if (GetToothNumberFromDataGrid(i) is null)
            {
                MessageBoxExtensions.ShowWarning($"هناك رقم سن غير صالح في الصف رقم {i + 1}.", "تنبيه");
                return false;
            }

            if (GetTreatmentIdFromDataGrid(i) is null)
            {
                MessageBoxExtensions.ShowWarning($"هناك اسم خدمه غير صالح في الصف رقم {i + 1}.", "تنبيه");
                return false;
            }
        }

        return true;
    }

    private bool ValidateToothTreatmentsDuplication()
    {
        var seen = new HashSet<(int ToothNumber, string TreatmentName)>();

        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            // Ignore the new row at the bottom.
            if (row.IsNewRow)
                continue;

            if (row.Cells[nameof(colToothNumber)].Value is null ||
                row.Cells[nameof(colTreatmentName)].Value is null)
            {
                continue;
            }

            int toothNumber = Convert.ToInt32(row.Cells[nameof(colToothNumber)].Value);
            string treatmentName = Convert.ToString(row.Cells[nameof(colTreatmentName)].Value)!;

            if (!seen.Add((toothNumber, treatmentName)))
            {
                MessageBoxExtensions.ShowError(
                    $"لا يمكن اضافة '{treatmentName}' للسن رقم {toothNumber} اكثر من مره.");
                return false;
            }
        }

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

    private bool ValidateTextboxes()
    {
        // ========================== Appointment Id ==========================
        if (string.IsNullOrWhiteSpace(txtAppointmentId.Text))
        {
            // Do Nothing
            // This condition exists to do not check the next condition
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

        // ========================== Remaining Amount ==========================
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

        // ========================== Appointment Date Time ==========================
        if (dateTimePicker.Value > DateTime.Now)
        {
            MessageBoxExtensions.ShowError("تاريخ الزياره لا يمكن ان يكون في المستقبل.");
            return false;
        }

        return true;
    }

    private void InitializeDataGridDefaultValues()
    {
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

        // Second Row Height
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
        if (_selectedRowIndex < 0 || _selectedRowIndex >= dataGridView.Rows.Count)
            e.Cancel = true;
    }

    private void cmsDelete_Click(object sender, EventArgs e)
    {
        DeleteRow(_selectedRowIndex);
    }

    private bool DeleteRow(int index)
    {
        if (index < 0 || index >= dataGridView.Rows.Count)
            return false;

        if (dataGridView.Rows.Count is 1)
        {
            MessageBox.Show("يجب ان يكون هناك صف واحد علي الأقل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        if (!dataGridView.Rows[index].IsNewRow)
        {
            dataGridView.Rows.RemoveAt(index);

            if (_selectedRowIndex == index)
                _selectedRowIndex = -1;

            return true;
        }
        else
        {
            MessageBox.Show("لا يمكن حذف الصف الفارغ. هذا الصف غير مؤثر يمكنك تجاهله.", "خطأ", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        return false;
    }

    private async void cmsEdit_Click(object sender, EventArgs e)
    {
        int? selectedTreatmentId = SelectedTreatmentId;

        if (selectedTreatmentId.HasValue)
        {
            using var frm = _formFactory.Create_frmAddEditTreatment(selectedTreatmentId.Value);

            await frm.ShowDialogAsync();
            await InitializeAsync(); // Update the form
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
        if (decimal.TryParse(txtPaidAmount.Text, out decimal decimalValue))
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

    private void timer_Tick(object sender, EventArgs e)
    {
        dateTimePicker.MaxDate = DateTime.Now;
    }

    private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        _logger.LogWarning(
            e.Exception,
            "DataGridView data error at row {RowIndex}, column {ColumnIndex}",
            e.RowIndex, e.ColumnIndex);

        e.ThrowException = false;
    }
}