using branef.Domain.Extensions;
using branef.Domain.Models;
using System.Net;
using System.Text.Json;

namespace branef.Api.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next, IHostEnvironment environment)
    {
        private readonly RequestDelegate _next = next;
        private readonly IHostEnvironment _environment = environment;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _environment.IsDevelopment() ?
                    new ApiError(context.Response.StatusCode.ToString(), ex.Message, ex.StackTrace?.ToString()) :
                    new ApiError(context.Response.StatusCode.ToString(), ex.Message, BusinessMessage.MSG02);

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
                var json = JsonSerializer.Serialize(response, options);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
