using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo _veiculo; //setup
        public ITestOutputHelper saidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper saidaConsoleTeste) //sempre criado o ctor antes da chamada do metodo de teste
        {
            this.saidaConsoleTeste = saidaConsoleTeste;
            this.saidaConsoleTeste.WriteLine("Executando o construtor");

            _veiculo = new Veiculo();
        }

        [Fact/*(DisplayName = "Teste para aceleração de um veículo")*/]
        //[Trait("Funcionalidade", "Acelerar")]
        public void Testa_Metodo_Acelerar_Com_Parametro_Dez()
        {
            // AAA
            //Arrenge (CONFIGURAÇÃO)
            //var veiculo = new Veiculo();

            //Act (AÇÃO)
            _veiculo.Acelerar(10); //10 * 10 + velocidade atual

            //Assert (VALIDAÇÃO)
            Assert.Equal(100, _veiculo.VelocidadeAtual);
        }

        [Fact]
        //[Trait("Funcionalidade", "Frear")]
        public void Testa_Metodo_Frear_Com_Parametro_Dez()
        {
            //var veiculo = new Veiculo();



            _veiculo.Frear(10); //10 * 15 - velocidade atual



            Assert.Equal(-150, _veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste em implementação")]
        public void Teste_Valida_Nome_Proprietario_Do_Veiculo()
        {
            //implementação do teste
        }

        [Fact]
        public void Testa_Dados_Do_Veiculo()
        {
            //var veiculo = new Veiculo();
            _veiculo.Proprietario = "Fulano";
            _veiculo.Placa = "ABC-1234";
            _veiculo.Cor = "Preto";
            _veiculo.Modelo = "Carro";
            _veiculo.Tipo = TipoVeiculo.Automovel;




            string dados = _veiculo.ToString();



            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Executando o dispose");
        }
    }
}
