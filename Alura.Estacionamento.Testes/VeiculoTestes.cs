using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName = "Teste para acelera��o de um ve�culo")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaMetodoAceleracar()
        {
            // AAA
            //Arrenge (CONFIGURA��O)
            var veiculo = new Veiculo();
            //Act (A��O)
            veiculo.Acelerar(10); //10 * 10 + velocidade atual
            //Assert (VALIDA��O)
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]
        public void TestaMetodoFrear()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10); //10 * 15 - velocidade atual

            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste em implementa��o")]
        public void TesteValidaNomeProprietario()
        {
            //implementa��o do teste
        }

        [Fact]
        public void TestaDadosDoVeiculo()
        {
            var veiculo = new Veiculo
            {
                Proprietario = "Fulano",
                Placa = "ABC-1234",
                Cor = "Preto",
                Modelo = "Carro",
                Tipo = TipoVeiculo.Automovel
            };



            string dados = veiculo.ToString();



            Assert.Contains("Tipo do Ve�culo: Automovel", dados);
        }
    }
}
