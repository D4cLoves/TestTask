using Microsoft.AspNetCore.Mvc;
using TestTask_Application.Services;
using TestTask_Domain.Entites;

namespace TestTask_API.Controllers;

[ApiController]
[Route("api/diseases")]
public class DiseaseController : ControllerBase
{
    private readonly DiseaseService  _diseaseService;
    public DiseaseController(DiseaseService diseaseService) => _diseaseService = diseaseService;

    [HttpGet]
    public async Task<ActionResult<List<Disease>>> Get()
    {
        var diseases = await _diseaseService.GetDiseases();
        if (diseases == null || !diseases.Any())
            return NotFound("Болезни не найдены");
        return diseases;
    }
}