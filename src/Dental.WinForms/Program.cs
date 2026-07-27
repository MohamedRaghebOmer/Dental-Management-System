using Dental.Application;
using Dental.Infrastructure;
using Dental.Infrastructure.Constants;
using Dental.WinForms.Configurations;
using Dental.WinForms.Security;
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

            if (!LicenseBootstrapper.IsActivated(out string error))
            {
                using ActivationForm form = new ActivationForm();

                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

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

            EnsureInitialDataAsync(provider).GetAwaiter().GetResult();

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
        Directory.CreateDirectory(DataStoragePaths.DatabaseFolderPath);
        Directory.CreateDirectory(DataStoragePaths.LogsFolderPath);
        Directory.CreateDirectory(DataStoragePaths.ImagesFolderPath);
    }

    private static async Task EnsureInitialDataAsync(IServiceProvider provider)
    {
        using var scope = provider.CreateScope();

        var initializer = scope.ServiceProvider
            .GetRequiredService<DatabaseInitializer>();

        await initializer.InitializeAsync();
    }
}