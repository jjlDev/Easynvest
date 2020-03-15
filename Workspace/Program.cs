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
            Investimentos carteira = new Investimentos();
            List<IInvestimento> investimentos = new List<IInvestimento>();

            HttpClient client = new HttpClient();

            InvestimentosServiceAgent agent = new InvestimentosServiceAgent(investimentos, client);

            var teste = agent.ObtemInvestimentosAsync();
            carteira.investimentos = teste.Result;

            Console.ReadKey();

        }
    }

}
