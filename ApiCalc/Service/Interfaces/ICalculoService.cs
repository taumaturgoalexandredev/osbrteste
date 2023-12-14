using ApiCalc.Service.Requests;
using ApiCalc.Service.Responses;

namespace ApiCalc.Service.Interfaces;

public interface ICalculoService
{
    Task<CalcularJurosResponse> CalcularJuros(CalcularJurosRequest request);
}