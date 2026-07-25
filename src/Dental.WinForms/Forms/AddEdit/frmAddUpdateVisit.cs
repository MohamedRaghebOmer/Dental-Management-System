using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Treatment;
using Dental.Application.DTOs.Visit;
using Dental.Application.DTOs.VisitToothNumber;
using Dental.Application.Errors;
using Dental.Application.ViewsStuff.Interfaces.Appointments;
using Dental.Application.ViewsStuff.Interfaces.Patients;
using Dental.Application.ViewsStuff.Interfaces.Visits;
using Dental.Domain.Shared;
using Dental.Domain.Views.Visit;
using Dental.WinForms.Abstractions;
using Dental.WinForms.Extensions;
using Dental.WinForms.Helpers;
using Microsoft.Extensions.Logging;
using System.ComponentModel;

namespace Dental.WinForms.Forms;

public partial class frmAddUpdateVisit : Form
{
    private readonly ITreatmentService _treatmentService;
    private readonly ILogger<frmAddUpdateVisit> _logger;
    private readonly IVisitService _visitService;
    private readonly IVisitTreatmentService _visitTreatmentService;
    private readonly IVisitTreatmentsViewService _visitTreatmentsViewService;
    private readonly IFormFactory _formFactory;

    private readonly int? _visitId = null;
    private int _selectedRowIndex = -1;
    private List<TreatmentResponseDto> _treatments = [];

    public enum Mode { Add, Update }
    private readonly Mode _mode = Mode.Add;

    public enum VisitType { WalkIn, PreAppointment }
    private readonly VisitType? _visitType = null;


    public frmAddUpdateVisit(
        ITreatmentService treatmentService,
        IVisitService visitService,
        IVisitTreatmentService visitToothTreatmentService,
        IVisitTreatmentsViewService visitTreatmentsViewService,
        ILogger<frmAddUpdateVisit> logger,
        IAppointmentInfoService appointmentInfoService,
        IPatientService patientService,
        IPatientViewService patientViewService,
        IFormFactory formFactory)
    {
        InitializeComponent();

        _treatmentService = treatmentService;
        _visitService = visitService;
        _visitTreatmentService = visitToothTreatmentService;
        _visitTreatmentsViewService = visitTreatmentsViewService;
        _logger = logger;
        _formFactory = formFactory;
        _mode = Mode.Add;
        _visitId = null;


        ctrlSearchAppointment1.Initialize(formFactory, appointmentInfoService);
        ctrlSearchPatient1.Initialize(patientViewService, patientService, formFactory);

        ctrlSearchAppointment1.AppointmentSelected += CtrlSearchAppointment1_AppointmentSelected;
        ctrlSearchPatient1.PatientSelected += CtrlSearchPatient1_PatientSelected;
    }

    public frmAddUpdateVisit(
        VisitType visitType,
        ITreatmentService treatmentService,
        IVisitService visitService,
        IVisitTreatmentService visitToothTreatmentService,
        IVisitTreatmentsViewService visitTreatmentsViewService,
        ILogger<frmAddUpdateVisit> logger,
        IAppointmentInfoService appointmentInfoService,
        IPatientService patientService,
        IPatientViewService patientViewService,
        IFormFactory formFactory) : this(
            treatmentService,
            visitService,
            visitToothTreatmentService,
            visitTreatmentsViewService,
            logger,
            appointmentInfoService,
            patientService,
            patientViewService,
            formFactory)
    {
        _mode = Mode.Add;
        _visitId = null;
        _visitType = visitType;
    }

    public frmAddUpdateVisit(
        int visitId,
        ITreatmentService treatmentService,
        IVisitService visitService,
        IVisitTreatmentService visitToothTreatmentService,
        IVisitTreatmentsViewService visitTreatmentsViewService,
        ILogger<frmAddUpdateVisit> logger,
        IAppointmentInfoService appointmentInfoService,
        IPatientService patientService,
        IPatientViewService patientViewService,
        IFormFactory formFactory) : this(
            treatmentService,
            visitService,
            visitToothTreatmentService,
            visitTreatmentsViewService,
            logger,
            appointmentInfoService,
            patientService,
            patientViewService,
            formFactory)
    {
        _mode = Mode.Update;
        _visitId = visitId;
        _visitType = null;
    }


    private void CtrlSearchPatient1_PatientSelected(object? sender, Application.DTOs.Patient.PatientResponseDto e)
    {
        txtId.Text = e.Id.ToString();
    }

    private void CtrlSearchAppointment1_AppointmentSelected(
        object? sender, Domain.Views.Appointment.ShortAppointmentInfo e)
    {
        if (e.Status == Domain.Enums.AppointmentStatus.Completed)
        {
            MessageBoxExtensions.ShowWarning("هذا الحجز مكتمل بالفعل ولا يمكن انشاء زياره له.");
            return;
        }

        if (e.Status == Domain.Enums.AppointmentStatus.Canceled)
        {
            MessageBoxExtensions.ShowWarning("هذا الحجز ملغي ولا يمكن انشاء زياره له.");
            return;
        }

        txtId.Text = e.AppointmentId?.ToString() ?? string.Empty;
    }


    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int? Id
    {
        get
        {
            if (int.TryParse(txtId.Text, out int id))
                return id;

            return null;
        }

        set =>
            txtId.Text = value.HasValue ? value.Value.ToString() : string.Empty;
    }


    private async void AddUpdateVisit_Load(object sender, EventArgs e)
    {
        await InitializeAsync();

        if (_mode == Mode.Update)
        {
            SetUpdateUiMode();
            await LoadUi();
        }

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
        colTreatmentName.DataSource = treatments;

        _treatments = treatments;
    }

    private void InitializeFormTexts()
    {
        Text = _mode == Mode.Add ? "اضافة زياره" : "تعديل زياره";
        lblTitile.Text = _mode == Mode.Add ? "اضافة زياره جديده" : "تعديل بيانات زياره";
        lblVisitDateTime.Text = DateTimeHelper.GetArabicDateTime(DateTime.Now);
        lblId.Text = _visitType == VisitType.WalkIn ? "رقم المريض :" : "رقم الحجز :";

        if (_mode == Mode.Add)
        {
            if (_visitType == VisitType.WalkIn)
            {
                ctrlSearchPatient1.Visible = true;
                ctrlSearchAppointment1.Visible = false;
            }
            else if (_visitType == VisitType.PreAppointment)
            {
                ctrlSearchPatient1.Visible = false;
                ctrlSearchAppointment1.Visible = true;
            }
        }
        else // Mode.Update
        {
            ctrlSearchPatient1.Visible = false;
            ctrlSearchAppointment1.Visible = false;
            btnSearch.Visible = true;
        }
    }

    private void SetUpdateUiMode()
    {
        txtId.Enabled = false;
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
        if (_mode != Mode.Update || !_visitId.HasValue)
            return;

        var viewResult = await _visitTreatmentsViewService.GetAsync(_visitId.Value);
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
            if (viewResult.Error == ServiceErrors.Common.InvalidId)
            {
                MessageBoxExtensions.ShowError($"رقم الزياره غير صالح");
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
            if (visitResult.Error == ServiceErrors.Common.InvalidId)
            {
                MessageBoxExtensions.ShowError("رقم الزياره غير صحيح.");
            }
            else if (visitResult.Error == ServiceErrors.Common.NotFound)
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
        if (!_visitId.HasValue)
            return null;

        var visitResult = await _visitService.GetByIdAsync(_visitId.Value);
        if (!HandelGetVisitResult(visitResult))
        {
            Close();
            return null;
        }

        if (visitResult.Value.AppointmentId.HasValue)
        {
            txtId.Text = visitResult.Value.AppointmentId.Value.ToString();
            lblId.Text = "رقم الحجز :";
        }
        else
        {
            txtId.Text = visitResult.Value.PatientId.ToString();
            lblId.Text = "رقم المريض :";
        }

        txtPaidAmount.Text = visitResult.Value.PaidAmount.ToString();
        txtDiscountAmount.Text = visitResult.Value.DiscountAmount.ToString();
        lblVisitDateTime.Text = DateTimeHelper.GetArabicDateTime(visitResult.Value.VisitDateTime);
        txtNotes.Text = visitResult.Value.Notes ?? string.Empty;

        return visitResult.Value;
    }

    private void DataGridViewCellValueChanged(
        object sender, DataGridViewCellEventArgs e)
    {
        // Only handle the event if the changed cell is in the TreatmentName column
        // and the row index is valid
        if (e is { ColumnIndex: 1, RowIndex: >= 0 } && e.RowIndex < dataGridView.Rows.Count)
        {
            AssignPriceToSelectedTreatment(e);
            UpdateTotalPrice();
        }
    }

    private decimal UpdateTotalPrice()
    {
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
                .FirstOrDefault(t => t.Name == selectedTreatmentName)?.Id;
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

        if (_mode == Mode.Update)
        {
            if (await UpdateVisitAndTreatmentsAsync())
                Close();

            return; // Exist the method whether the update is successful or not.
        }

        if (_visitType == VisitType.WalkIn)
        {
            if (await CreateWalkInVisitAndTreatmentsAsync())
                Close();

            return; // Exist the method whether the creation is successful or not.
        }

        if (await CreatePreAppointmentVisitAndTreatmentsAsync())
            Close();
    }

    private async Task<bool> CreatePreAppointmentVisitAndTreatmentsAsync()
    {
        var preAppointmentVisitDto = GetPreAppointmentVisitDtoFromUi();
        if (preAppointmentVisitDto is null)
            return false;

        var addVisitResult = await _visitService.CreatePreAppointmentVisitAsync(preAppointmentVisitDto);
        if (addVisitResult.IsFailure)
        {
            HandelCreateAndUpdateVisitResult(addVisitResult.Error);
            return false;
        }

        var visitTreatments = GetVisitTreatmentsFromUi(addVisitResult.Value);
        if (visitTreatments is null)
            return false;

        var addVisitTreatmentsResult =
            await _visitTreatmentService.CreateManyAsync(visitTreatments.ToArray());
        if (addVisitTreatmentsResult.IsFailure)
        {
            HandelCreateUpdateVisitTreatmentsResult(addVisitTreatmentsResult.Error);
            return false;
        }

        MessageBoxExtensions.ShowInfo(
            "تم حفظ بيانات الزياره بنجاح.", "تم الحفظ");

        return true;
    }

    private PreAppointmentVisitDto? GetPreAppointmentVisitDtoFromUi()
    {
        var appointmentId = Get_txtId_ValueFromUi();
        if (!appointmentId.HasValue)
            return null;

        var paidAmount = GetPaidAmountFromTextbox();
        if (!paidAmount.HasValue)
            return null;

        var discountAmount = GetDiscountPriceFromTextbox();
        if (!discountAmount.HasValue)
            discountAmount = 0;

        return new PreAppointmentVisitDto
        {
            AppointmentId = appointmentId.Value,
            PaidAmount = paidAmount.Value,
            DiscountAmount = discountAmount.Value,
            Notes = txtNotes.Text
        };
    }

    private async Task<bool> CreateWalkInVisitAndTreatmentsAsync()
    {
        var walkInVisitDto = GetWalkInVisitDtoFromUi();
        if (walkInVisitDto is null)
            return false;

        var addVisitResult = await _visitService.CreateWalkInVisitAsync(walkInVisitDto);
        if (addVisitResult.IsFailure)
        {
            HandelCreateAndUpdateVisitResult(addVisitResult.Error);
            return false;
        }

        var visitTreatments = GetVisitTreatmentsFromUi(addVisitResult.Value);
        if (visitTreatments is null)
            return false;

        var addVisitTreatmentsResult =
            await _visitTreatmentService.CreateManyAsync(visitTreatments.ToArray());
        if (addVisitTreatmentsResult.IsFailure)
        {
            HandelCreateUpdateVisitTreatmentsResult(addVisitTreatmentsResult.Error);
            return false;
        }

        MessageBoxExtensions.ShowInfo(
            "تم حفظ بيانات الزياره بنجاح.", "تم الحفظ");

        return true;
    }

    private WalkInVisitDto? GetWalkInVisitDtoFromUi()
    {
        var patientId = Get_txtId_ValueFromUi();
        if (!patientId.HasValue)
            return null;

        var paidAmount = GetPaidAmountFromTextbox();
        if (!paidAmount.HasValue)
            return null;

        var discountAmount = GetDiscountPriceFromTextbox();
        if (!discountAmount.HasValue)
            discountAmount = 0;

        return new WalkInVisitDto
        {
            PatientId = patientId.Value,
            PaidAmount = paidAmount.Value,
            DiscountAmount = discountAmount.Value,
            Notes = txtNotes.Text
        };
    }

    private async Task<bool> UpdateVisitAndTreatmentsAsync()
    {
        if (!_visitId.HasValue)
            return false;

        var updateDto = GetUpdateVisitDtoFromUi();
        if (updateDto is null)
            return false;

        var updateVisitResult = await _visitService.UpdateAsync(_visitId.Value, updateDto);
        if (updateVisitResult.IsFailure)
        {
            HandelCreateAndUpdateVisitResult(updateVisitResult.Error);
            return false;
        }

        var visitTreatments = GetVisitTreatmentsFromUi(_visitId.Value);
        if (visitTreatments is null)
            return false;

        var updateVisitTreatmentsResult =
            await _visitTreatmentService.SetAllVisitTreatmentsAsync(
                _visitId.Value, visitTreatments.ToArray());

        if (updateVisitTreatmentsResult.IsFailure)
        {
            HandelCreateUpdateVisitTreatmentsResult(updateVisitTreatmentsResult.Error);
            return false;
        }

        MessageBox.Show(
            "تم تعديل بيانات الزياره بنجاح.", "تم التعديل",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        return true;
    }

    private UpdateVisitDto? GetUpdateVisitDtoFromUi()
    {
        var paidAmount = GetPaidAmountFromTextbox();
        if (!paidAmount.HasValue)
            return null;

        var discountAmount = GetDiscountPriceFromTextbox();
        if (!discountAmount.HasValue)
            discountAmount = 0;

        return new UpdateVisitDto
        {
            PaidAmount = paidAmount.Value,
            DiscountAmount = discountAmount.Value,
            Notes = txtNotes.Text
        };
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
            case "Id.LessThanOrEqualToZero":
                MessageBoxExtensions.ShowError("رقم الزياره يجب ان يكون اكبر من صفر.");
                break;

            case "Status.CannotBeCompletedWhenCanceled":
                MessageBoxExtensions.ShowError($"الحجز رقم {txtId.Text} ملغي ولا يمكن انشاء زياره له.");
                break;

            case "Notes.TooLong":
                MessageBoxExtensions.ShowError("ملاحظات الزياره طويله جدا");
                break;

            case "Visit.AppointmentNotFound":
                MessageBoxExtensions.ShowError("رقم الحجز غير موجود.");
                break;

            case "Visit.PatientNotFound":
                MessageBoxExtensions.ShowError("رقم المريض غير موجود.");
                break;

            case "PatientName.TooLong":
                MessageBoxExtensions.ShowError($"اسم المريض طويل جدا.");
                break;

            case "Appointment.NotFound":
                MessageBoxExtensions.ShowError("رقم الحجز غير موجود.");
                break;

            case "Visit.DuplicatedAppointmentId":
            case "Status.CannotBeCompletedWhenAlreadyCompleted":
                MessageBoxExtensions.ShowError("رقم الحجز مستخدم في زياره اخري.");
                break;

            case "Common.UnexpectedError":
                MessageBoxExtensions.ShowError("حدث خطأ غير متوقع اثناء حفظ بيانات الزياره.");
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

    private int? Get_txtId_ValueFromUi()
    {
        if (int.TryParse(txtId.Text, out int appointmentId))
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
        if (string.IsNullOrWhiteSpace(txtId.Text))
        {
            if (_mode == Mode.Add)
            {
                string message = _visitType == VisitType.WalkIn ?
                    "رقم المريض لا يجب ان يكون فارغ." :
                    "رقم الحجز لا يجب ان يكون فارغ.";

                MessageBoxExtensions.ShowError(message);
                return false;
            }
        }
        else if (!int.TryParse(txtId.Text, out int appointmentId))
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

    private void txtId_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            e.Handled = true;
    }

    private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            e.Handled = true;

        if (sender is TextBox textBox)
        {
            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
                e.Handled = true;
        }
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

    private void timer_Tick(object sender, EventArgs e)
    {
        if (_mode == Mode.Add)
        {
            lblVisitDateTime.Text = DateTimeHelper.GetArabicDateTime(DateTime.Now);
        }
    }

    private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        _logger.LogWarning(
            e.Exception,
            "DataGridView data error at row {RowIndex}, column {ColumnIndex}",
            e.RowIndex, e.ColumnIndex);

        e.ThrowException = false;
    }

    private async void btnSearch_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtId.Text, out int id) || id <= 0)
            return;

        if (_mode == Mode.Add)
        {
            if (_visitType == VisitType.WalkIn)
            {
                using var frm = _formFactory.Create_frmAddEditPatient(id);
                await frm.ShowDialogAsync();
            }
            else // PreAppointment
            {
                using var frm = _formFactory.Create_frmAppointmentInfo(id);
                await frm.ShowDialogAsync();
            }
        }
        else // Update
        {
            if (lblId.Text.Contains("حجز") || lblId.Text.Contains("موعد")) // Appointment ID
            {
                using var frm = _formFactory.Create_frmAppointmentInfo(id);
                await frm.ShowDialogAsync();
            }
            else // Patient ID
            {
                using var frm = _formFactory.Create_frmAddEditPatient(id);
                await frm.ShowDialogAsync();
            }
        }
    }

    private void btnAddPatientOrAppointment_Click(object sender, EventArgs e)
    {
        if (_mode != Mode.Add)
            return;

        if (_visitType == VisitType.WalkIn)
        {
            using var frm = _formFactory.Create_frmAddEditPatient();
            frm.PatientAdded += (s, patientId) =>
            {
                txtId.Text = patientId.ToString();
            };

            frm.ShowDialog();
        }
        else // PreAppointment
        {
            using var frm = _formFactory.Create_frmAddEditAppointment();
            frm.AppointmentAdded += (s, appointmentId) =>
            {
                txtId.Text = appointmentId.ToString();
            };
            frm.ShowDialog();
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}