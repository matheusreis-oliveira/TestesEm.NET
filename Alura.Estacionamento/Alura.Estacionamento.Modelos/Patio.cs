using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Modelos
{
    public class Patio
    {
        private Operador _operadorPatio;
        public Patio()
        {
            Faturado = 0;
            veiculos = new List<Veiculo>();
        }
        private List<Veiculo> veiculos;
        private double faturado;
        public double Faturado { get => faturado; set => faturado = value; }
        public List<Veiculo> Veiculos { get => veiculos; set => veiculos = value; }
        public Operador OperadorPatio { get => _operadorPatio; set => _operadorPatio = value; }
        public double TotalFaturado()
        {
            return this.Faturado;
        }

        public string MostrarFaturamento()
        {
            string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}", this.TotalFaturado());
            return totalfaturado;
        }

        public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            veiculo.Ticket = this.GerarTicket(veiculo);
            this.Veiculos.Add(veiculo);
        }

        public string RegistrarSaidaVeiculo(String placa)
        {
            Veiculo encontrado = null;
            string registro = string.Empty;

            foreach (Veiculo v in this.Veiculos)
            {
                if (v.Placa == placa)
                {
                    v.HoraSaida = DateTime.Now;
                    TimeSpan tempo = v.HoraSaida - v.HoraEntrada;
                    double valorCobrado = 0;
                    if (v.Tipo == TipoVeiculo.Automovel)
                    {
                        /// o método Math.Ceiling(), aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                        /// Ex.: 0,9999 ou 0,0001 teto = 1
                        /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();
                        valorCobrado = Math.Ceiling(tempo.TotalHours) * 2;

                    }
                    else if (v.Tipo == TipoVeiculo.Motocicleta)
                    {
                        valorCobrado = Math.Ceiling(tempo.TotalHours) * 1;
                    }
                    registro = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                             "Hora de saída: {1: HH:mm:ss}\n " +
                                             "Permanência: {2: HH:mm:ss} \n " +
                                             "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida, new DateTime().Add(tempo), valorCobrado);
                    encontrado = v;
                    this.Faturado = this.Faturado + valorCobrado;
                    break;
                }

            }
            if (encontrado != null)
            {
                this.Veiculos.Remove(encontrado);
            }
            else
            {
                return "Não há veículo com a placa informada.";
            }

            return registro;
        }

        public Veiculo AlterarDadosVeiculo(Veiculo veiculoAlterado)
        {
            var veiculoTemporario = Veiculos.FirstOrDefault(v => v.Placa == veiculoAlterado.Placa);
            veiculoTemporario.AlterarDados(veiculoAlterado);
            return veiculoTemporario;
        }

        public Veiculo PesquisaVeiculo(string placa, string idTicket)
        {
            var veiculosEncontrados = Veiculos.FirstOrDefault(v => v.Placa == placa && v.IdTicket == idTicket);
            return veiculosEncontrados;
        }

        public Veiculo PesquisaVeiculoPlaca(string placa)
        {
            var veiculosEncontrados = Veiculos.FirstOrDefault(v => v.Placa == placa);
            return veiculosEncontrados;
        }

        public Veiculo PesquisaVeiculoIdTicket(string idTicket)
        {
            var veiculosEncontrados = Veiculos.FirstOrDefault(v => v.IdTicket == idTicket);
            return veiculosEncontrados;
        }

        private string GerarTicket(Veiculo veiculo)
        {
            var identificador = new Guid().ToString().Substring(0, 5);
            veiculo.IdTicket = identificador;

            var ticket = "###Ticket Estacionamento Alura###" +
                            $"Identifcador: {identificador}" +
                            $"Data/Hora de entrada: {DateTime.Now}" +
                            $"Placa do Veículo:{veiculo.Placa}" + 
                            $">>> Operador: {this.OperadorPatio.Matricula}";
            return ticket;
        }
    }
}