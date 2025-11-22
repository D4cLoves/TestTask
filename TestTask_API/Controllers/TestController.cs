using Microsoft.AspNetCore.Mvc;

namespace TestTask_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(new { Message = "Hello World" });
    }
}