using AdvertisingPlatforms.Domain.Exeptions;
using Microsoft.AspNetCore.Http;

namespace AdvertisingPlatforms.Domain.Middlewares
{
    /// <summary>
    /// Middleware for exception handling.
    /// </summary>
    public class ExeptionHanglerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExeptionHanglerMiddleware(RequestDelegate next)
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
                await HandleExeptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExeptionAsync(HttpContext httpContext, Exception exception)
        {
            string message = exception.Message;
            int statusCode = 0;


            switch (exception)
            {
                case InvalidFileExeption:
                    statusCode = 400;
                    break;
                case InvalidFileDataExeption:
                    statusCode = 422;
                    break;
                default:
                    statusCode = 500;
                    message = "Ошибка сервера";
                    break;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync($"что-то пошло не так. {exception.Message}.");
        }
    }
}
