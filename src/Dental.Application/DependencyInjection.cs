using Dental.Application.Abstractions;
using Dental.Application.DTOs.Responses;
using Dental.Application.Services;
using Dental.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ServiceBase<Service, ServiceResponseDto>, ServiceService>();

        return services;
    }
}