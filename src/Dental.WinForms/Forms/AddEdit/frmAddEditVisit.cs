using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Treatment;
using Dental.Application.DTOs.Visit;
using Dental.Application.DTOs.VisitPayment;
using Dental.Application.DTOs.VisitTreatments;
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

public partial class frmAddEditVisit : Form
{
    private readonly ITreatmentService _treatmentService;
    private readonly ILogger<frmAddEditVisit> _logger;
    private readonly IVisitPaymentService _visitPaymentService;
    private readonly IVisitService _visitService;
    private readonly IVisitTreatmentService _visitTreatmentService;
    private readonly IVisitTreatmentsViewService _visitTreatmentsViewService;
    private readonly IFormFactory _formFactory;

    private readonly int? _visitId = null;
    private int _treatmentsSelectedRowIndex = -1;
    private int _paymentsSelectedRowIndex = -1;
    private List<TreatmentResponseDto> _treatments = [];
    private HashSet<int> _loadedVisitPaymentsIds = [];

    public enum Mode { Add, Update }
    private readonly Mode _mode = Mode.Add;

    public enum VisitType { WalkIn, PreAppointment }
    private readonly VisitType? _visitType = null;


    private frmAddEditVisit(
        ITreatmentService treatmentService,
        IVisitService visitService,
        IVisitTreatmentService visitToothTreatmentService,
        IVisitTreatmentsViewService visitTreatmentsViewService,
        ILogger<frmAddEditVisit> logger,
        IAppointmentInfoService appointmentInfoService,
        IPatientService patientService,
        IPatientViewService patientViewService,
        IVisitPaymentService visitPaymentService,
        IFormFactory formFactory)
    {
        InitializeComponent();

        _treatmentService = treatmentService;
        _visitService = visitService;
        _visitTreatmentService = visitToothTreatmentService;
        _visitTreatmentsViewService = visitTreatmentsViewService;
        _logger = logger;
        _visitPaymentService = visitPaymentService;
        _formFactory = formFactory;
        _mode = Mode.Add;
        _visitId = null;

        dgvVisitPayments.AlternatingRowsDefaultCellStyle = null;
        dgvVisitTreatments.AlternatingRowsDefaultCellStyle = null;

        ctrlSearchAppointment1.Initialize(formFactory, appointmentInfoService);
        ctrlSearchPatient1.Initialize(patientViewService, patientService, formFactory);

        ctrlSearchAppointment1.AppointmentSelected += CtrlSearchAppointment1_AppointmentSelected;
        ctrlSearchPatient1.PatientSelected += CtrlSearchPatient1_PatientSelected;

        CancelButton = btnClose;

        InitializeFormTexts();
    }

    public frmAddEditVisit(
        VisitType visitType,
        ITreatmentService treatmentService,
        IVisitService visitService,
        IVisitTreatmentService visitToothTreatmentService,
        IVisitTreatmentsViewService visitTreatmentsViewService,
        ILogger<frmAddEditVisit> logger,
        IAppointmentInfoService appointmentInfoService,
        IPatientService patientService,
        IPatientViewService patientViewService,
        IVisitPaymentService visitPaymentService,
        IFormFactory formFactory) : this(
            treatmentService,
            visitService,
            visitToothTreatmentService,
            visitTreatmentsViewService,
            logger,
            appointmentInfoService,
            patientService,
            patientViewService,
            visitPaymentService,
            formFactory)
    {
        _mode = Mode.Add;
        _visitId = null;
        _visitType = visitType;

        InitializeFormTexts();
    }

    public frmAddEditVisit(
        int visitId,
        ITreatmentService treatmentService,
        IVisitService visitService,
        IVisitTreatmentService visitToothTreatmentService,
        IVisitTreatmentsViewService visitTreatmentsViewService,
        ILogger<frmAddEditVisit> logger,
        IAppointmentInfoService appointmentInfoService,
        IPatientService patientService,
        IPatientViewService patientViewService,
        IVisitPaymentService visitPaymentService,
        IFormFactory formFactory) : this(
            treatmentService,
            visitService,
            visitToothTreatmentService,
            visitTreatmentsViewService,
            logger,
            appointmentInfoService,
            patientService,
            patientViewService,
            visitPaymentService,
            formFactory)
    {
        _mode = Mode.Update;
        _visitId = visitId;
        _visitType = null;

        InitializeFormTexts();
    }


    private void CtrlSearchPatient1_PatientSelected(object? sender, Application.DTOs.Patient.PatientResponseDto e)
    {
        txtId.Text = e.Id.ToString();
        txtId.FillColor = Color.Red;
        change_txtId_FillColorTimer.Start();
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
        txtId.FillColor = Color.Red;
        change_txtId_FillColorTimer.Start();
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
            await LoadDataGrid();

            if (_mode == Mode.Add)
            {
                InitializeDataGridDefaultValues();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex, "Error occurred while initializing visit data. Error Occurred in {ClassName}", nameof(frmAddEditVisit));

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
        if (!await LoadVisitUi())
        {
            Close();
            return;
        }

        await LoadVisitToothTreatmentsUi();

        if (dgvVisitTreatments.Rows.Count - 1 > 0)
            dgvVisitTreatments.Rows[1].Height = 35;
    }

    private async Task LoadVisitToothTreatmentsUi()
    {
        if (_mode != Mode.Update || !_visitId.HasValue)
            return;

        var viewResult = await _visitTreatmentsViewService.GetAsync(_visitId.Value);
        if (!HandleGetVisitToothTreatmentViewResult(viewResult))
            return;

        // Clear the gird first
        dgvVisitTreatments.Rows.Clear();

        var viewsCount = viewResult.Value.Count;
        if (viewsCount > 0)
        {
            // Fill the grid with empty rows same as views count
            dgvVisitTreatments.Rows.Add(viewsCount);
        }

        for (int i = 0; i < viewsCount; i++)
        {
            AssignViewToRowCells(viewResult.Value[i], i);
        }

        var discountAmount = GetDiscountPriceFromTextbox();
        if (!discountAmount.HasValue)
            return;

        var totalPaidAmount = GetSumOfPaidAmountsFromPaymentsGrid();
        if (!totalPaidAmount.HasValue)
            return;

        decimal totalPrice = UpdateTotalPrice();
        decimal remainingAmount =
            totalPrice - (totalPaidAmount.Value + discountAmount.Value);

        txtRemainingAmount.Text = remainingAmount.ToString("F2");
    }

    private decimal? GetSumOfPaidAmountsFromPaymentsGrid()
    {
        decimal sum = 0;
        var newRowIndex = dgvVisitPayments.NewRowIndex;

        for (int i = 0; i < dgvVisitPayments.Rows.Count; i++)
        {
            if (i == newRowIndex)
                continue;

            var cellValue = dgvVisitPayments.Rows[i]
                .Cells[nameof(col_Payments_PaidAmount)].Value;

            if (!decimal.TryParse(cellValue?.ToString(), out var value))
                return null;

            sum += value;
        }

        return sum;
    }

    private void AssignViewToRowCells(VisitTreatmentsView view, int currentRowIndex)
    {
        // ToothNumber
        ((DataGridViewComboBoxCell)dgvVisitTreatments.Rows[currentRowIndex]
            .Cells[nameof(colToothNumber)]).Value = (view.ToothNumber.ToString());

        // TreatmentName
        ((DataGridViewComboBoxCell)dgvVisitTreatments.Rows[currentRowIndex]
            .Cells[nameof(colTreatmentName)]).Value = view.Name;

        // TreatmentPrice
        ((DataGridViewTextBoxCell)dgvVisitTreatments.Rows[currentRowIndex]
            .Cells[nameof(colTreatmentPrice)]).Value = view.Price;

        // Notes
        ((DataGridViewTextBoxCell)dgvVisitTreatments.Rows[currentRowIndex]
            .Cells[nameof(colNotes)]).Value = view.Notes;
    }

    private bool HandleGetVisitToothTreatmentViewResult(
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
                MessageBoxExtensions.ShowError("حدث خطأ أثناء تحميل بيانات الزياره. "
                    + viewResult.Error.Message);
            }

            return false;
        }

        return true;
    }

    private bool HandleGetVisitResult(Result<VisitResponseDto> visitResult)
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
                MessageBoxExtensions.ShowError(
                    "حدث خطأ اثناء تحميل بيانات الزياره." + visitResult.Error.Message);
            }

            return false;
        }

        return true;
    }

    private async Task<bool> LoadVisitUi()
    {
        if (_mode != Mode.Update || !_visitId.HasValue)
            return false;

        var visitResult = await _visitService.GetByIdAsync(_visitId.Value);
        if (!HandleGetVisitResult(visitResult))
        {
            Close();
            return false;
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

        txtDiscountAmount.Text = visitResult.Value.DiscountAmount.ToString("F2");
        lblVisitDateTime.Text =
            DateTimeHelper.GetArabicDateTime(visitResult.Value.VisitDateTime);
        txtNotes.Text = visitResult.Value.Notes ?? string.Empty;

        return await LoadVisitPaymentsGridAsync();
    }

    private async Task<bool> LoadVisitPaymentsGridAsync()
    {
        if (_mode != Mode.Update || !_visitId.HasValue)
            return false;

        var paymentsResult =
            await _visitService.GetPaymentsByVisitIdAsync(_visitId.Value);
        if (paymentsResult.IsFailure)
            return false;

        // Clear the grid rows first
        dgvVisitPayments.Rows.Clear();

        // Add empty rows same as the dtos count
        var dtosCount = paymentsResult.Value.Count;
        if (dtosCount > 0)
            dgvVisitPayments.Rows.Add(dtosCount);

        for (int i = 0; i < dtosCount; i++)
        {
            dgvVisitPayments.Rows[i].Cells[nameof(col_Payments_VisitPaymentId)].Value =
                paymentsResult.Value[i].VisitPaymentId;

            dgvVisitPayments.Rows[i].Cells[nameof(col_Payments_VisitId)].Value =
                paymentsResult.Value[i].VisitId;

            dgvVisitPayments.Rows[i].Cells[nameof(col_Payments_PaidAmount)].Value =
                paymentsResult.Value[i].PaidAmount;

            dgvVisitPayments.Rows[i].Cells[nameof(col_Payments_OldPaidAmount)].Value =
                paymentsResult.Value[i].PaidAmount;

            dgvVisitPayments.Rows[i].Cells[nameof(col_Payments_PaymentDateTime)].Value =
                DateTimeHelper.GetArabicDateTime(paymentsResult.Value[i].PaymentDateTime);

            dgvVisitPayments.Rows[i]
                .Cells[nameof(col_Payments_ConvertablePaymentDateTime)]
                .Value = paymentsResult.Value[i].PaymentDateTime.ToString("O");
        }

        _loadedVisitPaymentsIds = paymentsResult.Value
            .Select(p => p.VisitPaymentId)
            .ToHashSet();

        return true;
    }

    private void DataGridViewCellValueChanged(
        object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == dgvVisitTreatments.Columns[nameof(colTreatmentName)]?.Index
            && e.RowIndex >= 0
            && e.RowIndex < dgvVisitTreatments.Rows.Count)
        {
            AssignPriceToSelectedTreatment(e);
            UpdateTotalPrice();
        }
    }

    private decimal UpdateTotalPrice()
    {
        int rowsCount = dgvVisitTreatments.Rows.Count;
        decimal sum = 0;

        for (int i = 0; i < rowsCount; i++)
        {
            decimal? rowTreatmentPrice = GetTreatmentPriceFromGrid(i);

            if (rowTreatmentPrice.HasValue)
                sum += rowTreatmentPrice.Value;
        }

        lblTotalPrice.Text = sum.ToString("F2");
        return sum;
    }

    private void AssignPriceToSelectedTreatment(
        DataGridViewCellEventArgs e)
    {
        var selectedTreatmentName = dgvVisitTreatments.Rows[e.RowIndex]
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

        dgvVisitTreatments.Rows[e.RowIndex].Cells[nameof(colTreatmentPrice)].Value =
            selectedTreatmentPrice.Value.ToString("F2");
    }

    private string? SelectedTreatmentName
    {
        get
        {
            if (_treatmentsSelectedRowIndex < 0 || _treatmentsSelectedRowIndex >= dgvVisitTreatments.Rows.Count)
                return null;

            return dgvVisitTreatments.Rows[_treatmentsSelectedRowIndex]
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
        if (rowIndex < 0 || rowIndex >= dgvVisitTreatments.Rows.Count)
            return null;


        var cellValue = dgvVisitTreatments.Rows[rowIndex]
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
            HandleCreateAndUpdateVisitResult(addVisitResult.Error);
            return false;
        }

        var visitTreatments = GetVisitTreatmentsFromUi(addVisitResult.Value);
        if (visitTreatments is null)
            return false;

        var addVisitTreatmentsResult =
            await _visitTreatmentService.CreateManyAsync(visitTreatments.ToArray());
        if (addVisitTreatmentsResult.IsFailure)
        {
            HandleCreateUpdateVisitTreatmentsResult(addVisitTreatmentsResult.Error);
            return false;
        }

        if (!await AddPaymentsAsync(addVisitResult.Value))
            return false;

        var want = MessageBoxExtensions.ShowQuestion(
            "تم حفظ بيانات الزياره بنجاح، هل تود إضافة الأشعه؟", "تم الحفظ");

        if (want == DialogResult.Yes)
        {
            Hide();

            using var frm = _formFactory.Create_frmAddEditVisitRadioghraph();
            frm.VisitId = addVisitResult.Value;
            await frm.ShowDialogAsync();
        }

        return true;
    }

    private PreAppointmentVisitDto? GetPreAppointmentVisitDtoFromUi()
    {
        var appointmentId = Get_txtId_ValueFromUi();
        if (!appointmentId.HasValue)
            return null;

        var discountAmount = GetDiscountPriceFromTextbox();
        if (!discountAmount.HasValue)
            discountAmount = 0;

        return new PreAppointmentVisitDto
        {
            AppointmentId = appointmentId.Value,
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
            HandleCreateAndUpdateVisitResult(addVisitResult.Error);
            return false;
        }

        var visitTreatments =
            GetVisitTreatmentsFromUi(addVisitResult.Value);
        if (visitTreatments is null)
            return false;

        var addVisitTreatmentsResult =
            await _visitTreatmentService.CreateManyAsync(visitTreatments.ToArray());
        if (addVisitTreatmentsResult.IsFailure)
        {
            HandleCreateUpdateVisitTreatmentsResult(addVisitTreatmentsResult.Error);
            return false;
        }

        if (!await AddPaymentsAsync(addVisitResult.Value))
            return false;

        var want = MessageBoxExtensions.ShowQuestion(
            "تم حفظ بيانات الزياره بنجاح، هل تود إضافة الأشعه؟", "تم الحفظ");

        if (want == DialogResult.Yes)
        {
            Hide();

            using var frm = _formFactory.Create_frmAddEditVisitRadioghraph();
            frm.VisitId = addVisitResult.Value;
            await frm.ShowDialogAsync();
        }

        return true;
    }

    private async Task<bool> AddPaymentsAsync(int visitId)
    {
        var dtos = GetAllPaymentsDtosFromGrid(visitId);
        if (dtos is null)
            return false;

        var addResult = await _visitPaymentService.CreateMenyAsync(dtos);
        if (addResult.IsFailure)
        {
            HandleCreateAndUpdatePaymentResult(addResult.Error);
            return false;
        }

        return true;
    }

    private List<CreateVisitPaymentDto>? GetAllPaymentsDtosFromGrid(int visitId)
    {
        var rowsCount = dgvVisitPayments.Rows.Count;
        var newRowIndex = dgvVisitPayments.NewRowIndex;
        List<CreateVisitPaymentDto> dtos = [];

        for (int i = 0; i < rowsCount; i++)
        {
            if (i == newRowIndex)
                continue;

            var paidAmount = GetPaidAmountFromPaymentsGrid(i);
            if (!paidAmount.HasValue)
            {
                MessageBoxExtensions.ShowQuestion(
                    $"يرجى إدخال مبلغ أكبر من الصفر في الصف رقم {i + 1} أو حذف الصف.");
                return null;
            }

            dtos.Add(new CreateVisitPaymentDto
            {
                VisitId = visitId,
                PaidAmount = paidAmount.Value
            });
        }

        return dtos;
    }

    private WalkInVisitDto? GetWalkInVisitDtoFromUi()
    {
        var patientId = Get_txtId_ValueFromUi();
        if (!patientId.HasValue)
            return null;

        var discountAmount = GetDiscountPriceFromTextbox();
        if (!discountAmount.HasValue)
            discountAmount = 0;

        return new WalkInVisitDto
        {
            PatientId = patientId.Value,
            DiscountAmount = discountAmount.Value,
            Notes = txtNotes.Text
        };
    }

    private async Task<bool> UpdateVisitAndTreatmentsAsync()
    {
        if (_mode != Mode.Update || !_visitId.HasValue)
            return false;

        var updateDto = GetUpdateVisitDtoFromUi();
        if (updateDto is null)
            return false;

        var visitTreatments = GetVisitTreatmentsFromUi(_visitId.Value);
        if (visitTreatments is null)
            return false;

        var updateVisitResult = await _visitService.UpdateAsync(_visitId.Value, updateDto);
        if (updateVisitResult.IsFailure)
        {
            HandleCreateAndUpdateVisitResult(updateVisitResult.Error);
            return false;
        }

        var updateVisitTreatmentsResult =
            await _visitTreatmentService.SetAllVisitTreatmentsAsync(
                _visitId.Value, visitTreatments.ToArray());

        if (updateVisitTreatmentsResult.IsFailure)
        {
            HandleCreateUpdateVisitTreatmentsResult(updateVisitTreatmentsResult.Error);
            return false;
        }

        if (!await UpdatePaymentsAsync())
            return false;

        MessageBoxExtensions.ShowInfo(
            "تم تعديل بيانات الزياره بنجاح.", "تم التعديل");

        return true;
    }

    private async Task<bool> UpdatePaymentsAsync()
    {
        if (_mode != Mode.Update || _visitId is not > 0)
            return false;

        var updateDtos = GetUpdatePaymentsDtosFromUi();
        if (updateDtos is null)
            return false;

        var updateResult = await _visitPaymentService.UpdateManyAsync(updateDtos);
        if (updateResult.IsFailure)
        {
            HandleCreateAndUpdatePaymentResult(updateResult.Error);
            return false;
        }

        var addDtos = GetAddPaymentsDtosFromUi(_visitId.Value);
        if (addDtos is null)
            return false;

        var addResult = await _visitPaymentService.CreateMenyAsync(addDtos);
        if (addResult.IsFailure)
        {
            HandleCreateAndUpdatePaymentResult(addResult.Error);
            return false;
        }

        var deleteDtos = GetDeletePaymentsIdsFromUi();
        if (deleteDtos.Count > 0)
        {
            var deleteResult = await _visitPaymentService.DeleteManyAsync(deleteDtos);
            if (deleteResult.IsFailure)
            {
                HandleCreateAndUpdatePaymentResult(deleteResult.Error);
                return false;
            }
        }

        return true;
    }

    private HashSet<int> GetDeletePaymentsIdsFromUi()
    {
        var deleteIds = new HashSet<int>();

        foreach (var loadedPaymentId in _loadedVisitPaymentsIds)
        {
            if (!IsPaymentIdExistsInTheGrid(loadedPaymentId))
                deleteIds.Add(loadedPaymentId);
        }

        return deleteIds;
    }

    private bool IsPaymentIdExistsInTheGrid(int id)
    {
        var rowsCount = dgvVisitPayments.Rows.Count;
        var newRowIndex = dgvVisitPayments.NewRowIndex;

        for (int i = 0; i < rowsCount; i++)
        {
            if (i == newRowIndex)
                continue;

            var cellValue = dgvVisitPayments.Rows[i]
                .Cells[nameof(col_Payments_VisitPaymentId)].Value;


            if (int.TryParse(cellValue?.ToString(), out var cellId) && cellId == id)
                return true;
        }

        return false;
    }

    private List<CreateVisitPaymentDto>? GetAddPaymentsDtosFromUi(int visitId)
    {
        int rowsCount = dgvVisitPayments.Rows.Count;
        int newRowIndex = dgvVisitPayments.NewRowIndex;
        List<CreateVisitPaymentDto> dtos = [];

        for (int i = 0; i < rowsCount; i++)
        {
            if (i == newRowIndex)
                continue;

            // If the 'VisitPaymentId' has value, then the payment should be updated not added
            if (GetVisitPaymentIdFromPaymentsGrid(i).HasValue)
                continue;

            var paidAmount = GetPaidAmountFromPaymentsGrid(i);
            if (!paidAmount.HasValue)
            {
                MessageBoxExtensions.ShowQuestion(
                    $"يرجى إدخال مبلغ أكبر من الصفر في الصف رقم {i + 1}");
                return null;
            }

            dtos.Add(new CreateVisitPaymentDto
            {
                VisitId = visitId,
                PaidAmount = paidAmount.Value
            });
        }

        return dtos;
    }

    private static void HandleCreateAndUpdatePaymentResult(Error updateResultError)
    {
        switch (updateResultError.Code)
        {
            case "NotFound":
                MessageBoxExtensions.ShowError("الزياره غير موجوده.");
                break;

            case "VisitPayment.NotFound":
                MessageBoxExtensions.ShowError("المعامله غير موجوده.");
                break;

            default:
                MessageBoxExtensions.ShowError(
                    $"حدث خطأ اثناء تحديث بيانات الزياره. {updateResultError.ToString()}");
                break;
        }
    }

    private List<UpdateVisitPaymentDto>? GetUpdatePaymentsDtosFromUi()
    {
        if (_mode != Mode.Update || _visitId is not > 0)
            return null;

        List<UpdateVisitPaymentDto> dtos = [];
        int rowsCount = dgvVisitPayments.Rows.Count;
        var newRowIndex = dgvVisitPayments.NewRowIndex;

        for (int i = 0; i < rowsCount; i++)
        {
            if (i == newRowIndex)
                continue;

            // Old paid amount is null when the payment is newly added by the user
            // and it's null when it's already exists in the DB
            var oldPaidAmount = GetOldPaidAmountFromPaymentsGrid(i);
            if (oldPaidAmount is not > 0)
                continue;

            var visitPaymentId = GetVisitPaymentIdFromPaymentsGrid(i);
            if (visitPaymentId is not > 0)
                continue;

            var paidAmount = GetPaidAmountFromPaymentsGrid(i);
            if (paidAmount is not > 0)
            {
                MessageBoxExtensions.ShowWarning(
                    $"يرجى إدخال مبلغ أكبر من الصفر في الصف رقم {i + 1} أو حذف الصف.");
                return null;
            }

            // No need to udpate the payment when it's paid amount did not changed
            if (paidAmount == oldPaidAmount.Value)
                continue;

            dtos.Add(new UpdateVisitPaymentDto
            {
                VisitPaymentId = visitPaymentId.Value,
                VisitId = _visitId.Value,
                PaidAmount = paidAmount.Value
            });
        }

        return dtos;
    }

    private int? GetVisitPaymentIdFromPaymentsGrid(int rowIndex)
    {
        var cellValue = dgvVisitPayments.Rows[rowIndex]
            .Cells[nameof(col_Payments_VisitPaymentId)]
            .Value;

        if (int.TryParse(cellValue?.ToString(), out var id))
            return id;

        return null;
    }

    private decimal? GetOldPaidAmountFromPaymentsGrid(int i)
    {
        if (i < 0 || i >= dgvVisitPayments.Rows.Count)
            return null;

        var cellValue = dgvVisitPayments.Rows[i]
            .Cells[nameof(col_Payments_OldPaidAmount)]
            .Value;

        if (decimal.TryParse(cellValue?.ToString(), out var amount))
            return amount;

        return null;
    }

    private decimal? GetPaidAmountFromPaymentsGrid(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex >= dgvVisitPayments.Rows.Count)
            return null;

        var cellValue = dgvVisitPayments.Rows[rowIndex]
            .Cells[nameof(col_Payments_PaidAmount)]
            .Value;

        if (decimal.TryParse(cellValue?.ToString(), out var amount))
            return amount;

        return null;
    }

    private UpdateVisitDto? GetUpdateVisitDtoFromUi()
    {
        var discountAmount = GetDiscountPriceFromTextbox();
        if (!discountAmount.HasValue)
            discountAmount = 0;

        return new UpdateVisitDto
        {
            DiscountAmount = discountAmount.Value,
            Notes = txtNotes.Text
        };
    }

    private static void HandleCreateUpdateVisitTreatmentsResult(Error addVisitTreatmentsResult)
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

    private void HandleCreateAndUpdateVisitResult(Error addVisitResultError)
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
                MessageBoxExtensions.ShowError($"الحجز رقم {txtId.Text} مستخدم في زياره اخري.");
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
        int rowsCount = dgvVisitTreatments.Rows.Count;
        int newRowIndex = dgvVisitTreatments.NewRowIndex;

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
            || rowIndex >= dgvVisitTreatments.Rows.Count
            || rowIndex == dgvVisitTreatments.NewRowIndex)
            return null;

        var cellValue = dgvVisitTreatments.Rows[rowIndex].Cells[nameof(colNotes)].Value;

        if (cellValue is null)
            return null;

        return cellValue as string;
    }

    private int? GetTreatmentIdFromDataGrid(int rowIndex)
    {
        if (rowIndex < 0
            || rowIndex >= dgvVisitTreatments.Rows.Count
            || rowIndex == dgvVisitTreatments.NewRowIndex)
            return null;

        var cellValue = dgvVisitTreatments.Rows[rowIndex].Cells[nameof(colTreatmentName)].Value;

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
            || rowIndex >= dgvVisitTreatments.Rows.Count
            || rowIndex == dgvVisitTreatments.NewRowIndex)
            return null;

        var cellValue = dgvVisitTreatments.Rows[rowIndex].Cells[nameof(colToothNumber)].Value;

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

        if (!ValidateDataGrids())
            return false;

        return true;
    }

    private bool ValidateDataGrids()
    {
        if (!ValidatePaymentsGrid())
            return false;

        if (!ValidateColumnCellsValues(
                nameof(colToothNumber), "يرجي اختيار رقم السن"))
            return false;

        if (!ValidateColumnCellsValues(
            nameof(colTreatmentName), "يرجي اختيار الخدمه المقدمه"))
            return false;

        if (!ValidateToothTreatmentsDuplication())
            return false;

        if (!ValidateTreatmentsGridRowsValues())
            return false;

        return true;
    }

    private bool ValidatePaymentsGrid()
    {
        int rowsCount = dgvVisitPayments.Rows.Count;
        int newRowIndex = dgvVisitPayments.NewRowIndex;
        for (int i = 0; i < rowsCount; i++)
        {
            if (i == newRowIndex)
                continue;

            var cellValue = dgvVisitPayments.Rows[i]
                .Cells[nameof(col_Payments_PaidAmount)]
                .Value;

            if (!decimal.TryParse(cellValue?.ToString(), out _))
            {
                MessageBoxExtensions.ShowWarning(
                    $"يرجي إدخال مبلغ صالح في جدول المدفوعات الصف رقم {i + 1}");
                return false;
            }
        }

        return true;
    }

    private bool ValidateTreatmentsGridRowsValues()
    {
        int rowsCount = dgvVisitTreatments.Rows.Count;
        int newRowIndex = dgvVisitTreatments.NewRowIndex;

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

        foreach (DataGridViewRow row in dgvVisitTreatments.Rows)
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
        int cellsCount = dgvVisitTreatments.Rows.Count;
        int newRowIndex = dgvVisitTreatments.NewRowIndex;

        for (int i = 0; i < cellsCount; i++)
        {
            if (i != newRowIndex)
            {
                var cellValue = dgvVisitTreatments.Rows[i].Cells[columnName].Value;
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
                    "رقم المريض مطلوب." :
                    "رقم الحجز مطلوب.";

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

        if (GetTotalPriceFromLabel() is null or < 0)
        {
            MessageBoxExtensions.ShowWarning("المبلغ الكلي لا يجب ان يكون قيمه سالبه.");
            return false;
        }


        // ========================== Discount Amount ==========================
        if (string.IsNullOrWhiteSpace(txtDiscountAmount.Text))
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
            MessageBoxExtensions.ShowError(
                "إجمالي المبالغ المدفوعة لا يمكن أن يكون أكبر من المبلغ الكلي.");
            return false;
        }

        return true;
    }

    private void InitializeDataGridDefaultValues()
    {
        dgvVisitTreatments.Rows.Add();

        // Add 1 as a default value for ToothNumber
        ((DataGridViewComboBoxCell)(dgvVisitTreatments.Rows[0].Cells[nameof(colToothNumber)]))
            .Value = "1";

        // Add First Value of treatments names as a default value
        ((DataGridViewComboBoxCell)(dgvVisitTreatments.Rows[0].Cells[nameof(colTreatmentName)]))
            .Value = _treatments.FirstOrDefault()?.Name ?? string.Empty;

        // Add First value of treatments prices as a default value
        var firstValuePrice = _treatments.FirstOrDefault()?.Price;
        ((DataGridViewTextBoxCell)(dgvVisitTreatments.Rows[0].Cells[nameof(colTreatmentPrice)])).Value =
            firstValuePrice == null ? string.Empty : firstValuePrice?.ToString("F2");

        // Set the current only price to the lblPrice
        lblTotalPrice.Text = firstValuePrice?.ToString("F2");

        // Second Row Height
        if (dgvVisitTreatments.Rows.Count > 1)
            dgvVisitTreatments.Rows[1].Height = 35;

        if (dgvVisitPayments.Rows.Count > 0)
            dgvVisitPayments.Rows[0].Height = 35;
    }

    private void dataGridView_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hit = dgvVisitTreatments.HitTest(e.X, e.Y);
            if (hit.RowIndex >= 0 && hit.RowIndex < dgvVisitTreatments.Rows.Count)
            {
                _treatmentsSelectedRowIndex = hit.RowIndex;
                dgvVisitTreatments.ClearSelection();
                dgvVisitTreatments.Rows[_treatmentsSelectedRowIndex].Selected = true;
            }
            else
                _treatmentsSelectedRowIndex = -1;
        }
    }

    private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
    {
        if (_treatmentsSelectedRowIndex < 0
            || _treatmentsSelectedRowIndex >= dgvVisitTreatments.Rows.Count)
        {
            e.Cancel = true;
            return;
        }


        if (dgvVisitTreatments.Rows[_treatmentsSelectedRowIndex].IsNewRow)
            tsmiTreatmentsDelete.Enabled = false;
        else
            tsmiTreatmentsDelete.Enabled = true;
    }

    private void cmsDelete_Click(object sender, EventArgs e)
    {
        DeleteRow(_treatmentsSelectedRowIndex);
    }

    private bool DeleteRow(int index)
    {
        if (index < 0 || index >= dgvVisitTreatments.Rows.Count)
            return false;

        if (!dgvVisitTreatments.Rows[index].IsNewRow)
        {
            dgvVisitTreatments.Rows.RemoveAt(index);

            if (_treatmentsSelectedRowIndex == index)
                _treatmentsSelectedRowIndex = -1;

            return true;
        }

        MessageBoxExtensions.ShowError("لا يمكن حذف الصف الفارغ. هذا الصف غير مؤثر يمكنك تجاهله.", "خطأ");

        return false;
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
        decimal paidAmount = GetSumOfPaidAmountsFromPaymentsGrid() ?? 0;
        decimal discountAmount = GetDiscountPriceFromTextbox() ?? 0;

        decimal remainingAmount = totalAmount - (paidAmount + discountAmount);

        txtRemainingAmount.Text = remainingAmount.ToString("F2");
        lblSumOfPaidAmounts.Text = paidAmount.ToString("F2");
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

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void dgvVisitPayments_CellValueChanged(
        object sender, DataGridViewCellEventArgs e)
    {
        if (dgvVisitPayments.Columns[nameof(col_Payments_PaidAmount)]?.Index == e.ColumnIndex
            && e.RowIndex >= 0
            && e.RowIndex < dgvVisitPayments.Rows.Count)
        {
            var amountCellValue = dgvVisitPayments.Rows[e.RowIndex]
                .Cells[e.ColumnIndex].Value;

            if (amountCellValue is null)
                return;

            if (!decimal.TryParse(amountCellValue?.ToString(), out var enteredValue)
                || enteredValue <= 0)
            {
                MessageBoxExtensions.ShowError("يرجى إدخال مبلغ صالح.");
                dgvVisitPayments.Rows[e.RowIndex]
                    .Cells[e.ColumnIndex].Value = null;

                return;
            }

            txtMoney_TextChanged(null!, null!);

            var dateCellValue = dgvVisitPayments.Rows[e.RowIndex]
                .Cells[nameof(col_Payments_PaymentDateTime)]
                .Value;

            if (dateCellValue is null)
                dgvVisitPayments.Rows[e.RowIndex]
                    .Cells[nameof(col_Payments_PaymentDateTime)]
                    .Value = DateTimeHelper.GetArabicDateTime(DateTime.Now);
        }
    }

    private void tsmiPaymentsDelete_Click(object sender, EventArgs e)
    {
        if (_paymentsSelectedRowIndex < 0
            || _paymentsSelectedRowIndex >= dgvVisitPayments.Rows.Count
            || dgvVisitPayments.Rows[_paymentsSelectedRowIndex].IsNewRow)
            return;

        dgvVisitPayments.Rows.RemoveAt(_paymentsSelectedRowIndex);
    }

    private void cmsPaymentsGrid_Opening(object sender, CancelEventArgs e)
    {
        if (_paymentsSelectedRowIndex < 0
            || _paymentsSelectedRowIndex >= dgvVisitPayments.Rows.Count)
        {
            e.Cancel = true;
            return;
        }

        if (dgvVisitPayments.Rows[_paymentsSelectedRowIndex].IsNewRow)
            tsmiPaymentsDelete.Enabled = false;
        else
            tsmiPaymentsDelete.Enabled = true;
    }

    private void dgvVisitPayments_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            var hit = dgvVisitPayments.HitTest(e.X, e.Y);
            if (hit.RowIndex >= 0 && hit.RowIndex < dgvVisitPayments.Rows.Count)
            {
                _paymentsSelectedRowIndex = hit.RowIndex;
                dgvVisitPayments.ClearSelection();
                dgvVisitPayments.Rows[_paymentsSelectedRowIndex].Selected = true;
            }
            else
                _paymentsSelectedRowIndex = -1;
        }
    }

    private void dgvVisitTreatments_RowsRemoved(
        object sender, DataGridViewRowsRemovedEventArgs e)
    {
        UpdateTotalPrice();
    }

    private void dgvVisitPayments_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
        txtMoney_TextChanged(sender, e);
    }

    private void change_txtId_FillColorTimer_Tick(object sender, EventArgs e)
    {
        change_txtId_FillColorTimer.Stop();
        txtId.FillColor = Color.White;
    }
}