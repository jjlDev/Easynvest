using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEasynvest.Domain.Responses
{
    
    public class InfoInvestimentosResponse
    {

        public string nome { get; set; }
        public decimal valorInvestido { get; set; }
        public decimal valorTotal { get; set; }
        public DateTime vencimento { get; set; }
        public decimal Ir { get; set; }
        public decimal valorResgate { get; set; }
    }
}
