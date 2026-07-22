using Dental.Application.ViewsStuff.Interfaces;
using Dental.Domain.Enums;
using Dental.Domain.Views;
using Dental.WinForms.Extensions;
using Dental.WinForms.Helpers;

namespace Dental.WinForms.UserControls.Info;

public partial class ctrlAppointmentInfo : UserControl
{
    private int _appointmentId = -1;
    private IAppointmentInfoService _appointmentInfoService;

    public event EventHandler<int>? WhenAppointmentIsNotFound;

    public ctrlAppointmentInfo()
    {
        InitializeComponent();
    }

    public void Initialize(int appointmentId, IAppointmentInfoService appointmentInfoService)
    {
        _appointmentId = appointmentId;
        _appointmentInfoService = appointmentInfoService;
        LoadControl();
    }

    private async void LoadControl()
    {
        var appointmentInfo =
            await _appointmentInfoService.GetAppointmentInfoAsync(_appointmentId);

        if (appointmentInfo.IsFailure)
        {
            MessageBoxExtensions.ShowError($"رقم الحجز {_appointmentId} غير صحيح.");
            return;
        }

        if (appointmentInfo.Value is null)
        {
            MessageBoxExtensions.ShowError($"الحجز رقم {_appointmentId} غير موجود.");
            OnWhenAppointmentIsNotFound(_appointmentId);
            return;
        }

        LoadAppointmentInfoUi(appointmentInfo.Value);
    }

    private void LoadAppointmentInfoUi(AppointmentInfo appointmentInfoValue)
    {
        lblAppointmentId.Text = appointmentInfoValue.Id?.ToString();
        lblPatientId.Text = appointmentInfoValue.PatientId?.ToString();
        lblPatientName.Text = appointmentInfoValue.PatientName?? string.Empty;

        lblCreatedAt.Text = appointmentInfoValue.CreatedAt.HasValue
            ? DateTimeHelper.GetArabicDateTime(appointmentInfoValue.CreatedAt.Value)
            : string.Empty;

        lblScheduledVisitDateTime.Text = appointmentInfoValue.ScheduledVisitDateTime.HasValue
            ? DateTimeHelper.GetArabicDateTime(appointmentInfoValue.ScheduledVisitDateTime.Value)
            : string.Empty;

        lblActualVisitDateTime.Text = appointmentInfoValue.ActualVisitDateTime.HasValue
            ? DateTimeHelper.GetArabicDateTime(appointmentInfoValue.ActualVisitDateTime.Value)
            : "لم يتم الحضور بعد";

        if (appointmentInfoValue.Status is AppointmentStatus.Pending)
        {
            lblAppointmentStatus.Text = "قيد الانتظار";
        }
        else if (appointmentInfoValue.Status is AppointmentStatus.Completed)
        {
            lblAppointmentStatus.Text = "تم الحضور";
        }
        else if (appointmentInfoValue.Status is AppointmentStatus.Canceled)
        {
            lblAppointmentStatus.Text = "ملغي";
        }
        else if (appointmentInfoValue.Status is AppointmentStatus.Missed)
        {
            lblAppointmentStatus.Text = "لم يحضر";
        }

        lblNotes.Text = appointmentInfoValue.Notes ?? string.Empty;
    }

    protected virtual void OnWhenAppointmentIsNotFound(int appointmentId)
    {
        WhenAppointmentIsNotFound?.Invoke(this, appointmentId);
    }
}
