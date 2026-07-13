using System.Globalization;

namespace Dental.WinForms.Helpers;

public static class DateTimeHelper
{
    private static readonly CultureInfo ArabicCulture = new("ar-EG");

    public static string GetArabicDate(DateTime datetime)
    {
        return datetime.ToString("dddd dd/MM/yyyy", ArabicCulture);
    }

    public static string GetArabicTime(DateTime datetime)
    {
        return datetime.ToString("hh:mm tt", ArabicCulture);
    }

    public static string GetArabicDateTime(DateTime datetime)
    {
        return $"{GetArabicDate(datetime)} {GetArabicTime(datetime)}";
    }
}