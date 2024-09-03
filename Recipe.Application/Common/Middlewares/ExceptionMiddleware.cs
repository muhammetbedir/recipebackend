using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Recipe.Common.Exceptions;

namespace Recipe.Common.Middlewares
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
            catch (RecipeException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext httpContext, RecipeException ex)
        {

            httpContext.Response.ContentType = "application/json";

            httpContext.Response.StatusCode = ex.Code;
            //todo column name will be added
            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = ex.Message,
                Code = ex.Code
            }));
        }
    }
    public static class ExceptionMiddlewareMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
