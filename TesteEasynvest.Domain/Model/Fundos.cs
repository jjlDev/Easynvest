using System;
using System.Collections.Generic;
using System.Text;
using TesteEasynvest.Domain.Interfaces;

namespace TesteEasynvest.Domain.Model
{
    public class Fundos : IInvestimento
    {

        public decimal capitalInvestido { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime dataResgate { get; set; }
        public DateTime dataCompra { get; set; }
        public decimal iof { get; set; }
        public string nome { get; set; }
        public decimal totalTaxas { get; set; }
        public int quantity { get; set; }

        public decimal Rentabilidade() => ValorAtual - capitalInvestido;

        public decimal CalcularIR() => Rentabilidade() * Convert.ToDecimal(0.15);

        public decimal RetornarTotal() => this.ValorAtual;


        public string RetornarNome() => nome;

        public decimal RetornarValorInvestido() => capitalInvestido;

        public DateTime RetornarVencimento() => dataResgate;

        public decimal CalcularResgate()
        {

            decimal resgate = 0;

            int diasParaVencimento = (this.dataResgate - this.dataCompra).Days;
            

            int posicaoAtual = (DateTime.Now - this.dataCompra).Days;
            DateTime dataAtual = DateTime.Now;


            if (dataAtual >= dataResgate.AddMonths(-3) && dataAtual <= dataResgate)
            {
                //estar no periodo de tres meses para vencer
                //Investimento com até 3 meses para vencer: Perde 6% do valor investido
                resgate = this.ValorAtual - (ValorAtual * Convert.ToDecimal(0.06));
            }
            else if (posicaoAtual > (diasParaVencimento / 2))
            {
                //Investimento com mais da metade do tempo em custódia: Perde 15% do valor investido
                resgate = this.ValorAtual - (ValorAtual * Convert.ToDecimal(0.15));
            }
            else
            {
                //Outros: Perde 30% do valor investido
                resgate = this.ValorAtual - (ValorAtual * Convert.ToDecimal(0.30));
            }

            return resgate;



        }
    }
}
