using System;
using TesteEasynvest.Domain.Interfaces;
using TesteEasynvest.Domain.Model;
using TesteEasynvest.Domain.Responses;
using TesteEasynvest.Infra;

namespace TesteEasynvest.Service
{
    public class InvestimentoService : IInvestimentoService

    {
        Carteira carteira;
        IHttpServiceAgent serviceAgent;

        public InvestimentoService(Carteira _carteira, IHttpServiceAgent _serviceAgent)
        {
            carteira = _carteira;
            serviceAgent = _serviceAgent;

        }


        public async System.Threading.Tasks.Task<InvestimentosResponse> RetornarInvestimentosAsync()
        {

            InvestimentosResponse response = new InvestimentosResponse();

            carteira.investimentos = await serviceAgent.ObtemInvestimentosAsync();

            
            response = mapInvestimentos(carteira);
            return response;


        }

        private InvestimentosResponse mapInvestimentos(Carteira carteira)
        {
            //este mapeamento é utilizado para gerar o objeto de retorno totalmente formatado
            //e apartado de regra de negocio do dominio
            
            InvestimentosResponse investimentoResponse = new InvestimentosResponse();
            InfoInvestimentosResponse info;
            investimentoResponse.valorTotal = carteira.ValorTotal;

            foreach (var item in carteira.investimentos)
            {
                info = new InfoInvestimentosResponse();
                //utilizamos a abstração da interface dos investimentos IInvestimento
                // para percorrer e armazenar as informações do investimento
                info.nome = item.RetornarNome();
                info.valorInvestido = item.RetornarValorInvestido();
                info.valorTotal = item.RetornarTotal();
                info.vencimento = item.RetornarVencimento();
                info.Ir = item.CalcularIR();
                info.valorResgate = item.CalcularResgate();

                investimentoResponse.investimentos.Add(info);
            }
            



            return investimentoResponse;

        }


    }
}
