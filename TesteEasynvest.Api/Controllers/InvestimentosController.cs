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

            //setamos a chave do cache
            var keyCache = "investimentos_";

            InvestimentosResponse result;

            //verificamos se ja existe vamor cacheado (objeto cacheado)
            if (!memoryCache.TryGetValue(keyCache, out result))
            {
                //caso nao tenha geramos um novo objeto de cache
                var opcoesDoCache = new MemoryCacheEntryOptions()
                {
                    //seto a hora de expiração do cache
                    AbsoluteExpiration = DateTime.Now.AddSeconds(HoraUtil.SegundosParaMeiaNoite())
                };
                //retornamos o objeto preenchido e inserimos no cache
                result = await service.RetornarInvestimentosAsync();
                memoryCache.Set(keyCache, result, opcoesDoCache);
            }


            // no final retornamos o objeto preenchido seja pelo cache ou pela requisição no servidor
            return result;

        }


              

       
    }
}
