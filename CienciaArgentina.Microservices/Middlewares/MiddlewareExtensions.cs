using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CienciaArgentina.Microservices.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCienciaArgMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CienciaArgMiddleware>();
        }
    }
}
