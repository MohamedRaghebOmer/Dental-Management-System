using Dental.Domain.Interfaces.Repositories;
using Dental.Infrastructure.Persistence;
using Dental.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dental.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string connectionString =
            configuration.GetConnectionString("DefaultConnection")!;

        services.AddDbContext<DentalDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IVisitToothTreatmentRepository, VisitToothTreatmentRepository>();

        return services;
    }
}