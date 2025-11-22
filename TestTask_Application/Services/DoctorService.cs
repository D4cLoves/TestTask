using TestTask_Domain.Entites;
using TestTask_Infrastructure.Repositories;

namespace TestTask_Application.Services;

public class DoctorService
{
    private readonly DoctorRepository _doctorRepository;
    public DoctorService(DoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }
    
    public async Task<List<Doctor>> GetDoctorsBySpeciality(string speciality)
    {
        return await _doctorRepository.GetDoctorsBySpeciality(speciality);
    }
}