using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Coworking.Api.Config;
using Coworking.Api.Configuration;
using Coworking.Api.CrossCutting.Register;
using Coworking.Api.DataAccess;
using Coworking.Api.DataAccess.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace Coworking.Api
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

            services.AddTransient<ICoworkingDBContext, CoworkingDBContext>();
            services.AddDbContext<CoworkingDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataBaseConnection")));
            services.AddApplicationInsightsTelemetry(Configuration);

            IoCRegister.AddRegistration(services);
            SwaggerConfig.AddRegistration(services);

            services.AddAuthentication("Bearer")
            .AddIdentityServerAuthentication(options =>
            {
                options.Authority = "https://coworkingidentity.azurewebsites.net/";
                options.RequireHttpsMetadata = false;
                options.ApiName = "api1";
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            SwaggerConfig.AddRegistration(app);

            app.UseEjemploMiddleware();
            app.UseLogApplicationInsights();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
