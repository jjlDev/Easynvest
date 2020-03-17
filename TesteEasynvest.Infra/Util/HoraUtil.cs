using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEasynvest.Infra.CrossCutting.Util
{
    public static class HoraUtil
    {
        public static int SegundosParaMeiaNoite()
        {
            //metodo utilizado para retornar os segundos faltantes até meia noite
            //utilizado para setar o cache
            DateTime agora = DateTime.Now;
            int horas = 0, minutos = 0, segundos = 0, totalSegundos = 0;
            horas = (24 - agora.Hour) - 1;
            minutos = (60 - agora.Minute) - 1;
            segundos = (60 - agora.Second - 1);

            totalSegundos = segundos + (minutos * 60) + (horas * 3600);

            return totalSegundos;
        }


    }
}
