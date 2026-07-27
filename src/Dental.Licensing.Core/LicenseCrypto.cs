using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace Dental.Licensing.Core;

public static class LicenseCrypto
{
    private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
    {
        WriteIndented = false,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    public static string CreateLicenseKey(LicensePayload payload, RSA privateKey)
    {
        string payloadJson = JsonSerializer.Serialize(payload, JsonOptions);
        byte[] payloadBytes = Encoding.UTF8.GetBytes(payloadJson);

        byte[] signature = privateKey.SignData(
            payloadBytes,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1);

        string part1 = Base64Url.Encode(payloadBytes);
        string part2 = Base64Url.Encode(signature);

        return part1 + "." + part2;
    }

    public static bool TryReadLicenseKey(
        string licenseKey,
        RSA publicKey,
        string expectedFingerprint,
        out LicensePayload? payload,
        out string error)
    {
        payload = null;
        error = string.Empty;

        if (string.IsNullOrWhiteSpace(licenseKey))
        {
            error = "License key is empty.";
            return false;
        }

        string[] parts = licenseKey.Trim().Split('.');
        if (parts.Length != 2)
        {
            error = "License format is invalid.";
            return false;
        }

        byte[] payloadBytes;
        byte[] signatureBytes;

        try
        {
            payloadBytes = Base64Url.Decode(parts[0]);
            signatureBytes = Base64Url.Decode(parts[1]);
        }
        catch
        {
            error = "License encoding is invalid.";
            return false;
        }

        bool validSignature = publicKey.VerifyData(
            payloadBytes,
            signatureBytes,
            HashAlgorithmName.SHA256,
            RSASignaturePadding.Pkcs1);

        if (!validSignature)
        {
            error = "License signature is invalid.";
            return false;
        }

        string payloadJson = Encoding.UTF8.GetString(payloadBytes);

        try
        {
            payload = JsonSerializer.Deserialize<LicensePayload>(payloadJson, JsonOptions);
        }
        catch
        {
            error = "License payload is invalid.";
            return false;
        }

        if (payload == null)
        {
            error = "License payload is empty.";
            return false;
        }

        if (!string.Equals(payload.Fingerprint, expectedFingerprint, StringComparison.OrdinalIgnoreCase))
        {
            error = "This license is not for this device.";
            return false;
        }

        if (payload.ExpiresAtUtc.HasValue && payload.ExpiresAtUtc.Value < DateTime.UtcNow)
        {
            error = "License expired.";
            return false;
        }

        return true;
    }
}