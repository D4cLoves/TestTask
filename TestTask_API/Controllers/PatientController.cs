using Microsoft.AspNetCore.Mvc;
using TestTask_Application.Services;
using TestTask_Domain.Entites;

namespace TestTask_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly PatientService _patientService;

    public PatientController(PatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatient(Guid id)
    {
        var patient = await _patientService.GetPatientOnId(id);
        if (patient == null) return NotFound();
        return Ok(patient);
    }
}