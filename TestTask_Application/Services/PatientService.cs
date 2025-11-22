using TestTask_Domain.Entites;
using TestTask_Infrastructure.Repositories;

namespace TestTask_Application.Services;

public class PatientService 
{
    private readonly PatientRepository _patientRepository;
    public PatientService(PatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Patient> GetPatientOnId(Guid id)
    {
        return await _patientRepository.GetPatientOnId(id);
    }
    
    public async Task<List<Patient>> GetPatients()
    {
        return await _patientRepository.GetPatients();
    }
}