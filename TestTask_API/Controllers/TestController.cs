using Microsoft.AspNetCore.Mvc;

namespace TestTask_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { Message = "Hello World" });
    }
}