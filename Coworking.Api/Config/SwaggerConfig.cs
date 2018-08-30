using Coworking.Api.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Coworking.Api.Config
{
    public static class SwaggerConfig
    {

        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {

            var basepath = System.AppDomain.CurrentDomain.BaseDirectory;
            var xmlPath = Path.Combine(basepath, "Coworking.Api.xml");

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Coworking API V1", Version = "v1" });
                    c.IncludeXmlComments(xmlPath);

                    c.AddSecurityDefinition("Bearer", new OAuth2Scheme
                    {
                        Type = "Bearer",
                        Flow = "password",
                        TokenUrl = Path.Combine("https://coworkingidentity.azurewebsites.net/token"),
                        // Optional scopes
                        Scopes = new Dictionary<string, string>
                        {
                            { "api1", "client" },
                        }
                    });

                    //c.OperationFilter<AuthorizationHeaderParameterOperationFilter>();

                }
            );

            return services;

        }

        public static IApplicationBuilder AddRegistration(this IApplicationBuilder app)
        {

            app.UseSwagger();

            app.UseSwaggerUI(
                c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CCoworking API V1");
                });

            return app;
        }
    }
}
