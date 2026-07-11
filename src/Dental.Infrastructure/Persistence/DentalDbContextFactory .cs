using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Dental.Infrastructure.Persistence;

public sealed class DentalDbContextFactory : IDesignTimeDbContextFactory<DentalDbContext>
{
    public DentalDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        string connectionString =
            configuration.GetConnectionString("DefaultConnection")
            ?? "Data Source=Dental.db";

        var optionsBuilder = new DbContextOptionsBuilder<DentalDbContext>();
        optionsBuilder.UseSqlite(connectionString);

        return new DentalDbContext(optionsBuilder.Options);
    }
}