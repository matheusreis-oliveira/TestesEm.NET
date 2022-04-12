using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes : IDisposable
    {
        private Veiculo _veiculo;
        private Patio _patio;
        public ITestOutputHelper saidaConsoleTeste;

        public PatioTestes(ITestOutputHelper saidaConsoleTeste)
        {
            this.saidaConsoleTeste = saidaConsoleTeste;
            this.saidaConsoleTeste.WriteLine("Executando o construtor");

            _veiculo = new Veiculo();
            _patio = new Patio();
        }

        [Fact]
        public void Teste_Metodo_Total_Faturado_Com_Um_Veiculo()
        {
            //var estacionamento = new Patio();

            //var veiculo = new Veiculo();
            _veiculo.Proprietario = "Fulado de Tal";
            _veiculo.Cor = "Preto";
            _veiculo.Modelo = "Carro";
            _veiculo.Placa = "abc-1234";
            _veiculo.Tipo = TipoVeiculo.Automovel;

            _patio.RegistrarEntradaVeiculo(_veiculo);
            _patio.RegistrarSaidaVeiculo(_veiculo.Placa);



            var faturamento = _patio.TotalFaturado();



            Assert.Equal(2, faturamento);
        }

        [Theory] //permite fazer testes com parametros usando o InlineData
        [InlineData("Fulano de Tal", "ABC-1234", "Preto", "Carro")]
        [InlineData("Fulano de Tal Filho", "BCD-4321", "Branco", "Carro")]
        [InlineData("Fulano de Tal Primo", "GEF-9876", "Vermelho", "Moto")]
        public void Teste_Metodo_Total_Faturado_Com_Varios_Veiculos(string proprietario, string placa, string cor, string modelo)
        {
            //var estacionamento = new Patio();

            //var veiculo = new Veiculo();
            _veiculo.Proprietario = proprietario;
            _veiculo.Placa = placa;
            _veiculo.Cor = cor;
            _veiculo.Modelo = modelo;

            _patio.RegistrarEntradaVeiculo(_veiculo);
            _patio.RegistrarSaidaVeiculo(_veiculo.Placa);



            var faturamento = _patio.TotalFaturado();



            Assert.Equal(2, faturamento);
        }

        [Theory] //permite fazer testes com parametros usando o InlineData
        [InlineData("Fulano de Tal", "ABC-1234", "Preto", "Carro")]
        public void Teste_Metodo_Pesquisa_Veiculo_com_Placa_e_IdTicket(string proprietario, string placa, string cor, string modelo)
        {
            //var estacionamento = new Patio();

            //var veiculo = new Veiculo();
            _veiculo.Proprietario = proprietario;
            _veiculo.Placa = placa;
            _veiculo.Cor = cor;
            _veiculo.Modelo = modelo;

            _patio.RegistrarEntradaVeiculo(_veiculo);



            var consultado = _patio.PesquisaVeiculo(placa, _veiculo.IdTicket);



            Assert.Equal(placa, consultado.Placa); //placa
            Assert.Equal(_veiculo.IdTicket, consultado.IdTicket); //idTicket
        }

        [Fact]
        public void Teste_Metodo_Alterar_Dados_Veiculo_Alterando_Placa()
        {
            //var estacionamento = new Patio();

            //var veiculo = new Veiculo();
            _veiculo.Proprietario = "Fulano";
            _veiculo.Placa = "ABC-1234";
            _veiculo.Cor = "Preto";
            _veiculo.Modelo = "Carro";
            _veiculo.Tipo = TipoVeiculo.Automovel;

            _patio.RegistrarEntradaVeiculo(_veiculo);

            var veiculoAlterado = new Veiculo
            {
                Proprietario = "Fulano",
                Placa = "ABC-1234",
                Cor = "Branco", //alteração
                Modelo = "Carro",
            };



            var alterado = _patio.AlterarDadosVeiculo(veiculoAlterado);



            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            saidaConsoleTeste.WriteLine("Executando o dispose");
        }
    }
}
