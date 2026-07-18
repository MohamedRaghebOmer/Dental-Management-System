using Dental.Domain.Entities;
using Dental.Domain.Repositories;

namespace Dental.Infrastructure.Repositories;

public interface IPatientRepository
    : IRepository<Patient>
{

}