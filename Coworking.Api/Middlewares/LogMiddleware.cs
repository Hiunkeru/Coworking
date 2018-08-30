using Coworking.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Builder
{
    public static class LogMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseLogApplicationInsights(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<Log>();

            return builder;
        }

    }
}
