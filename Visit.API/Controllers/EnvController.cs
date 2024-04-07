using Microsoft.AspNetCore.Mvc;

namespace Visit.API.Controllers;

[ApiController]
[Route("api/env")]
public class EnvController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(Environment.GetEnvironmentVariables());
    }
}