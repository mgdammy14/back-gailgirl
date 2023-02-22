using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiBusinessLogic.Implementation;
using ApiBusinessLogic.Implementation.Clients;
using ApiBusinessLogic.Implementation.Services;
using ApiBusinessLogic.Interfaces.Clients;
using ApiBusinessLogic.Interfaces.General;
using ApiBusinessLogic.Interfaces.Services;
using ApiDataAccess.General;
using ApiUnitOfWork.General;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiCore
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
            services.AddControllers();

            services.AddScoped<IClientLogic, ClientLogic>();
            services.AddScoped<IServiceLogic, ServiceLogic>();

            services.AddScoped<IExceptionCustomizedLogic, ExceptionCustomizedLogic>();

            services.AddSingleton<IUnitOfWork>(option => new UnitOfWork(
                    Configuration.GetConnectionString("develop-azure")
                ));

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Backend Gail Girl", Version = "v1" });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend Gail Girl"));
        }
    }
}
