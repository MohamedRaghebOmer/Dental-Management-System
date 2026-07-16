namespace Dental.Infrastructure.Constants;

public static class DataStoragePaths
{
    public static readonly string BasePath =
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "Dental Clinic");

    public static readonly string DatabaseFolderPath = Path.Combine(
        BasePath,
        "Database");

    public static readonly string DatabaseFilePath = Path.Combine(
        BasePath,
        "Database",
        "Dental.db");

    public static readonly string LogsFolderPath = Path.Combine(
        BasePath,
        "Logs");
}