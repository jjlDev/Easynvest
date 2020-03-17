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
