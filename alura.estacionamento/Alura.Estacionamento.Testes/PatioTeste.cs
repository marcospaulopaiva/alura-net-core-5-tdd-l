using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste
    {
        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = "Marcos Paulo";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Lancer Evo X";
            veiculo.Placa = "MPP-1983";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
        [InlineData("Jose Pereira", "POL-9234", "cinza", "Fusca")]
        [InlineData("Maria Silva", "GDR-7649", "azul", "Opala")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Marcos Paulo", "MPP-1983", "Azul", "Lancer Evo X")]
        public void LocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AltearDadosVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();

            var veiculo = new Veiculo();
            veiculo.Proprietario = "Marcos Paulo";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Lancer Evo X";
            veiculo.Placa = "MPP-1983";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Marcos Paulo";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Verde"; //Alterado
            veiculoAlterado.Modelo = "Lancer Evo X";
            veiculoAlterado.Placa = "MPP-1983";

            //Act
            estacionamento.AlterarDadosVeiculo(veiculoAlterado);
            Veiculo veiculoConsultado = estacionamento.PesquisaVeiculo(veiculo.Placa);

            //Assert
            Assert.Equal(veiculoConsultado.Cor, veiculoAlterado.Cor);
        }
    }
}
