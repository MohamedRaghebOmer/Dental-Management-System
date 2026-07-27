using Dental.Domain.Enums;
using Dental.WinForms.Constants;

namespace Dental.WinForms.Helpers;

public static class AppointmentStatusHelper
{
    public static string AppointmentStatusToString(AppointmentStatus status)
    {
        return status switch
        {
            AppointmentStatus.Pending => UiStrings.AppointmentStatusStrings.Pending,
            AppointmentStatus.Completed => UiStrings.AppointmentStatusStrings.Completed,
            AppointmentStatus.Canceled => UiStrings.AppointmentStatusStrings.Canceled,
            AppointmentStatus.Missed => UiStrings.AppointmentStatusStrings.Missed,
            _ => throw new ArgumentException($"Invalid appointment status: {status}")
        };
    }

    public static AppointmentStatus AppointmentStatusFromString(string statusString)
    {
        return statusString switch
        {
            UiStrings.AppointmentStatusStrings.Pending => AppointmentStatus.Pending,
            UiStrings.AppointmentStatusStrings.Completed => AppointmentStatus.Completed,
            UiStrings.AppointmentStatusStrings.Canceled => AppointmentStatus.Canceled,
            UiStrings.AppointmentStatusStrings.Missed => AppointmentStatus.Missed,
            _ => throw new ArgumentException($"Invalid appointment status string: {statusString}")
        };
    }
}