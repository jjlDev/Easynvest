using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TesteEasynvest.Domain.Interfaces;
using TesteEasynvest.Domain.Model;
using TesteEasynvest.Domain.Responses;
using TesteEasynvest.Infra.CrossCutting.Util;
using TesteEasynvest.Service;

namespace TesteEasynvest.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentosController : ControllerBase
    {
        private IInvestimentoService service;
        private IMemoryCache memoryCache;
        public InvestimentosController(IInvestimentoService _service, IMemoryCache _memoryCache)
        {
            service = _service;
            memoryCache = _memoryCache;
        }

        
        // GET: api/Investimentos
        [HttpGet]
        public async Task<InvestimentosResponse> Get()
        {
            var keyCache = "investimentos_";

            InvestimentosResponse result;

            
            if (!memoryCache.TryGetValue(keyCache, out result))
            {
                var opcoesDoCache = new MemoryCacheEntryOptions()
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(HoraUtil.SegundosParaMeiaNoite())
                };
                result = await service.RetornarInvestimentosAsync();
                memoryCache.Set(keyCache, result, opcoesDoCache);
            }


            
            return result;

        }


              

       
    }
}
