using Dental.Application.Abstractions;
using Dental.Application.Abstractions.ServicesInterfaces;
using Dental.Application.DTOs.Treatment;
using Dental.Application.Services;
using Dental.Application.ViewsStuff.Interfaces.Appointments;
using Dental.Application.ViewsStuff.Interfaces.LabTransactions;
using Dental.Application.ViewsStuff.Interfaces.Patients;
using Dental.Application.ViewsStuff.Interfaces.Visits;
using Dental.Application.ViewsStuff.Services.Appointments;
using Dental.Application.ViewsStuff.Services.LabTransaction;
using Dental.Application.ViewsStuff.Services.Patients;
using Dental.Application.ViewsStuff.Services.Visits;
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
        services.AddScoped<IVisitPaymentService, VisitPaymentService>();

        // Dental.Application.ViewsStuff
        services.AddScoped<IVisitTreatmentsViewService, VisitTreatmentsViewService>();
        services.AddScoped<IVisitViewService, VisitViewService>();
        services.AddScoped<IVisitSummaryService, VisitSummaryService>();
        services.AddScoped<IAppointmentInfoService, AppointmentInfoService>();
        services.AddScoped<IPatientViewService, PatientViewService>();
        services.AddScoped<ILabTransactionService, LabTransactionService>();
        services.AddScoped<ILabTransactionViewService, LabTransactionViewService>();

        return services;
    }
}