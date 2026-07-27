namespace Dental.Licensing.Core;

public sealed class LicensePayload
{
    public string ProductId { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string Fingerprint { get; set; } = string.Empty;
    public DateTime IssuedAtUtc { get; set; }
    public DateTime? ExpiresAtUtc { get; set; } // null = lifetime
}