using TestTask_Domain.Entites;
using TestTask_Domain.ValueObject;

namespace TestTask_Domain.Interfaces;

public interface IPatientRepository
{
    Task<Patient> GetPatientOnId(Guid id);
    Task<List<Patient>> GetPatients();
    Task UpdatePatientNameAsync(Guid id, FullName name);
}