using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEasynvest.Domain.Model
{
    public static class  CalculosInvestimentos
    {



        //calculo para valor de resgate
        public static decimal CalcularResgate(DateTime  vencimento, DateTime  dataOperacao, decimal capitalAtual)
        {

            decimal resgate = 0;

            int diasParaVencimento = (vencimento - dataOperacao).Days;


            int posicaoAtual = (DateTime.Now - dataOperacao).Days;
            DateTime dataAtual = DateTime.Now;


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
            return rentabilidade* Convert.ToDecimal(porcentagem);

        }

    }
}
