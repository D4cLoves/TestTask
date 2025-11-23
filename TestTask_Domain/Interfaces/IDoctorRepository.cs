using TestTask_Domain.Entites;

namespace TestTask_Domain.Interfaces;

public interface IDoctorRepository
{
    Task<List<Doctor>> GetDoctorsBySpeciality(string specialty);
}