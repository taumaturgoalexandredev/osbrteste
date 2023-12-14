using ApiCalc.Facades.Interfaces;
using ApiCalc.Service.Interfaces;
using ApiCalc.Service.Requests;
using ApiCalc.Service.Responses;
using System.Globalization;

namespace ApiCalc.Service;

public class CalculoService : ICalculoService
{
    private readonly ITaxFacade _facade;
    public CalculoService(ITaxFacade facade)
    {
        _facade = facade;
    }

    public async Task<CalcularJurosResponse> CalcularJuros(CalcularJurosRequest request)
    {
        var tax = await _facade.BuscarTaxaBase();

        var valorFinal =
            CalcularJurosCompostos(request.ValorInicial, tax, request.Tempo);

        return new CalcularJurosResponse
        {
            ValorFinal = valorFinal
        };
    }

    private string CalcularJurosCompostos(decimal valorInicial, decimal taxa, int tempo)
    {
        decimal valorFinal = valorInicial;

        for (int i = 0; i < tempo; i++)
        {
            valorFinal *= (1 + taxa);
        }

        valorFinal = decimal.Round(valorFinal, 2, MidpointRounding.AwayFromZero);

        string valorFinalFormatado = valorFinal.ToString("N2", new CultureInfo("pt-BR"));

        return valorFinalFormatado;
    }
}