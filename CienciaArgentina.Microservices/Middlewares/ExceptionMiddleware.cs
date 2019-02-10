using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CienciaArgentina.Microservices.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CienciaArgentina.Microservices.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            try
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/json";

                var guid = Guid.NewGuid();
                const string message = "Error en la aplicación";
                var result = JsonConvert.SerializeObject(new { id = guid, error = message });

                if (exception == null) return context.Response.WriteAsync(result);
                
                //Storage!
                exception.Log(context, guid);
                result = JsonConvert.SerializeObject(new { id = guid, error = exception.Message });
                return context.Response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                //En la b por mil
                Console.WriteLine(ex.Message);
                return context.Response.WriteAsync("Fatal error del fatal error");
            }
        }
    }
}
