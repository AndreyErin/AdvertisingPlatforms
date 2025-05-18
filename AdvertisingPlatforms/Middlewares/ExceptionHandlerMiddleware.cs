using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Models;
using System.Net;
using System.Text.Json;

namespace AdvertisingPlatforms.Middlewares
{
    /// <summary>
    /// Middleware for exception handling.
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;

        public ExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (BusinessException ex)
            {
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception, HttpStatusCode httpStatusCode)
        {
            ExceptionInfo exceptionInfo = new (
                exception.GetType().Name,
                exception.Message,
                httpContext.Request.Path
                );

            AddDetailsForDevelopment(exception, exceptionInfo);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)httpStatusCode;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(
                    exceptionInfo,
                    new JsonSerializerOptions { WriteIndented = true }));
        }

        private void AddDetailsForDevelopment(Exception exception, ExceptionInfo exceptionInfo)
        {
            if (_environment.IsDevelopment())
            {
                exceptionInfo.StackTrace = exception.StackTrace;

                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                    exceptionInfo.InnerExceptionInfo = new(
                        exception.GetType().Name,
                        exception.Message,
                        stackTrace: exception.StackTrace
                        );

                    exceptionInfo = exceptionInfo.InnerExceptionInfo;
                }
            }
        }
    }
}
