using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TesteEasynvest.Domain.Model;

namespace TesteEasynvest.Domain.Responses
{
   public  class RendaFixaResponse
    {
        //jsonproperty indicado para leitura correta do retorno da api (mocky)
        [JsonProperty(PropertyName = "lcis")]
        public List<RendaFixa> RendaFixa { get; set; }
    }
}
