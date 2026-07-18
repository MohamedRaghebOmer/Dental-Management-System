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
    public Task<bool> ExistsByScheduleVisitDateTimeAsync(
        DateTime scheduledVisitDateTime,
        Id? excludedId = null,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Appointments.AnyAsync(
            a => a.ScheduledVisitDateTime == scheduledVisitDateTime && a.Id != excludedId,
            cancellationToken);
    }
}