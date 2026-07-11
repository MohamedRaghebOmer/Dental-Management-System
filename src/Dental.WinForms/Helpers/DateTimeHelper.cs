using System.Globalization;

namespace Dental.WinForms.Helpers;

public static class DateHelper
{
    public static string GetArabicDate(DateTime date)
    {
        var culture = new CultureInfo("ar-EG");

        return date.ToString("dd MMMM yyyy", culture);
    }
}