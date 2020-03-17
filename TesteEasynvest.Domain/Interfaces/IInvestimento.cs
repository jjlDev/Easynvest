using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEasynvest.Domain.Interfaces
{
    public interface IInvestimento
    {

        //interface com os metodos que compoem os investimentos
        //no final usamos esses metodos para fazer calculos e gerar o retorno da api
        public decimal CalcularIR();
        public decimal Rentabilidade();
        public decimal RetornarTotal();
        public decimal RetornarValorInvestido();
        public string RetornarNome();
        public DateTime RetornarVencimento();
        public decimal CalcularResgate();


    }
}
