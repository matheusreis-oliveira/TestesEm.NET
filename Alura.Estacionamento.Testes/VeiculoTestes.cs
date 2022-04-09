using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName = "Teste para aceleração de um veículo")]
        [Trait("Funcionalidade","Acelerar")]
        public void TesteMetodoAceleracar()
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
        [Trait("Funcionalidade", "Frear")]
        public void TesteMetodoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10); //10 * 15 - velocidade atual

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste em implementação")]
        public void TesteValidaNomeProprietario()
        {
            //implementação do teste
        }
    }
}
