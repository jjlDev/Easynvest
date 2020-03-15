using System;
using System.Collections.Generic;
using System.Text;
using TesteEasynvest.Domain.Interfaces;

namespace TesteEasynvest.Domain.Model
{
    public class RendaFixa : IInvestimento
    {

        public decimal capitalInvestido { get; set; }
        public decimal capitalAtual { get; set; }
        public decimal quantidade { get; set; }
        public DateTime vencimento { get; set; }
        public decimal iof { get; set; }
        public decimal outrasTaxas { get; set; }
        public decimal taxas { get; set; }
        public string indice { get; set; }
        public string tipo { get; set; }
        public string nome { get; set; }
        public bool guarantidoFGC { get; set; }
        public DateTime dataOperacao { get; set; }
        public decimal precoUnitario { get; set; }
        public bool primario { get; set; }

        private double porcentagemIR = 0.05;
        public decimal Rentabilidade() => (capitalAtual - capitalInvestido);


        public decimal CalcularIR() => CalculosInvestimentos.CalcularIR(Rentabilidade(), porcentagemIR);

        public decimal RetornarTotal() => this.capitalAtual;


        public string RetornarNome() => nome;

        public decimal RetornarValorInvestido() => capitalInvestido;

        public DateTime RetornarVencimento() => vencimento;

        public decimal CalcularResgate()
        {

            return CalculosInvestimentos.CalcularResgate(this.vencimento, this.dataOperacao,this.capitalAtual);
                        
        }
    }
}
