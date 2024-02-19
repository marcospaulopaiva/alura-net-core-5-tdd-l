using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste
    {
        private Patio _patio;
        private Veiculo _veiculo;
        private Operador _operador;

        public PatioTeste()
        {
            _operador = new Operador();
            _operador.Nome = "Nome Operador";
            _veiculo = new Veiculo();
            _patio = new Patio();
            _patio.OperadorPatio = _operador;
        }

        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            _veiculo.Proprietario = "Marcos Paulo";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Azul";
            _veiculo.Modelo = "Lancer Evo X";
            _veiculo.Placa = "MPP-1983";

            _patio.RegistrarEntradaVeiculo(_veiculo);
            _patio.RegistrarSaidaVeiculo(_veiculo.Placa);

            //Act
            double faturamento =_patio.TotalFaturado();

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
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Proprietario = proprietario;
            _veiculo.Placa = placa;
            _veiculo.Cor = cor;
            _veiculo.Modelo = modelo;

           _patio.RegistrarEntradaVeiculo(_veiculo);
           _patio.RegistrarSaidaVeiculo(_veiculo.Placa);

            //Act
            double faturamento =_patio.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Marcos Paulo", "MPP-1983", "Azul", "Lancer Evo X")]
        public void LocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Proprietario = proprietario;
            _veiculo.Placa = placa;
            _veiculo.Cor = cor;
            _veiculo.Modelo = modelo;

           _patio.RegistrarEntradaVeiculo(_veiculo);

            //Act
            var consultado =_patio.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AltearDadosVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();
            _veiculo.Proprietario = "Marcos Paulo";
            _veiculo.Tipo = TipoVeiculo.Automovel;
            _veiculo.Cor = "Azul";
            _veiculo.Modelo = "Lancer Evo X";
            _veiculo.Placa = "MPP-1983";
           _patio.RegistrarEntradaVeiculo(_veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Marcos Paulo";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Verde"; //Alterado
            veiculoAlterado.Modelo = "Lancer Evo X";
            veiculoAlterado.Placa = "MPP-1983";

            //Act
           _patio.AlterarDadosVeiculo(veiculoAlterado);
            Veiculo veiculoConsultado =_patio.PesquisaVeiculo(_veiculo.Placa);

            //Assert
            Assert.Equal(veiculoConsultado.Cor, veiculoAlterado.Cor);
        }
    }
}
