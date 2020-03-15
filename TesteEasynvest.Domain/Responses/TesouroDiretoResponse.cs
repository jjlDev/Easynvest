using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TesteEasynvest.Domain.Model;

namespace TesteEasynvest.Domain.Responses
{
    public class TesouroDiretoResponse
    {
        [JsonProperty(PropertyName = "tds")]
        public List<TesouroDireto> TesouroDireto { get; set; }
    }
}
