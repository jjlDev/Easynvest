using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TesteEasynvest.Domain.Model;

namespace TesteEasynvest.Domain.Responses
{
    public class TesouroDiretoResponse
    {
        //jsonproperty indicado para leitura correta do retorno da api (mocky)
        [JsonProperty(PropertyName = "tds")]
        public List<TesouroDireto> TesouroDireto { get; set; }
    }
}
