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
        HttpServiceAgent serviceAgent;

        public InvestimentoService(Carteira _carteira, HttpServiceAgent _serviceAgent)
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

            InvestimentosResponse investimentoResponse = new InvestimentosResponse();
            InfoInvestimentosResponse info;
            investimentoResponse.valorTotal = carteira.ValorTotal;

            foreach (var item in carteira.investimentos)
            {
                info = new InfoInvestimentosResponse();

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
