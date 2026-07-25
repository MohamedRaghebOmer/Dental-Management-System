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
}
