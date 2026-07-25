using Dental.Domain.Entities;
using Dental.Domain.Enums;
using Dental.Domain.Repositories;
using Dental.Domain.ValueObjects;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories;

public sealed class AppointmentRepository
    : Repository<Appointment>,
    IAppointmentRepository
{
    private readonly DentalDbContext _dbContext;

    public AppointmentRepository(DentalDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<bool> ExistsByScheduleVisitDateTimeAsync(
        DateTime scheduledVisitDateTime,
        Id? excludedId = null,
        CancellationToken cancellationToken = default)
    {
        return _dbContext.Appointments.AnyAsync(
            a => a.ScheduledVisitDateTime == scheduledVisitDateTime && a.Id != excludedId,
            cancellationToken);
    }

    public Task<AppointmentStatus?> GetStatusAsync(
        Id id,
        CancellationToken cancellationToken = default)
    {
        var now = DateTime.Now;

        return _dbContext.Appointments
            .Where(a => a.Id == id)
            .Select(a =>
                (AppointmentStatus?)(
                    a.Status == AppointmentStatus.Pending &&
                    a.ScheduledVisitDateTime < now &&
                    a.ActualVisitDateTime == null
                        ? AppointmentStatus.Missed
                        : a.Status))
            .FirstOrDefaultAsync(cancellationToken);
    }
}