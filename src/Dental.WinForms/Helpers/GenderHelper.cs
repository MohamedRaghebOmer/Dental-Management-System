using Dental.Domain.Enums;

namespace Dental.WinForms.Helpers;

public static class GenderHelper
{
    public static string GenderToString(Gender gender)
    {
        return gender == Gender.Male ? "ذكر" : "أنثى";
    }

    public static Gender GenderFromString(string genderString)
    {
        return genderString == "ذكر" ? Gender.Male : Gender.Female;
    }
}