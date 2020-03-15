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

        private double porcentagemIR = 0.10;

        public decimal Rentabilidade() => (valorTotal - valorInvestido);

        public decimal CalcularIR() => CalculosInvestimentos.CalcularIR(Rentabilidade(), porcentagemIR);

        public decimal RetornarTotal() => valorTotal;
        
        public string RetornarNome() => nome;

        public decimal RetornarValorInvestido() => valorInvestido;

        public DateTime RetornarVencimento() => vencimento;

        public decimal CalcularResgate()
        {

            return CalculosInvestimentos.CalcularResgate(this.vencimento, this.dataDeCompra, this.valorTotal);



        }
    }
}
