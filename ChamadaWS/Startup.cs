using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChamadaWS.Models;
using ChamadaWS.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.EntityFrameworkCore.Extensions;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ChamadaWS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //nome:fabws user:root senha:v0DKKhflJ5uS host:sql169.main-hosting.eu
            //meuip: 179.225.173.150
            services.AddDbContext<WSDbContext>(options =>           
            options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAlunoRepositorio, AlunoRepositorio>();
            services.AddTransient<IFrequenciaRepositorio, FrequenciaRepositorio>();
            services.AddTransient<ICalendarioRepositorio, CalendarioRepositorio>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
