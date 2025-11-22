using TestTask_Domain.Entites;

namespace TestTask_Domain.Interfaces;

public interface IDieseasRepository
{
    Task<List<Disease>> GetDiseases();
}