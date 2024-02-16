using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste
    {
        [Fact]
        [Trait("Teste de Veiculo", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Teste de Veiculo", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
        
        [Fact(DisplayName ="Tipo de Veiculo")]
        public void TestaTipoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(DisplayName="N�o implementado", Skip = "Teste ainda n�o implementado. ignorar")]
        public void ValidaNomeProprietario()
        {

        }
        
        [Fact]
        public void ValidarDadosVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Marcos Paulo";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZAP-0800";
            veiculo.Cor = "Amarelo";
            veiculo.Modelo = "R34 Skyline";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Tipo do Ve�culo: Automovel", dados);
        }
    }
}
