using Dental.Domain.Entities;
using Dental.Domain.Repositories;
using Dental.Infrastructure.Persistence;

namespace Dental.Infrastructure.Repositories;

public sealed class PatientRepository(DentalDbContext _dbContext)
    : Repository<Patient>(_dbContext)
    , IPatientRepository
{
}
