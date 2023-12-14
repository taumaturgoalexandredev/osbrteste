using ApiCalc.Facades.Interfaces;
using ApiCalc.Service;
using ApiCalc.Service.Requests;
using Moq;
using Xunit;

namespace ObsrIntegrationTests.Services;

public class CalculoServiceTests
{
    [Theory]
    [InlineData(100, 5, "105,10")]
    [InlineData(1000, 5, "1.051,01")]
    public async Task Test_CalcularJuros_ShouldBeReturnCorrectlyValues(decimal valorInicial, int tempo, string expected)
    {
        //Arrange
        var facade = new Mock<ITaxFacade>();

        facade.Setup(x => x.BuscarTaxaBase())
            .ReturnsAsync(0.01M);

        var service = GetService(facade.Object);

        //Act
        var response = await service.CalcularJuros(new CalcularJurosRequest
        {
            Tempo = tempo,
            ValorInicial = valorInicial
        });

        //Assert
        facade.Verify(x => x.BuscarTaxaBase(), Times.Once);
        Assert.NotNull(response);
        Assert.NotEmpty(response.ValorFinal);

        Assert.Equal(expected, response.ValorFinal);
    }

    private CalculoService GetService(ITaxFacade facade)
    {
        return new(facade);
    }
}