using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteEasynvest.Domain.Interfaces;
using TesteEasynvest.Domain.Model;
using TesteEasynvest.Domain.Responses;
using TesteEasynvest.Service;

namespace TesteEasynvest.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentosController : ControllerBase
    {
        private IInvestimentoService service;
        public InvestimentosController(IInvestimentoService _service)
        {
            service = _service;
        }

        
        // GET: api/Investimentos
        [HttpGet]
        public async Task<InvestimentosResponse> Get()
        {
         var result= await service.RetornarInvestimentosAsync();
            return result;
        }

       
    }
}
