using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void TestaMetodoTotalFaturadoComUmVeiculo()
        {
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = "Fulado de Tal";
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Carro";
            veiculo.Placa = "abc-1234";
            veiculo.Tipo = TipoVeiculo.Automovel;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);



            var faturamento = estacionamento.TotalFaturado();



            Assert.Equal(2, faturamento);
        }

        [Theory] //permite fazer testes com parametros usando o InlineData
        [InlineData("Fulano de Tal", "ABC-1234", "Preto", "Carro")]
        [InlineData("Fulano de Tal Filho", "BCD-4321", "Branco", "Carro")]
        [InlineData("Fulano de Tal Primo", "GEF-9876", "Vermelho", "Moto")]
        public void TestaMetodoTotalFaturadoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);



            var faturamento = estacionamento.TotalFaturado();



            Assert.Equal(2, faturamento);
        }

        [Theory] //permite fazer testes com parametros usando o InlineData
        [InlineData("Fulano de Tal", "ABC-1234", "Preto", "Carro")]
        public void TestaMetodoPesquisaVeiculo(string proprietario, string placa, string cor, string modelo)
        {
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);



            var consultado = estacionamento.PesquisaVeiculo(placa);



            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void TestaMetodoAlterarDadosVeiculo()
        {
            var estacionamento = new Patio();
            var veiculo = new Veiculo
            { 
                Proprietario = "Fulano",
                Placa = "ABC-1234",
                Cor = "Preto",
                Modelo = "Carro",
            };
            var veiculoAlterado = new Veiculo
            {
                Proprietario = "Fulano",
                Placa = "ABC-1234",
                Cor = "Branco", //alteração
                Modelo = "Carro",
            };
            estacionamento.RegistrarEntradaVeiculo(veiculo);



            var alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);



            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }
    }
}
