using ApiCalc.Facades.Interfaces;
using System.Globalization;

namespace ApiCalc.Facades;

public class TaxFacade : ITaxFacade
{
    private readonly HttpClient _httpClient; 
    public TaxFacade(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<decimal> BuscarTaxaBase()
    {
        var httpResponseMessage = await _httpClient.GetAsync("api/v1/Taxa");
        var response = await httpResponseMessage.Content.ReadAsStringAsync();

        var tax = decimal.Parse(response, CultureInfo.InvariantCulture);

        return tax;
    }
}