using Dental.Domain.Repositories;
using Dental.Domain.Repositories.Views;
using Dental.Infrastructure.Persistence;
using Dental.Infrastructure.Repositories;
using Dental.Infrastructure.Repositories.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IVisitTreatmentsRepository, VisitTreatmentsRepository>();
        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<ITreatmentRepository, TreatmentRepository>();
        services.AddScoped<IMaterialRepository, MaterialRepository>();
        services.AddScoped<IVisitToothTreatmentsViewRepository, VisitToothTreatmentsViewRepository>();
        services.AddScoped<IDentalInfoRepository, DentalInfoRepository>();
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IPrescriptionItemRepository, PrescriptionItemRepository>();

        return services;
    }
}