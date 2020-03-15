using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TesteEasynvest.Domain.Model;

namespace TesteEasynvest.Domain.Responses
{
   public  class RendaFixaResponse
    {
        [JsonProperty(PropertyName = "lcis")]
        public List<RendaFixa> RendaFixa { get; set; }
    }
}
