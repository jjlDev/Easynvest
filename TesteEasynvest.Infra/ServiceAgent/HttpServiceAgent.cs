using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TesteEasynvest.Domain.Interfaces;
using TesteEasynvest.Domain.Responses;

namespace TesteEasynvest.Infra
{
    public class HttpServiceAgent
    {

        List<IInvestimento> investimentos;
        private static HttpClient httpClient;

        public HttpServiceAgent(List<IInvestimento> _investimentos, HttpClient _httpClient)
        {
            investimentos = _investimentos;
            httpClient = _httpClient;
        }


        public async System.Threading.Tasks.Task<List<IInvestimento>> ObtemInvestimentosAsync()
        {

            try
            {
                //requisito os dados da api onde estam os dados dos investimentos
                HttpResponseMessage responseTesouro = await httpClient.GetAsync("http://www.mocky.io/v2/5e3428203000006b00d9632a");
                HttpResponseMessage responseRenda = await httpClient.GetAsync("http://www.mocky.io/v2/5e3429a33000008c00d96336");
                HttpResponseMessage responseFundos = await httpClient.GetAsync("http://www.mocky.io/v2/5e342ab33000008c00d96342");

                //retorno todos os conteudos do request
                string responseFundosText = await responseFundos.Content.ReadAsStringAsync();
                string responseTesouroText = await responseTesouro.Content.ReadAsStringAsync();
                string responseRendaText = await responseRenda.Content.ReadAsStringAsync();

                //adiciono no objeto de investimentos 
                //como todos os objetos implementam a interface IInvestimentos
                //tratamos com a abstração e utulizamos a mesma lista de objetos
                investimentos.AddRange(JsonConvert.DeserializeObject<FundosResponse>(responseFundosText).Fundos);
                investimentos.AddRange(JsonConvert.DeserializeObject<TesouroDiretoResponse>(responseTesouroText).TesouroDireto);
                investimentos.AddRange(JsonConvert.DeserializeObject<RendaFixaResponse>(responseRendaText).RendaFixa);

            }
            catch (Exception ex)
            {

                    throw new Exception(ex.Message);
            }
            


            return investimentos;
        }

    }
}
