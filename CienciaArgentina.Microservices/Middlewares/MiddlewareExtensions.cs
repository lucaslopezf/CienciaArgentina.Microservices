using Microsoft.AspNetCore.Builder;

namespace CienciaArgentina.Microservices.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
