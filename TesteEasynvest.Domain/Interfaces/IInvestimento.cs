using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEasynvest.Domain.Interfaces
{
    public interface IInvestimento
    {
        public decimal CalcularIR();
        public decimal Rentabilidade();

        public decimal RetornarTotal();

        public decimal RetornarValorInvestido();

        public string RetornarNome();

        public DateTime RetornarVencimento();


        public decimal CalcularResgate();


    }
}
