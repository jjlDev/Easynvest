﻿using Newtonsoft.Json;
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
        
            DateTime agora = DateTime.Now;
            int horas = 0, minutos = 0, segundos = 0, totalSegundos = 0;
            horas = (24 - agora.Hour) - 1;
            minutos = (60 - agora.Minute) - 1;
            segundos = (60 - agora.Second - 1);

            totalSegundos = segundos + (minutos * 60) + (horas * 3600);
        }
    }

}
