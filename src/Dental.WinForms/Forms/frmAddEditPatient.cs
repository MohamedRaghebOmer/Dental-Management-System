using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Patient;
using Dental.Domain.Shared;
using Dental.WinForms.Extensions;

namespace Dental.WinForms.Forms;

public partial class frmAddEditPatient : Form
{
    private readonly IPatientService _patientService;
    private readonly int? _patientId = null;

    private enum Mode { Add, Update }
    private Mode _mode = Mode.Add;


    public frmAddEditPatient(IPatientService patientService)
    {
        InitializeComponent();

        _mode = Mode.Add;
        _patientId = null;

        _patientService = patientService;
    }

    public frmAddEditPatient(
        int patientId,
        IPatientService patientService) : this(patientService)
    {
        _mode = Mode.Update;
        _patientId = patientId;
    }


    private async void frmAddEditPatient_Load(object sender, EventArgs e)
    {
        InitializeForm();

        if (_mode == Mode.Update)
        {
            if (!IsValidId())
                return;

            await LoadPatientInfo();
        }
    }

    private void InitializeForm()
    {
        Text = _mode == Mode.Add ? "إضافة مريض جديد" : "تعديل بيانات المريض";
        lblTitile.Text = _mode == Mode.Add ? "إضافة مريض جديد" : "تعديل بيانات المريض";
    }

    private bool IsValidId()
    {
        if (_patientId.HasValue && _patientId.Value <= 0)
        {
            MessageBoxExtensions.ShowError("رقم المريض يجب ان يكون اكبر من الصفر.");
            return false;
        }

        return true;
    }

    private async Task LoadPatientInfo()
    {
        if (!_patientId.HasValue)
            return;

        Cursor = Cursors.WaitCursor;
        var patientResult = await _patientService.GetByIdAsync(_patientId.Value);
        Cursor = Cursors.Default;

        if (patientResult.IsFailure)
        {
            HandelGetPatientError(patientResult.Error);
            return;
        }

        txtFirstName.Text = patientResult.Value.FirstName;
        txtLastName.Text = patientResult.Value.LastName;
        txtAge.Text = patientResult.Value.Age.ToString();
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
    }

    private void HandelGetPatientError(Error error)
    {
        switch (error)
        {
            case "Id.LessThanOrEqualToZero":
                MessageBoxExtensions.ShowError("رقم المريض يجب ان يكون اكبر من الصفر.");
                break;

            case "NotFound":
                MessageBoxExtensions.ShowError($"المريض رقم غير موجود.");
                break;

            default:
                MessageBoxExtensions.ShowError("حدث خطأ اثناء تحميل بيانات المريض.");
                break;
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateToSave())
            return;

        string message = _mode == Mode.Add ? "هل انت متأكد من اضافة المريض؟" : "هل انت متأكد من تعديل بيانات المريض؟";

        if (MessageBoxExtensions.ShowQuestion(
            message, "تأكيد") == DialogResult.No)
            return;

        if (_mode == Mode.Add)
            await AddPatient();
        else
            await UpdatePatient();

        Close();
    }

    private bool ValidateToSave()
    {
        if (string.IsNullOrWhiteSpace(txtFirstName.Text))
        {
            MessageBoxExtensions.ShowError("الإسم الأول مطلوب.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtLastName.Text))
        {
            MessageBoxExtensions.ShowError("الإسم الأخير مطلوب.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtAge.Text))
        {
            MessageBoxExtensions.ShowError("السن مطلوب.");
            return false;
        }

        if (!int.TryParse(txtAge.Text, out _))
        {
            MessageBoxExtensions.ShowError("سن غير صالح.");
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

        if (txtPhoneNumber.Text.Length != 11)
        {
            MessageBoxExtensions.ShowError("رقم الهاتف يجب ان يكون 11 رقم.");
            return false;
        }

        return true;
    }

    private async Task AddPatient()
    {
        PatientRequestDto? patientInfo = GetPatientInfoFromUi();
        if (patientInfo is null)
            return;

        Cursor = Cursors.WaitCursor;
        var saveResult = await _patientService.CreateAsync(patientInfo);
        Cursor = Cursors.Default;

        if (saveResult.IsFailure)
        {
            HandelAddPatientError(saveResult.Error);
            return;
        }

        MessageBoxExtensions.ShowInformation("تم إضافة المريض بنجاح.");
    }

    private void HandelAddPatientError(Error error)
    {
        switch (error.Code)
        {
            case "FirstName.Empty":
                MessageBoxExtensions.ShowError("الإسم الأول مطلوب.");
                break;

            case "FirstName.TooLong":
                MessageBoxExtensions.ShowError("الإسم الأول طويل جدا.");
                break;

            case "LastName.Empty":
                MessageBoxExtensions.ShowError("الإسم الأخير مطلوب.");
                break;

            case "LastName.TooLong":
                MessageBoxExtensions.ShowError("الإسم الأخير طويل جدا.");
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
                MessageBoxExtensions.ShowError("بيانات غير صحيحه.");
                break;
        }
    }

    private async Task UpdatePatient()
    {
        if (!_patientId.HasValue)
            return;

        var patientInfo = GetPatientInfoFromUi();
        if (patientInfo is null)
            return;

        Cursor = Cursors.WaitCursor;
        var saveResult = await _patientService.UpdateAsync(_patientId.Value, patientInfo);
        Cursor = Cursors.Default;

        if (saveResult.IsFailure)
        {
            HandelUpdatePatientError(saveResult.Error);
            return;
        }

        MessageBoxExtensions.ShowInformation("تم تعديل بيانات المريض بنجاح.");
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
        if (!int.TryParse(txtAge.Text, out var age))
            return null;

        return new PatientRequestDto
        {
            FirstName = txtFirstName.Text,
            LastName = txtLastName.Text,
            Age = age,
            Gender = rbMale.Checked ? Domain.Enums.Gender.Male : Domain.Enums.Gender.Female,
            PhoneNumber = txtPhoneNumber.Text
        };
    }

    private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }
}
