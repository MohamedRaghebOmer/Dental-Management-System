using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Responses;
using Dental.Application.Services;
using Dental.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ServiceBase<Treatment, TreatmentResponseDto>, TreatmentService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<ITreatmentService, TreatmentService>();
        services.AddScoped<IVisitService, VisitService>();

        return services;
    }
}