using Dental.Application;
using Dental.Infrastructure;
using Dental.WinForms.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.WinForms;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();

        var services = new ServiceCollection();

        services
            .AddInfrastructure(configuration)
            .AddApplication()
            .AddWinForms()
            .ConfigureSerilog();


        ServiceProvider provider = services.BuildServiceProvider();

        System.Windows.Forms.Application.Run(provider.GetRequiredService<MainForm>());
    }
}