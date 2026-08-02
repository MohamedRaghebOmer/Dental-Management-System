using Microsoft.Win32;
using System.Management;
using System.Runtime.Versioning;
using System.Security.Cryptography;
using System.Text;

namespace Dental.Licensing.Core;

public static class FingerprintService
{
    [SupportedOSPlatform("windows")]
    public static string GetFingerprint()
    {
        string machineGuid = ReadMachineGuid();
        string biosSerial = ReadWmiValue("Win32_BIOS", "SerialNumber");
        string boardSerial = ReadWmiValue("Win32_BaseBoard", "SerialNumber");
        string cpuId = ReadWmiValue("Win32_Processor", "ProcessorId");

        string raw = string.Join("|",
            Normalize(machineGuid),
            Normalize(biosSerial),
            Normalize(boardSerial),
            Normalize(cpuId));

        if (string.IsNullOrWhiteSpace(raw.Replace("|", "")))
        {
            raw = Environment.MachineName + "|" + Environment.OSVersion.VersionString;
        }

        byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(raw));
        return Convert.ToHexString(hash);
    }

    private static string Normalize(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim().ToUpperInvariant();
    }

    [SupportedOSPlatform("windows")]
    private static string ReadMachineGuid()
    {
        try
        {
            using RegistryKey? key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography");
            object? value = key?.GetValue("MachineGuid");
            return value?.ToString() ?? string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }

    [SupportedOSPlatform("windows")]
    private static string ReadWmiValue(string wmiClass, string propertyName)
    {
        try
        {
            using ManagementObjectSearcher searcher =
                new ManagementObjectSearcher($"SELECT {propertyName} FROM {wmiClass}");

            foreach (ManagementObject obj in searcher.Get())
            {
                object? value = obj[propertyName];
                if (value != null)
                {
                    return value.ToString() ?? string.Empty;
                }
            }
        }
        catch
        {
        }

        return string.Empty;
    }
}