using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;

namespace Recipe.Common.Middlewares
{
    public class UnauthorizeResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public UnauthorizeResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == (int)System.Net.HttpStatusCode.Unauthorized)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    StatusCode = (int)System.Net.HttpStatusCode.Unauthorized,
                    Message = "Token Validation Has Failed. Request Access Denied",
                }));
            }
        }
    }
    public static class UnauthorizeResponseMiddlewareExtensions
    {
        public static IApplicationBuilder UseUnauthorizeResponse(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UnauthorizeResponseMiddleware>();
        }
    }
}
