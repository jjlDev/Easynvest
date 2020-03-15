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


        private double porcentagemIR = 0.15;
        public decimal Rentabilidade() => ValorAtual - capitalInvestido;

        public decimal CalcularIR() => CalculosInvestimentos.CalcularIR(Rentabilidade(), porcentagemIR);

        public decimal RetornarTotal() => this.ValorAtual;


        public string RetornarNome() => nome;

        public decimal RetornarValorInvestido() => capitalInvestido;

        public DateTime RetornarVencimento() => dataResgate;

        public decimal CalcularResgate()
        {

            return CalculosInvestimentos.CalcularResgate(this.dataResgate, this.dataCompra, this.ValorAtual);

        }
    }
}
