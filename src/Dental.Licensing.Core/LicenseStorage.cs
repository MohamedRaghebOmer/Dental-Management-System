using System.Security.Cryptography;
using System.Text;

namespace Dental.Licensing.Core;

public static class LicenseStorage
{
    private static readonly string FolderPath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
            "DentalProtection");

    private static readonly string FilePath = Path.Combine(FolderPath, "license.dat");

    public static void Save(string licenseKey)
    {
        Directory.CreateDirectory(FolderPath);

        byte[] rawBytes = Encoding.UTF8.GetBytes(licenseKey);
        byte[] protectedBytes = ProtectedData.Protect(
            rawBytes,
            null,
            DataProtectionScope.LocalMachine);

        File.WriteAllBytes(FilePath, protectedBytes);
    }

    public static bool TryLoad(out string licenseKey)
    {
        licenseKey = string.Empty;

        if (!File.Exists(FilePath))
        {
            return false;
        }

        try
        {
            byte[] protectedBytes = File.ReadAllBytes(FilePath);
            byte[] rawBytes = ProtectedData.Unprotect(
                protectedBytes,
                null,
                DataProtectionScope.LocalMachine);

            licenseKey = Encoding.UTF8.GetString(rawBytes);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static void Delete()
    {
        if (File.Exists(FilePath))
        {
            File.Delete(FilePath);
        }
    }
}