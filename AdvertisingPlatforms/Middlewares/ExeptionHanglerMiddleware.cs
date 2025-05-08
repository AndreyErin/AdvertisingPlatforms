using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.DAL.Resources;

namespace AdvertisingPlatforms.Middlewares
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
            var message = exception.Message;
            var statusCode = 0;

            switch (exception)
            {
                case AdvertisingPlatformsControllerExeption:
                    if (exception.Message == Messages.Error.NotFound)
                        statusCode = 404;
                    if (exception.Message == Messages.Error.NoCorrectFileData)
                        statusCode = 422;
                    break;
                case EntityNotFoundExeption:
                    statusCode = 404;
                    break;
                case InvalidFileDataExeption:
                    statusCode = 422;
                    break;
                default:
                    statusCode = 500;
                    message = Messages.Error.ServerError;
                    break;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;
            await httpContext.Response.WriteAsync($"{Messages.Information.Fail} {message}");
        }
    }
}
