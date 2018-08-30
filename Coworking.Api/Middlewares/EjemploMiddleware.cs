using Coworking.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Builder
{
    public static class EjemploMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseEjemploMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<Ejemplo>();

            return builder;
        }

    }
}
