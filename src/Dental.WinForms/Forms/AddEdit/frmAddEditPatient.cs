using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Patient;
using Dental.Domain.Shared;
using Dental.WinForms.Extensions;

namespace Dental.WinForms.Forms;

public partial class frmAddEditPatient : Form
{
    private readonly IPatientService _patientService;
    private readonly int? _patientId = null;

    public event EventHandler<int>? PatientAdded;

    private enum Mode { Add, Update }
    private Mode _mode = Mode.Add;


    public frmAddEditPatient(IPatientService patientService)
    {
        InitializeComponent();

        _mode = Mode.Add;
        _patientId = null;

        _patientService = patientService;

        AcceptButton = btnSave;
        CancelButton = btnClose;

        InitializeForm();
    }

    public frmAddEditPatient(
        int patientId,
        IPatientService patientService) : this(patientService)
    {
        _mode = Mode.Update;
        _patientId = patientId;

        InitializeForm();
    }


    private async void frmAddEditPatient_Load(object sender, EventArgs e)
    {
        if (_mode == Mode.Update)
        {
            if (!IsValidId())
                return;

            if (!await LoadPatientInfo())
                Close();
        }
    }

    private void InitializeForm()
    {
        Text = _mode == Mode.Add ? "إضافة مريض جديد" : "تعديل بيانات المريض";
        lblTitile.Text = _mode == Mode.Add ? "إضافة مريض جديد" : "تعديل بيانات المريض";
        lblPatientId.Visible = _mode == Mode.Update;
        lblPatientIdValue.Visible = _mode == Mode.Update;
    }

    private bool IsValidId()
    {
        if (_patientId is <= 0)
        {
            MessageBoxExtensions.ShowError("رقم المريض يجب ان يكون اكبر من الصفر.");
            return false;
        }

        return true;
    }

    private async Task<bool> LoadPatientInfo()
    {
        if (!_patientId.HasValue)
            return false;

        Cursor = Cursors.WaitCursor;
        var patientResult = await _patientService.GetByIdAsync(_patientId.Value);
        Cursor = Cursors.Default;

        if (patientResult.IsFailure)
        {
            HandelGetPatientError(patientResult.Error);
            return false;
        }

        lblPatientIdValue.Text = patientResult.Value.Id.ToString();
        txtName.Text = patientResult.Value.Name;
        txtAge.Text = patientResult.Value.Age?.ToString()?? string.Empty;
        if (patientResult.Value.Gender == Domain.Enums.Gender.Male)
        {
            rbMale.Checked = true;
            rbFemale.Checked = false;
        }
        else // Female
        {
            rbMale.Checked = false;
            rbFemale.Checked = true;
        }
        txtPhoneNumber.Text = patientResult.Value.PhoneNumber ?? string.Empty;

        return true;
    }

    private void HandelGetPatientError(Error error)
    {
        switch (error)
        {
            case "Id.LessThanOrEqualToZero":
                MessageBoxExtensions.ShowError("رقم المريض يجب ان يكون اكبر من الصفر.");
                break;

            case "NotFound":
                MessageBoxExtensions.ShowError($"المريض رقم {_patientId} غير موجود.");
                break;

            default:
                MessageBoxExtensions.ShowError("حدث خطأ أثناء تحميل بيانات المريض.");
                break;
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateToSave())
            return;

        string message = _mode == Mode.Add ?
            "هل انت متأكد من اضافة المريض؟" 
            : "هل انت متأكد من تعديل بيانات المريض؟";

        if (MessageBoxExtensions.ShowQuestion(
            message, "تأكيد") == DialogResult.No)
            return;

        bool isSuccess = false;

        if (_mode == Mode.Add)
            isSuccess = await AddPatient();
        else
            isSuccess = await UpdatePatientAsync();

        if (isSuccess)
            Close();
    }

    private bool ValidateToSave()
    {
        if (string.IsNullOrWhiteSpace(txtName.Text))
        {
            MessageBoxExtensions.ShowError("الإسم مطلوب.");
            return false;
        }

        if (txtName.Text.Length > 100)
        {
            MessageBoxExtensions.ShowError("الإسم طويل جدا.");
            return false;
        }

        if (!string.IsNullOrWhiteSpace(txtAge.Text)
            && !int.TryParse(txtAge.Text, out _))
        {
            MessageBoxExtensions.ShowError("السن غير صالح.");
            return false;
        }

        foreach (var c in txtPhoneNumber.Text)
        {
            if (!char.IsDigit(c))
            {
                MessageBoxExtensions.ShowError("رقم الهاتف يجب ان يحتوي على ارقام فقط.");
                return false;
            }
        }

        if (!string.IsNullOrWhiteSpace(txtPhoneNumber.Text) && txtPhoneNumber.Text?
            .Trim().Length != 11)
        {
            MessageBoxExtensions.ShowError("رقم الهاتف يجب ان يكون 11 رقم.");
            return false;
        }

        return true;
    }

    private async Task<bool> AddPatient()
    {
        PatientRequestDto? patientInfo = GetPatientInfoFromUi();
        if (patientInfo is null)
            return false;

        Cursor = Cursors.WaitCursor;
        var saveResult = await _patientService.CreateAsync(patientInfo);
        Cursor = Cursors.Default;

        if (saveResult.IsFailure)
        {
            HandelAddPatientError(saveResult.Error);
            return false;
        }

        MessageBoxExtensions.ShowInfo("تم إضافة المريض بنجاح.");
        OnPatientAdded(saveResult.Value);

        return true;
    }

    private void HandelAddPatientError(Error error)
    {
        switch (error.Code)
        {
            case "Patient.DuplicateName":
                MessageBoxExtensions.ShowError("المريض موجود مسبقا.");
                break;

            case "Name.TooLong":
                MessageBoxExtensions.ShowError("الإسم طويل جدا.");
                break;

            case "DateOfBirth.LessThanMinimumAllowedAge":
                MessageBoxExtensions.ShowError($"يجب ان يكون العمر اكبر من {Domain.Entities.Patient.Constants.MinimumAllowedAge} اعوام.");
                break;

            case "DateOfBirth.OlderThanMaximumAllowedAge":
                MessageBoxExtensions.ShowError($"يجب ان يكون العمر اقل من {Domain.Entities.Patient.Constants.MaximumAllowedAge} اعوام.");
                break;

            case "PhoneNumber.InvalidLength":
                MessageBoxExtensions.ShowError($"طول رقم الهاتف يجب ان يكون {Domain.Entities.Patient.Constants.PhoneNumberLength} رقم.");
                break;

            case "Age.LessThanMinimumAllowedAge":
            case "Age.GreaterThanMaximumAllowedAge":
                MessageBoxExtensions.ShowError($"يجب ان يكون السن بين {Domain.Entities.Patient.Constants.MinimumAllowedAge} و {Domain.Entities.Patient.Constants.MaximumAllowedAge}.");
                break;

            default:
                MessageBoxExtensions.ShowError("بيانات غير صحيحه. {0}", error.Code);
                break;
        }
    }

    private async Task<bool> UpdatePatientAsync()
    {
        if (!_patientId.HasValue)
            return false;

        var patientInfo = GetPatientInfoFromUi();
        if (patientInfo is null)
            return false;

        Cursor = Cursors.WaitCursor;
        var saveResult = await _patientService.UpdateAsync(_patientId.Value, patientInfo);
        Cursor = Cursors.Default;

        if (saveResult.IsFailure)
        {
            HandelUpdatePatientError(saveResult.Error);
            return false;
        }

        MessageBoxExtensions.ShowInfo("تم تعديل بيانات المريض بنجاح.");

        return true;
    }

    private void HandelUpdatePatientError(Error error)
    {
        switch (error.Code)
        {
            case "Id.LessThanOrEqualToZero":
                MessageBoxExtensions.ShowError("رقم المريض يجب ان يكون اكبر من الصفر.");
                break;

            case "NotFound":
                MessageBoxExtensions.ShowError("المريض غير موجود.");
                break;
        }

        // Handles the same errors
        HandelAddPatientError(error);
    }

    private PatientRequestDto? GetPatientInfoFromUi()
    {
        var ageString = txtAge.Text.Trim();
        int ageInt = -1;

        if (!string.IsNullOrWhiteSpace(ageString))
        {
            if (!int.TryParse(ageString, out ageInt))
                return null;
        }

        return new PatientRequestDto
        {
            Name = txtName.Text,
            Age = ageInt >= 0 ? ageInt : null,
            Gender = rbMale.Checked ? Domain.Enums.Gender.Male : Domain.Enums.Gender.Female,
            PhoneNumber = txtPhoneNumber.Text.Trim()
        };
    }

    private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    protected virtual void OnPatientAdded(int patientId)
    {
        PatientAdded?.Invoke(this, patientId);
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
