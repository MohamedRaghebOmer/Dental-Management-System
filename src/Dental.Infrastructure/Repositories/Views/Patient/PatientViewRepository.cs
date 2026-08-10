using Dental.Domain.Repositories.Views.Patients;
using Dental.Domain.ValueObjects;
using Dental.Domain.Views.Patients;
using Dental.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Dental.Infrastructure.Repositories.Views.Patient;

public sealed class PatientViewRepository : IPatientViewRepository
{
    private readonly DentalDbContext _dbContext;

    public PatientViewRepository(DentalDbContext dentalDbContext)
    {
        _dbContext = dentalDbContext;
    }

    public async Task<List<PatientViewDto>> GetAsync(
        PatientViewDto? filterDto = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Domain.Entities.Patient> query = _dbContext.Patients.AsNoTracking();

        string? phoneNumber = null;

        if (filterDto is not null)
        {
            if (filterDto.Id is { } id)
                query = query.Where(p => p.Id == Id.FromDatabase(id));

            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                string name = filterDto.Name.Trim();
                query = query.Where(p => p.Name!.Contains(name));
            }

            if (filterDto.Age is { } age)
                query = query.Where(p => p.Age == age);

            if (filterDto.Gender is { } gender)
                query = query.Where(p => p.Gender == gender);

            if (!string.IsNullOrWhiteSpace(filterDto.PhoneNumber))
                phoneNumber = filterDto.PhoneNumber.Trim();
        }

        var patients = await query
            .Select(p => new PatientViewDto
            {
                Id = p.Id.Value,
                Name = p.Name,
                Age = p.Age,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber != null ? p.PhoneNumber.Value : null
            })
            .ToListAsync(cancellationToken);

        if (phoneNumber is not null)
        {
            patients = patients
                .Where(p => p.PhoneNumber?.Contains(phoneNumber) == true)
                .ToList();
        }

        return patients;
    }

    public Task<List<PatientDetailedInfoDto>> GetDetailedInfoAsync(
        PatientDetailedInfoDto? filterDto = null,
        CancellationToken cancellationToken = default)
    {
        var now = DateTime.Now;

        IQueryable<Domain.Entities.Patient> query = _dbContext.Patients.AsNoTracking();

        if (filterDto is not null)
        {
            if (filterDto.Id is { } id)
                query = query.Where(p => p.Id == Id.FromDatabase(id));

            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                var name = filterDto.Name.Trim();
                query = query.Where(p => p.Name.Contains(name));
            }

            if (filterDto.Age is { } age)
                query = query.Where(p => p.Age == age);

            if (filterDto.Gender is { } gender)
                query = query.Where(p => p.Gender == gender);

            if (!string.IsNullOrWhiteSpace(filterDto.PhoneNumber))
            {
                var phoneNumber = filterDto.PhoneNumber.Trim();
                query = query.Where(p =>
                    p.PhoneNumber != null &&
                    p.PhoneNumber == PhoneNumber.FromDatabase(phoneNumber));
            }

            if (filterDto.NextAppointmentDateTime is { } nextAppointmentDateTime)
            {
                query = query.Where(p =>
                    p.Appointments
                        .Where(a =>
                            a.Status == Domain.Enums.AppointmentStatus.Pending &&
                            a.ScheduledVisitDateTime > now)
                        .OrderBy(a => a.ScheduledVisitDateTime)
                        .Select(
                            a => (DateTime?)a.ScheduledVisitDateTime.Date)
                        .FirstOrDefault() == nextAppointmentDateTime.Date);
            }

            if (filterDto.LastVisitDateTime is { } lastVisitDateTime)
            {
                query = query.Where(p =>
                    p.Visits
                        .Select(v => (DateTime?)v.VisitDateTime.Date)
                        .Max() == lastVisitDateTime.Date);
            }

            if (filterDto.TotalNumberOfVisits is { } totalNumberOfVisits)
            {
                query = query.Where(p => p.Visits.Count() == totalNumberOfVisits);
            }
        }

        return query
            .Select(p => new PatientDetailedInfoDto
            {
                Id = p.Id.Value,
                Name = p.Name,
                Age = p.Age,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber != null ? p.PhoneNumber.Value : null,
                NextAppointmentDateTime = p.Appointments
                    .Where(a =>
                        a.Status == Domain.Enums.AppointmentStatus.Pending &&
                        a.ScheduledVisitDateTime > now)
                    .OrderBy(a => a.ScheduledVisitDateTime)
                    .Select(a => (DateTime?)a.ScheduledVisitDateTime)
                    .FirstOrDefault(),
                LastVisitDateTime = p.Visits
                    .Select(v => (DateTime?)v.VisitDateTime)
                    .Max(),
                TotalNumberOfVisits = p.Visits.Count()
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<PatientInfoCards> GetInfoCardsAsync(
        CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Patients
            .AsNoTracking()
            .Select(p => new
            {
                IsTodayPatient = p.Visits.Any(v =>
                    v.VisitDateTime.Date >= DateTime.Today.Date
                    && v.VisitDateTime.Date < DateTime.Today.AddDays(1).Date),

                IsMale = p.Gender == Domain.Enums.Gender.Male ? 1 : 0,
                IsFemale = p.Gender == Domain.Enums.Gender.Female ? 1 : 0,
                IsChild = p.Age.HasValue && p.Age.Value < 18 ? 1 : 0,
                IsAdult = p.Age.HasValue && p.Age.Value >= 18 ? 1 : 0
            })
            .GroupBy(_ => 1)
            .Select(g => new PatientInfoCards
            {
                PatientsCount = g.Count(),
                TodayPatientsCount = g.Count(x => x.IsTodayPatient),
                MalePatientsPercentage = g.Any()
                    ? g.Sum(x => x.IsMale) * 100m / g.Count()
                    : 0m,
                FemalePatientsPercentage = g.Any()
                    ? g.Sum(x => x.IsFemale) * 100m / g.Count()
                    : 0m,
                ChildrenPatientsPercentage = g.Any()
                    ? g.Sum(x => x.IsChild) * 100m / g.Count()
                    : 0m,
                AdultsPatientsPercentage = g.Any()
                    ? g.Sum(x => x.IsAdult) * 100m / g.Count()
                    : 0m
            })
            .FirstOrDefaultAsync(cancellationToken);

        return result ?? new PatientInfoCards
        {
            PatientsCount = 0,
            TodayPatientsCount = 0,
            MalePatientsPercentage = 0m,
            FemalePatientsPercentage = 0m,
            AdultsPatientsPercentage = 0m,
            ChildrenPatientsPercentage = 0m
        };
    }
}
