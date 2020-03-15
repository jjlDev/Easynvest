using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TesteEasynvest.Domain.Interfaces;
using TesteEasynvest.Domain.Model;
using TesteEasynvest.Infra;

namespace Workspace
{
    class Program
    {


        static void Main(string[] args)
        {
            DateTime dataatual = DateTime.Now;
            DateTime vencimento = DateTime.Now.AddMonths(2);

            TimeSpan resta = vencimento - dataatual;

            
            var tes = dataatual >= vencimento.AddMonths(-3) && dataatual <= vencimento;
            
        }
    }

}
