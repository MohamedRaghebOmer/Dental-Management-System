using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Diagnostics;

namespace Dental.Infrastructure.Persistence;

public sealed class DentalDbContextFactory : IDesignTimeDbContextFactory<DentalDbContext>
{
    public DentalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DentalDbContext>();
        optionsBuilder.UseSqlite(
            string.Concat("Data Source=", Constants.DataStoragePaths.DatabaseFilePath))
            .AddInterceptors(new LoggingInterceptor())
           .EnableSensitiveDataLogging()
           .LogTo(message => Debug.WriteLine(message),
               Microsoft.Extensions.Logging.LogLevel.Information);

        return new DentalDbContext(optionsBuilder.Options);
    }
}