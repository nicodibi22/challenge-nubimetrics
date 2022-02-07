using challenge_nubimetrics_services.Implementations;
using challenge_nubimetrics_services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using challenge_nubimetrics_data.Repositories;
using challenge_nubimetrics_data.Implementations;
using Microsoft.AspNetCore.Identity;
using challenge_nubimetrics_data.Utils;
using challenge_nubimetrics.Middlewares;

namespace challenge_nubimetrics
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
            services.AddControllers().AddNewtonsoftJson(x =>
                x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            // Esto debiera sacarse y ponerse en una clase que lo resuelva
            #region Dependency Injection
            services.AddScoped<PaisService, PaisImplementation>();
            services.AddScoped<BusquedaService, BusquedaImplementation>();
            services.AddScoped<MonedaService, MonedaImplementation>();
            services.AddScoped<MonedaRepository, MonedaFileImplementation>();
            services.AddScoped<UsuarioService, challenge_nubimetrics_services.Implementations.UsuarioImplementation>();
            services.AddScoped<UsuarioRepository, challenge_nubimetrics_data.Implementations.UsuarioImplementation>();
            services.AddScoped<IHelper, NHibernateHelper>();
            services.AddScoped<DBStrategy, MSSQLStrategy>();
            services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();
            app.UseHttpsRedirection();
            
            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
