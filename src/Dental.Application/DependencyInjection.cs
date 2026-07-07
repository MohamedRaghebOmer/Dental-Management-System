using Dental.Application.Interfaces;
using Dental.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IServiceService, ServiceService>();

        return services;
    }
}