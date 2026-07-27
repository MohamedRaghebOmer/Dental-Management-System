namespace Dental.Licensing.Core;

public static class Base64Url
{
    public static string Encode(byte[] data)
    {
        string text = Convert.ToBase64String(data);
        text = text.Replace("+", "-").Replace("/", "_").TrimEnd('=');
        return text;
    }

    public static byte[] Decode(string text)
    {
        string s = text.Replace("-", "+").Replace("_", "/");

        int mod = s.Length % 4;
        if (mod == 2)
        {
            s += "==";
        }
        else if (mod == 3)
        {
            s += "=";
        }
        else if (mod == 1)
        {
            throw new FormatException("Invalid Base64Url string.");
        }

        return Convert.FromBase64String(s);
    }
}