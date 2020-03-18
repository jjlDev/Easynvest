using System;
using System.Collections.Generic;
using System.Text;

namespace TesteEasynvest.Domain.Interfaces
{
    public interface IHttpServiceAgent
    {
        System.Threading.Tasks.Task<List<IInvestimento>> ObtemInvestimentosAsync();

    }
}
