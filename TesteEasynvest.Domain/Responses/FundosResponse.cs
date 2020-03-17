using System;
using System.Collections.Generic;
using System.Text;
using TesteEasynvest.Domain.Model;

namespace TesteEasynvest.Domain.Responses
{
    public class FundosResponse
    {
        //response criado para mapeamento do retorna da api
        public List<Fundos> Fundos { get; set; }
    }
}
