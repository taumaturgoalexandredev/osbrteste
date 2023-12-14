using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiTaxa.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TaxaController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TaxaController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    [HttpGet]
    public Task<OkObjectResult> BuscarTaxaBase()
    {
        var tax = _configuration.GetSection("BaseTax").Value;

        return Task.FromResult(Ok(tax));
    }
}