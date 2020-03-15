using System;
using System.Collections.Generic;
using System.Text;
using TesteEasynvest.Domain.Model;
using TesteEasynvest.Domain.Responses;

namespace TesteEasynvest.Domain.Interfaces
{
    public interface IInvestimentoService
    {
        System.Threading.Tasks.Task<InvestimentosResponse> RetornarInvestimentosAsync();
    }
}
