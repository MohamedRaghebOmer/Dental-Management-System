using Dental.Domain.Enums;

namespace Dental.WinForms.Helpers;

public static class MaterialStatusHelper
{
    public static string ToString(MaterialStatus status)
    {
        return status switch
        {
            MaterialStatus.Available => "متوفر",
            MaterialStatus.LowStock => "منخفض",
            MaterialStatus.OutOfStock => "نفد",
            _ => throw new ArgumentException("Invalid material status.", nameof(status))
        };
    }

    public static MaterialStatus FromString(string status)
    {
        return status switch
        {
            "متوفر" => MaterialStatus.Available,
            "منخفض" => MaterialStatus.LowStock,
            "نفد" => MaterialStatus.OutOfStock,
            _ => throw new ArgumentException("Invalid material status string.", nameof(status))
        };
    }
}