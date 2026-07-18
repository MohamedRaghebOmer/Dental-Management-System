using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Treatment;
using Dental.Application.Services;
using Dental.Application.ViewsStuff.Interfaces;
using Dental.Application.ViewsStuff.Services;
using Dental.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ServiceBase<Treatment, TreatmentResponseDto>, TreatmentService>();

        // Dental.Application.Services
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<ITreatmentService, TreatmentService>();
        services.AddScoped<IVisitService, VisitService>();
        services.AddScoped<IVisitTreatmentService, VisitTreatmentService>();
        services.AddScoped<IDentalInfoService, DentalInfoService>();
        services.AddScoped<IMaterialService, MaterialService>();
        services.AddScoped<IPrescriptionItemService, PrescriptionItemService>();
        services.AddScoped<IPrescriptionService, PrescriptionService>();
        services.AddScoped<ISupplierService, SupplierService>();

        // Dental.Application.ViewsStuff
        services.AddScoped<IVisitToothTreatmentsViewService, VisitToothTreatmentsViewService>();
        services.AddScoped<IVisitViewService, VisitViewService>();
        services.AddScoped<IVisitSummaryService, VisitSummaryService>();

        return services;
    }
}