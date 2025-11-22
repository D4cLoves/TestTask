using TestTask_Domain.Entites;
using TestTask_Infrastructure.Repositories;

namespace TestTask_Application.Services;

public class DiseaseService
{
    private readonly DiseaseRepository _diseaseRepository;
    public DiseaseService(DiseaseRepository diseaseRepository)
    {
        _diseaseRepository = diseaseRepository;
    }

    public async Task<List<Disease>> GetDiseases()
    {
        return await _diseaseRepository.GetDiseases();
    }
}