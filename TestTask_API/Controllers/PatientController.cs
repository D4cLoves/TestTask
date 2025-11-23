using Microsoft.AspNetCore.Mvc;
using TestTask_Application.Services;
using TestTask_Domain.Entites;
using TestTask_Domain.ValueObject;

namespace TestTask_API.Controllers;

[ApiController]
[Route("api/patients")]
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

    [HttpGet]
    public async Task<ActionResult<List<Patient>>> GetPatients()
    {
        var patients = await _patientService.GetPatients();
        if (patients == null || !patients.Any())
            return NotFound("Пациенты не найдены");
        return Ok(patients);
    }

    [HttpPatch("{id}/name")]
    public async Task<IActionResult> UpdatePatientName(Guid id, [FromBody] string newName)
    {
        await _patientService.UpdatePatientNameAsync(id, newName);
        return NoContent();
    }
}