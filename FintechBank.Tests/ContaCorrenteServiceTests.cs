using FintechBank.App;

namespace FintechBank.Tests;

public class ContaCorrenteServiceTests
{
    private readonly ContaCorrenteService _service = new();

    [Theory]
    [InlineData(6000.00, false, 0.00)]
    [InlineData(500.00, true, 0.00)]
    [InlineData(2500.00, false, 12.50)]
    [InlineData(300.00, false, 25.00)]
    public void CalcularTaxaManutencao_DeveRetornarValorEsperado(double saldo, bool clienteEspecial, double esperado)
    {
        var resultado = _service.CalcularTaxaManutencao((decimal)saldo, clienteEspecial);

        Assert.Equal((decimal)esperado, resultado);
    }

    [Theory]
    [InlineData(1000.00, 500.00, 1200.00, true)]
    [InlineData(1000.00, 500.00, 1600.00, false)]
    public void PodeRealizarSaque_DeveValidarSaldoMaisLimite(double saldo, double limite, double valorSaque, bool esperado)
    {
        var resultado = _service.PodeRealizarSaque((decimal)saldo, (decimal)limite, (decimal)valorSaque);

        Assert.Equal(esperado, resultado);
    }
}