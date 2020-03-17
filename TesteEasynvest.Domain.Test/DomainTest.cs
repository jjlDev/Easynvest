using System;
using TesteEasynvest.Domain.Model;
using Xunit;

namespace TesteEasynvest.Domain.Test
{
    public class DomainTest
    {
        

        [Fact]
        public void Retornar_Valor_De_Resgate()
        {

            DateTime dataVencimento = Convert.ToDateTime("17/03/2020 00:00:00");
            DateTime dataOperacao = Convert.ToDateTime("17/03/2022 00:00:00");
            decimal valorTotal = 2000.00M;
            //Act
            var resultadoCalculo = CalculosInvestimentos.CalcularResgate(dataVencimento, dataOperacao,valorTotal);


            Assert.Equal(Convert.ToDecimal(1400.0), resultadoCalculo);


        }
    }
}
