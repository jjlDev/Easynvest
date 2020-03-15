using System;
using System.Collections.Generic;
using System.Text;
using TesteEasynvest.Domain.Interfaces;

namespace TesteEasynvest.Domain.Model
{
    public class TesouroDireto : IInvestimento 
    {

        public decimal valorInvestido { get; set; }
        public decimal valorTotal { get; set; }
        public DateTime vencimento { get; set; }
        public DateTime dataDeCompra { get; set; }
        public double iof { get; set; }
        public string indice { get; set; }
        public string tipo { get; set; }
        public string nome { get; set; }

        public decimal Rentabilidade() => (valorTotal - valorInvestido);

        public decimal CalcularIR() => Rentabilidade() * Convert.ToDecimal(0.10);

        public decimal RetornarTotal() => valorTotal;
        
        public string RetornarNome() => nome;

        public decimal RetornarValorInvestido() => valorInvestido;

        public DateTime RetornarVencimento() => vencimento;

        public decimal CalcularResgate()
        {

            decimal resgate = 0;

            int diasParaVencimento = (this.vencimento - this.dataDeCompra).Days;
            int mesesParaVencimento = (this.vencimento.Month - this.dataDeCompra.Month);
            
            int posicaoAtual = (DateTime.Now - this.dataDeCompra).Days;
            int mesAtual = DateTime.Now.Month;


            if (mesAtual <= mesesParaVencimento && mesAtual >= mesesParaVencimento - 3)
            {
                //estar no periodo de tres meses para vencer
                //Investimento com até 3 meses para vencer: Perde 6% do valor investido
                resgate = this.valorTotal - (valorTotal * Convert.ToDecimal(0.06));
            }
            else if (posicaoAtual > (diasParaVencimento / 2))
            {
                //Investimento com mais da metade do tempo em custódia: Perde 15% do valor investido
                resgate = this.valorTotal - (valorTotal * Convert.ToDecimal(0.15));
            }
            else 
            {
                //Outros: Perde 30% do valor investido
                resgate = this.valorTotal - (valorTotal * Convert.ToDecimal(0.30));
            }

            return resgate;



        }
    }
}
