using Microsoft.AspNetCore.Mvc;
using TestTask_Application.Services;
using TestTask_Domain.Entites;
using TestTask_Infrastructure.Repositories;

namespace TestTask_API.Controllers;

[ApiController]
[Route("api/doctors")]
public class DoctorController : ControllerBase
{
    private readonly DoctorService _doctorService;

    public DoctorController(DoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("specialty/{speciality}")]
    public async Task<ActionResult<List<Doctor>>> GetDoctorsBySpeciality(string speciality)
    {
        return await _doctorService.GetDoctorsBySpeciality(speciality);
    }
}