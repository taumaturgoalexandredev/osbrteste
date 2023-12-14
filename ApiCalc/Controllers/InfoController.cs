using Microsoft.AspNetCore.Mvc;

namespace ApiCalc.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class InfoController : ControllerBase
{
    private readonly IConfiguration _configuration;
    public InfoController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("ShowMeTheCode")]
    public IActionResult ShowMeTheCode()
    {
        return Ok()
    }
}