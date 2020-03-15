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

        public decimal Rentabilidade() => (capitalAtual - capitalInvestido);

        
        public decimal CalcularIR() => Rentabilidade() * Convert.ToDecimal(0.05);

        public decimal RetornarTotal() => this.capitalAtual;


        public string RetornarNome() => nome;

        public decimal RetornarValorInvestido() => capitalInvestido;

        public DateTime RetornarVencimento() => vencimento;

        public decimal CalcularResgate()
        {

            decimal resgate = 0;

            int diasParaVencimento = (this.vencimento - this.dataOperacao).Days;
            

            int posicaoAtual =(DateTime.Now - this.dataOperacao).Days;
            DateTime dataAtual = DateTime.Now; 


            if (dataAtual >= vencimento.AddMonths(-3) && dataAtual <= vencimento)
            {
                //estar no periodo de tres meses para vencer
                //Investimento com até 3 meses para vencer: Perde 6% do valor investido
                resgate = this.capitalAtual - (capitalAtual * Convert.ToDecimal(0.06));
            }
            else if (posicaoAtual > (diasParaVencimento / 2))
            {
                //Investimento com mais da metade do tempo em custódia: Perde 15% do valor investido
                resgate = this.capitalAtual - (capitalAtual * Convert.ToDecimal(0.15));
            }
            else
            {
                //Outros: Perde 30% do valor investido
                resgate = this.capitalAtual - (capitalAtual * Convert.ToDecimal(0.30));
            }

            return resgate;



        }
    }
}
