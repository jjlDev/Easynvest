using System;
using System.Net.Http;
using TesteEasynvest.Infra;
using Xunit;

namespace HttpServiceAgentTest
{


    public class HttpTest
    {


        HttpServiceAgent agent;

        public HttpTest()
        {
            agent = new HttpServiceAgent(new System.Collections.Generic.List<TesteEasynvest.Domain.Interfaces.IInvestimento>());
        }


        [Fact]
        public void Retornar_Investimentos()
        {
            // act
            var resultado = agent.ObtemInvestimentosAsync();

            //assert
            Assert.Equal(6, resultado.Result.Count);

        }
    }
}
