using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void TestaMetodoTotalFaturadoPatioModelo()
        {
            var estacionamento = new Patio();
            var carro = new Veiculo();

            carro.Proprietario = "Fulado de Tal";
            carro.Cor = "Preto";
            carro.Modelo = "Carro";
            carro.Placa = "abc-1234";
            carro.Tipo = TipoVeiculo.Automovel;

            estacionamento.RegistrarEntradaVeiculo(carro);
            estacionamento.RegistrarSaidaVeiculo(carro.Placa);



            var faturamento = estacionamento.TotalFaturado();


            Assert.Equal(2, faturamento);
        }
    }
}
