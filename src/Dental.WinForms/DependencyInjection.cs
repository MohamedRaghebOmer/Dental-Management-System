using Dental.WinForms.Views;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.WinForms;

public static class DependencyInjection
{
    public static IServiceCollection AddWinForms(this IServiceCollection services)
    {
        services.AddTransient<MainForm>();
        services.AddSingleton(TimeProvider.System);
        services.AddTransient<MainMenuView>();
        services.AddTransient<VisitView>();

        return services;
    }
}