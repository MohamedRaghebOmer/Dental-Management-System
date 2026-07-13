using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class AppointmentRepository(DentalDbContext _dbContext) 
    : Repository<Appointment>(_dbContext), 
    IAppointmentRepository
{
    public Task<bool> ExistsByDateAsync(
        DateTime date,
        int? excludedId = null,
        CancellationToken cancellationToken = default)
    {
        if (excludedId == null)
        {
            return _dbContext.Appointments.AnyAsync(
            a => a.Date == date,
            cancellationToken);
        }

        return _dbContext.Appointments.AnyAsync(
            a => a.Date == date && a.Id != Id.FromDatabase(excludedId.Value),
            cancellationToken);
    }
}