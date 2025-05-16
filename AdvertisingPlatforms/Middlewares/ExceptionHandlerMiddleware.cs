using AdvertisingPlatforms.DAL.Resources;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Models;
using System.Net;
using System.Text;
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
            string title = exception is BusinessException
                ? RuLocalization.GetLocalizedMessage(exception.Message)
                : exception.Message;

            ExceptionInfo exceptionInfo = new (
                exception.GetType().Name,
                title,
                httpContext.Request.Path,
                GetDetails(exception, httpContext)
                );

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)httpStatusCode;
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(
                    exceptionInfo,
                    new JsonSerializerOptions { WriteIndented = true }));
        }

        private List<string?>? GetDetails(Exception exception, HttpContext httpContext)
        {
            if (_environment.IsDevelopment())
            {
                List<string?> details = new();

                details.Add(exception.StackTrace);

                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;

                    var innerExceptionInfo = $"{exception.Message}\n{exception.GetType().Name}\n{exception.StackTrace}";

                    details.Add(innerExceptionInfo);
                }

                return details;
            }
            else
            {
                return null;
            }
        }
    }
}
