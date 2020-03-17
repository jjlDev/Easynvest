using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TesteEasynvest.Domain.Interfaces;
using TesteEasynvest.Domain.Model;
using TesteEasynvest.Infra;
using TesteEasynvest.Service;

namespace TesteEasynvest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            //adção das injeções de dependencia
            services.AddControllers();
            services.AddTransient<IInvestimentoService, InvestimentoService>();
            services.AddTransient<HttpClient>();
            services.AddTransient<List<IInvestimento>>();
            services.AddTransient<Carteira>();
            services.AddTransient<HttpServiceAgent>();

            
            services.AddMemoryCache();


        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
