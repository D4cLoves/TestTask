using TestTask_Domain.Entites;

namespace TestTask_Domain.Interfaces;

public interface IPatientRepository
{
    Task<Patient> GetPatientOnId(Guid id);
    Task<List<Patient>> GetPatients();
}