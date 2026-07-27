using Dental.Domain.Entities;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure;

public sealed class DatabaseInitializer
{
    private readonly DentalDbContext _dbContext;

    public DatabaseInitializer(DentalDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task InitializeAsync()
    {
        await _dbContext.Database.MigrateAsync();

        if (await _dbContext.DentalInfo.AnyAsync())
            return;

        _dbContext.DentalInfo.Add(DentalInfo.CreateDefault());
        await _dbContext.SaveChangesAsync();
    }
}