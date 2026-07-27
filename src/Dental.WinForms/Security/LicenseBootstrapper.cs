using Dental.Licensing.Core;
using System.Security.Cryptography;

namespace Dental.WinForms.Security;

internal static class LicenseBootstrapper
{
    public static bool IsActivated(out string error)
    {
        error = string.Empty;

        if (!LicenseStorage.TryLoad(out string licenseKey))
        {
            error = "License file not found.";
            return false;
        }

        return ValidateLicense(licenseKey, saveIfValid: false, out error);
    }

    public static bool Activate(string licenseKey, out string error)
    {
        return ValidateLicense(licenseKey, saveIfValid: true, out error);
    }

    private static bool ValidateLicense(string licenseKey, bool saveIfValid, out string error)
    {
        error = string.Empty;

        using RSA rsa = RSA.Create();
        rsa.ImportFromPem(AppKeys.PublicKeyPem);

        string fingerprint = FingerprintService.GetFingerprint();

        if (!LicenseCrypto.TryReadLicenseKey(
                licenseKey,
                rsa,
                fingerprint,
                out LicensePayload? payload,
                out error))
        {
            return false;
        }

        if (payload == null)
        {
            error = "License payload is missing.";
            return false;
        }

        if (saveIfValid)
        {
            LicenseStorage.Save(licenseKey);
        }

        return true;
    }
}