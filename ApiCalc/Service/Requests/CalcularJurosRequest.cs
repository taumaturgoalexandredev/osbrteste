namespace ApiCalc.Service.Requests;

public class CalcularJurosRequest
{
    public decimal ValorInicial { get; set; }
    public int Tempo { get; set; }
}