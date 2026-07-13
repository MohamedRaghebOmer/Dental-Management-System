using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dental.Infrastructure.Persistence;

public sealed class DentalDbContextFactory : IDesignTimeDbContextFactory<DentalDbContext>
{
    public DentalDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DentalDbContext>();
        optionsBuilder.UseSqlite(
            string.Concat("Data Source=", Constants.DataStoragePaths.DatabaseFilePath))
            .AddInterceptors(new LoggingInterceptor());

        return new DentalDbContext(optionsBuilder.Options);
    }
}