using AdvertisingPlatforms.DAL.Resources;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Models;
using System.Net;
using System.Text;

namespace AdvertisingPlatforms.Middlewares
{
    /// <summary>
    /// Middleware for exception handling.
    /// </summary>
    public class ExeptionHanglerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;

        public ExeptionHanglerMiddleware(RequestDelegate next, IWebHostEnvironment environment)
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
                await HandleExeptionAsync(httpContext, ex, HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExeptionAsync(httpContext, ex, HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExeptionAsync(HttpContext httpContext, Exception exception, HttpStatusCode httpStatusCode)
        {
            ExceptionInfo exceptionInfo = new (
                exception.GetType().Name,
                RuLocalization.GetLocalizedMessage(exception.Message),
                httpContext.Request.Path,
                GetDetails(exception)
                );

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)httpStatusCode;
            await httpContext.Response.WriteAsync(exceptionInfo.ToString());
        }

        private string? GetDetails(Exception exception)
        {
            if (_environment.IsDevelopment())
            {
                StringBuilder details = new();

                details.AppendLine(exception.StackTrace);

                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                    details.AppendLine(exception.Message);
                    details.AppendLine(exception.GetType().Name);
                    details.AppendLine(exception.StackTrace);
                }

                return details.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
