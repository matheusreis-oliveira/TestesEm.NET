using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact]
        public void TestaMetodoAceleracar()
        {
            // AAA
            //Arrenge (CONFIGURAÇÃO)
            var veiculo = new Veiculo();
            //Act (AÇÃO)
            veiculo.Acelerar(10); //10 * 10 + velocidade atual
            //Assert (VALIDAÇÃO)
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaMetodoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10); //10 * 15 - velocidade atual

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
    }
}
