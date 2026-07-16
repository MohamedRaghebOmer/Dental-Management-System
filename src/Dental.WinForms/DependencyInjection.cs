using Dental.WinForms.Abstractions;
using Dental.WinForms.Factories;
using Dental.WinForms.Forms;
using Dental.WinForms.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.WinForms;

public static class DependencyInjection
{
    public static IServiceCollection AddWinForms(this IServiceCollection services)
    {
        services.AddTransient<IFormFactory, FormFactory>();
        services.AddForms();
        services.AddViews();

        return services;
    }

    private static IServiceCollection AddForms(this IServiceCollection services)
    {
        services.AddTransient<frmMain>();
        services.AddTransient<frmAddUpdateVisit>();
        services.AddTransient<frmAddEditTreatment>();

        return services;
    }

    private static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddTransient<MainMenuView>();
        services.AddTransient<VisitView>();

        return services;
    }
}