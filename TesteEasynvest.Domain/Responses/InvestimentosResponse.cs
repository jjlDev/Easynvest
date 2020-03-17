using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEasynvest.Domain.Responses
{
    public class InvestimentosResponse
    {
        //este objeto e utilizado para retornar por completo os dados dos investimentos da nossa api
        public InvestimentosResponse()
        {
            investimentos = new List<InfoInvestimentosResponse>();
        }
        public decimal valorTotal { get; set; }

        [JsonProperty(PropertyName= "investimentos")]
        public List<InfoInvestimentosResponse> investimentos { get; set; }
         
    }
}

 