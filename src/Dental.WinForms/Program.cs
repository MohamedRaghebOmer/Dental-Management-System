using Dental.Application;
using Dental.Infrastructure;
using Dental.Infrastructure.Constants;
using Dental.WinForms.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Dental.WinForms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        try
        {
            ApplicationConfiguration.Initialize();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json",
                    optional: false, reloadOnChange: true)
                .Build();

            var services = new ServiceCollection();
            services
                .AddInfrastructure()
                .AddApplication()
                .AddWinForms()
                .ConfigureSerilog(configuration);

            CreateApplicationDataFolder();

            ServiceProvider provider = services.BuildServiceProvider();
            System.Windows.Forms.Application.Run(provider.GetRequiredService<frmMain>());
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly.");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static void CreateApplicationDataFolder()
    {
        if (!Directory.Exists(DataStoragePaths.BasePath))
        {
            Directory.CreateDirectory(DataStoragePaths.BasePath);
        }

        if (!Directory.Exists(DataStoragePaths.DatabaseFolderPath))
        {
            Directory.CreateDirectory(DataStoragePaths.DatabaseFolderPath);
        }

        if (!Directory.Exists(DataStoragePaths.LogsFolderPath))
        {
            Directory.CreateDirectory(DataStoragePaths.LogsFolderPath);
        }
    }
}