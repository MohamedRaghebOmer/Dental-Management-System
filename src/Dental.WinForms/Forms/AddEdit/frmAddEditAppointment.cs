using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Appointment;
using Dental.Domain.Enums;
using Dental.Domain.Shared;
using Dental.WinForms.Extensions;
using System.Reflection.Emit;

namespace Dental.WinForms.Forms;

public partial class frmAddEditAppointment : Form
{
    private readonly IAppointmentService _appointmentService;
    private readonly int? _appointmentId = null;

    public event EventHandler<int>? AppointmentAdded;

    public enum Mode { Add, Update }
    private readonly Mode _mode = Mode.Add;


    public frmAddEditAppointment(IAppointmentService appointmentService)
    {
        InitializeComponent();

        _appointmentService = appointmentService;

        _mode = Mode.Add;
        _appointmentId = null;
    }

    public frmAddEditAppointment(
        int appointmentId,
        Mode mode,
        IAppointmentService appointmentService)
    {
        InitializeComponent();

        _appointmentService = appointmentService;
        _mode = mode;

        if (_mode == Mode.Add)
        {
            txtPatientId.Text = appointmentId.ToString();
            return;
        }

        _appointmentId = appointmentId;
    }


    private async void frmAddAppointment_Load(object sender, EventArgs e)
    {
        AppointmentResponseDto? appointment = null;

        if (_mode == Mode.Update)
        {
            appointment = await ValidateUpdateAppointment();
            if (appointment is null)
            {
                Close();
                return;
            }
                
        }

        InitializeForm();

        if (_mode == Mode.Update)
            LoadAppointmentInfo(appointment!);
    }

    private void LoadAppointmentInfo(AppointmentResponseDto appointment)
    {
        txtPatientId.Text = appointment.PatientId.ToString();
        dtpVisitDate.Value = appointment.ScheduledVisitDateTime.Date;
        dtpVisitTime.Value = appointment.ScheduledVisitDateTime;
        txtNotes.Text = appointment.Notes;
    }

    private async Task<AppointmentResponseDto?> ValidateUpdateAppointment()
    {
        if (_mode != Mode.Update || !_appointmentId.HasValue)
            return null;

        Cursor = Cursors.WaitCursor;
        var appointmentStatusResult = await _appointmentService.GetByIdAsync(_appointmentId.Value);
        Cursor = Cursors.Default;

        if (appointmentStatusResult.IsFailure)
        {
            HandleGetAppointmentStatusError(appointmentStatusResult.Error);
            return null;
        }

        if (appointmentStatusResult.Value.Status 
            is AppointmentStatus.Canceled or AppointmentStatus.Completed)
        {
            MessageBoxExtensions.ShowWarning("لا يمكن تعديل بيانات الحجز لأنه ليس في حالة الإنتظار.");
            return null;
        }

        return appointmentStatusResult.Value;
    }

    private static void HandleGetAppointmentStatusError(Error error)
    {
        if (error.Code == "NotFound")
        {
            MessageBoxExtensions.ShowError("الموعد غير موجود. يرجى التحقق من الرقم وإعادة المحاولة.");
        }
        else
        {
            MessageBoxExtensions.ShowError($"حدث خطأ أثناء جلب حالة الحجز: {error.Message}");
        }
    }

    private void InitializeForm()
    {
        dtpVisitDate.Value = DateTime.Now;
        dtpVisitDate.Format = DateTimePickerFormat.Custom;
        dtpVisitDate.CustomFormat = "MM/dd/yyyy dddd";

        lblTitile.Text = _mode == Mode.Add ? "إضافة موعد جديد" : "تعديل موعد";
        Text = _mode == Mode.Add ? "إضافة موعد جديد" : "تعديل موعد";
    }

    private void txtPatientId_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (!ValidateToSave())
            return;

        var appointmentDto = GetAppointmentDtoFromUi();
        if (appointmentDto is null)
            return;

        Cursor = Cursors.WaitCursor;
        if (_mode == Mode.Add)
        {
            var saveResult = await _appointmentService.CreateAsync(appointmentDto);
            if (saveResult.IsFailure)
                HandleSaveResult(saveResult.Error);
            else
            {
                MessageBoxExtensions.ShowInfo("تم حفظ الموعد بنجاح.");
                OnAppointmentAdded(saveResult.Value);
                Close();
            }
        }
        else // Mode.Update
        {
            if (!_appointmentId.HasValue)
            {
                MessageBoxExtensions.ShowError("رقم الموعد غير صالح.");
                return;
            }

            var saveResult = 
                await _appointmentService.UpdateAsync(_appointmentId.Value, appointmentDto);
            if (saveResult.IsFailure)
                HandleSaveResult(saveResult.Error);
            else
            {
                MessageBoxExtensions.ShowInfo("تم حفظ الموعد بنجاح.");
                Close();
            }
        }
        Cursor = Cursors.Default;
    }

    private void HandleSaveResult(Error saveResultError)
    {
        switch (saveResultError.Code)
        {
            case "Id.LessThanOrEqualToZero":
                MessageBoxExtensions.ShowError("رقم المريض يجب أن يكون أكبر من صفر.");
                txtPatientId.Focus();
                break;

            case "InvalidId":
                MessageBoxExtensions.ShowError("رقم الحجز غير صالح. يرجى التحقق من الرقم وإعادة المحاولة.");
                break;

            case "NotFound":
                MessageBoxExtensions.ShowError("الموعد غير موجود. يرجى التحقق من الرقم وإعادة المحاولة.");
                break;

            case "Date.CannotBeChangedWhenStatusIsNotPendingOrMissed":
            case "PatientId.CannotBeChangedWhenStatusIsNotPendingOrMissed":
                MessageBoxExtensions.ShowError("لا يمكن تعديل بيانات الحجز لأنه ليس في حالة الإنتظار. \nتم ربط الحجز بزياره او تم الغاء الحجز."); 
                break;

            case "Appointment.PatientNotFound":
                MessageBoxExtensions.ShowError("المريض غير موجود. يرجى التحقق من رقم المريض.");
                txtPatientId.Focus();
                break;

            case "Date.InThePast":
                MessageBoxExtensions.ShowError("تاريخ الموعد غير صالح. يرجى اختيار تاريخ في المستقبل.");
                dtpVisitDate.Focus();
                break;
            
            case "Notes.TooLong":
                MessageBoxExtensions.ShowError("الملاحظات طويلة جدًا. يرجى تقليل طول الملاحظات.");
                txtNotes.Focus();
                break;

            default:
                MessageBoxExtensions.ShowError($"حدث خطأ أثناء حفظ الموعد: {saveResultError.Message}");
                break;
        }
    }   

    private AppointmentRequestDto? GetAppointmentDtoFromUi()
    {
        if (!int.TryParse(txtPatientId.Text.Trim(), out int patientId))
        {
            MessageBoxExtensions.ShowError("رقم المريض غير صالح.");
            return null;
        }

        var appointmentDto = new AppointmentRequestDto
        {
            PatientId = patientId,
            ScheduledVisitDateTime = GetScheduledVisitDateTime(),
            Notes = txtNotes.Text,
        };

        return appointmentDto;
    }

    private DateTime GetScheduledVisitDateTime()
    {
        var date = dtpVisitDate.Value.Date;
        var time = dtpVisitTime.Value;

        return new DateTime(
            date.Year,
            date.Month,
            date.Day,
            time.Hour,
            time.Minute,
            0);
    }

    private bool ValidateToSave()
    {
        string patientId = txtPatientId.Text.Trim();

        if (string.IsNullOrWhiteSpace(patientId))
        {
            MessageBox.Show("من فضلك أدخل رقم المريض.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPatientId.Focus();
            return false;
        }

        if (!int.TryParse(patientId, out int patientIdValue) || patientIdValue <= 0)
        {
            MessageBox.Show("رقم المريض يجب أن يكون رقمًا صحيحًا أكبر من صفر.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPatientId.Focus();
            return false;
        }

        var visitDateTime = GetScheduledVisitDateTime();

        if (visitDateTime < DateTime.Now)
        {
            MessageBox.Show("تاريخ الموعد يجب أن يكون في المستقبل.", "خطأ في التحقق", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dtpVisitDate.Focus();
            return false;
        }

        return true;
    }

    protected virtual void OnAppointmentAdded(int appointmentId)
    {
        AppointmentAdded?.Invoke(this, appointmentId);
    }
}