using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEasynvest.Domain.Responses
{
    public class InvestimentosResponse
    {

        public InvestimentosResponse()
        {
            investimentos = new List<InfoInvestimentosResponse>();
        }
        public decimal valorTotal { get; set; }

        [JsonProperty(PropertyName= "investimentos")]
        public List<InfoInvestimentosResponse> investimentos { get; set; }
         
    }
}

 