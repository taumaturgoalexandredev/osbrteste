using ApiCalc.Service.Interfaces;
using ApiCalc.Service.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ApiCalc.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CalculoController : ControllerBase
{
    private readonly ICalculoService _calculoService;
    public CalculoController(ICalculoService calculoService)
    {
        _calculoService = calculoService;
    }

    [HttpPost("calculajuros")]
    public async Task<IActionResult> CalcularJuros([FromQuery] CalcularJurosRequest request)
    {
        if (request.ValorInicial == 0 || request.Tempo == 0)
        {
            return BadRequest("Request inválida, por favor verifique-a.");
        }

        var response = await _calculoService.CalcularJuros(request);
        return Ok(response);
    }
}