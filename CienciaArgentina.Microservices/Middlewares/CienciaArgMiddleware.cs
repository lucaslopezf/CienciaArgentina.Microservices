using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CienciaArgentina.Microservices.Middlewares
{
    public class CienciaArgMiddleware
    {
        private readonly RequestDelegate _next;

        public CienciaArgMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            Debug.WriteLine($"Oh, it's working CienciaArgMiddleware");

            // Call the next middleware delegate in the pipeline 
            await _next.Invoke(httpContext);
        }
    }
}
