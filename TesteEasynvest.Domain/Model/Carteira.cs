using System;
using System.Collections.Generic;
using System.Text;
using TesteEasynvest.Domain.Interfaces;

namespace TesteEasynvest.Domain.Model
{
    public class Carteira
    {
        public decimal ValorTotal { get => this.valorTotal(); }
        public List<IInvestimento> investimentos { get; set; }
       
        //atraves da abstração dos investimentos
        //varremos todos os objetos para fazer a somatoria dos totais.
        //com essa abstração quando vier novos investimentos só sera preciso implementar 
        //a interface IInvestimento e funcionara normalmente sem precisar alterar a regra do calculo
        private decimal valorTotal()
        {

            decimal total = 0;
            foreach (var inv in this.investimentos)
            {
                total += inv.RetornarTotal();
            }

            return total;

        }

      
    }
}
