using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TesteEasynvest.Infra;

namespace TesteEasynvest.Api
{
    public class HealthCheckEasynvest : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            string retornoHealth = "Não esta respondendo:";
            bool erro = false;

            HttpClient httpClient = new HttpClient();
            

          
            //bato nas apis que consumimos para verificar se estao de pé
            var responseTesouro = await httpClient.GetAsync("http://www.mocky.io/v2/5e3428203000006b00d9632a");
            var responseRenda = await httpClient.GetAsync("http://www.mocky.io/v2/5e3429a33000008c00d96336");
            var responseFundos = await httpClient.GetAsync("http://www.mocky.io/v2/5e342ab33000008c00d96342");


            //faço a verificação uma por uma para adicionar um descritivo do erro 
            if (!responseTesouro.IsSuccessStatusCode)
            {
                retornoHealth += " Tesouro Direto";
                erro = true;
            }

            if (!responseRenda.IsSuccessStatusCode)
            {
                retornoHealth += " Renda Fixa";
                erro = true;
            }

            if (!responseFundos.IsSuccessStatusCode)
            {
                retornoHealth += " Fundos";
                erro = true;
            }

            //se nao houver erro retornamos que esta tudo ok
            if (!erro) 
            {
                retornoHealth = "Todos serviços funcionando corretamente";
                return HealthCheckResult.Healthy(retornoHealth);
            }
            else
            {
                //caso seja eprcebido o erro nas apis, retornamos um Unhealthy
                return HealthCheckResult.Unhealthy(retornoHealth);
            }
            


        }
    }
}
