using Dental.Domain.Repositories;
using Dental.Domain.Repositories.Views.Appointments;
using Dental.Domain.Repositories.Views.LabTransactions;
using Dental.Domain.Repositories.Views.Patients;
using Dental.Domain.Repositories.Views.Visits;
using Dental.Infrastructure.Persistence;
using Dental.Infrastructure.Repositories;
using Dental.Infrastructure.Repositories.Views.Appointment;
using Dental.Infrastructure.Repositories.Views.LabTransactions;
using Dental.Infrastructure.Repositories.Views.Patient;
using Dental.Infrastructure.Repositories.Views.Visit;
using Dental.Infrastructure.Repositories.Views.Visits;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddDbContext<DentalDbContext>(options =>
        {
            options.UseSqlite(
                string.Concat(
                    "Data Source=",
                    Constants.DataStoragePaths.DatabaseFilePath));

            options.AddInterceptors(new LoggingInterceptor());
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<ITreatmentRepository, TreatmentRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IVisitToothTreatmentsViewRepository, VisitTreatmentsViewRepository>();
        services.AddScoped<IDentalInfoRepository, DentalInfoRepository>();
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IVisitViewRepository, VisitViewRepository>();
        services.AddScoped<IVisitSummaryRepository, VisitSummaryRepository>();
        services.AddScoped<IAppointmentInfoRepository, AppointmentInfoRepository>();
        services.AddScoped<IPatientViewRepository, PatientViewRepository>();
        services.AddScoped<ILabTransactionRepository, LabTransactionRepository>();
        services.AddScoped<ILabTransactionViewRepository, LabTransactionViewRepository>();
        services.AddScoped<DatabaseInitializer>();

        return services;
    }
}