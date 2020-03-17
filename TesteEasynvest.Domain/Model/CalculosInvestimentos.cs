using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEasynvest.Domain.Model
{
    public static class  CalculosInvestimentos
    {
        //esta classe foi feita para auxiliar os calculos que os investimentos fazem 
        //como todos os investimentos tem os mesmos calculos mudando apenas alguns parametros de valores
        //essa classe encapsula os calculos para caso mudem algum dia, mudaremos apenas aqui.


        //calculo para valor de resgate
        public static decimal CalcularResgate(DateTime  vencimento, DateTime  dataOperacao, decimal capitalAtual)
        {

            //iniciamos a variavel qeu tera o valor final de resgate
            decimal resgate = 0;

            //pego a quantidade de dias para vencer o investimento
            int diasParaVencimento = (vencimento - dataOperacao).Days;

            //pego a posição que estamos em dias apartir da data de operação (date de compra)
            int posicaoAtual = (DateTime.Now - dataOperacao).Days;
            DateTime dataAtual = DateTime.Now;

            // se a data atual estiver entre os tres meses para vencimento efetuo o calculo de 6%
            if (dataAtual >= vencimento.AddMonths(-3) && dataAtual <= vencimento)
            {
                //estar no periodo de tres meses para vencer
                //Investimento com até 3 meses para vencer: Perde 6% do valor investido
                resgate = capitalAtual - (capitalAtual * Convert.ToDecimal(0.06));
            }
            else if (posicaoAtual > (diasParaVencimento / 2))
            {

                //Investimento com mais da metade do tempo em custódia: Perde 15% do valor investido
                resgate = capitalAtual - (capitalAtual * Convert.ToDecimal(0.15));
            }
            else
            {
                //Outros: Perde 30% do valor investido
                resgate = capitalAtual - (capitalAtual * Convert.ToDecimal(0.30));
            }

            return resgate;



        }

        //calculo do IR
        public static decimal CalcularIR(decimal rentabilidade, double porcentagem)
        {
            //calculo do IR
            return rentabilidade * Convert.ToDecimal(porcentagem);

        }

    }
}
