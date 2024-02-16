using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste
    {
        private Veiculo _veiculo;

        public VeiculoTeste()
        {
            _veiculo = new Veiculo();
        }

        [Fact]
        [Trait("Teste de Veiculo", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Act
            _veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, _veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Teste de Veiculo", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Act
            _veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, _veiculo.VelocidadeAtual);
        }
        
        [Fact(DisplayName ="Tipo de Veiculo")]
        public void TestaTipoVeiculo()
        {
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, _veiculo.Tipo);
        }

        [Fact(DisplayName="Não implementado", Skip = "Teste ainda não implementado. ignorar")]
        public void ValidaNomeProprietario()
        {

        }
        
        [Fact]
        public void ValidarDadosVeiculo()
        {
            //Arrange
            _veiculo.Proprietario = "Marcos Paulo";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Placa = "ZAP-0800";
            _veiculo.Cor = "Amarelo";
            _veiculo.Modelo = "R34 Skyline";

            //Act
            string dados = _veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }
    }
}
