namespace ApiCalc.Facades.Interfaces;

public interface ITaxFacade
{
    Task<decimal> BuscarTaxaBase();
}