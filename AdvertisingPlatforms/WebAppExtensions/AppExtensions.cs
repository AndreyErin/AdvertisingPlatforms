using AdvertisingPlatforms.Middlewares;

namespace AdvertisingPlatforms.WebAppExtensions
{
    /// <summary>
    /// Extensions for web application.
    /// </summary>
    public static class AppExtensions
    {
        /// <summary>
        /// Configure web application.
        /// </summary>
        /// <param name="app">Web application.</param>
        public static void ConfigureApp(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ExeptionHanglerMiddleware>();

            app.UseRouting();
            app.MapControllers();

            app.MapGet("/", () => Results.Content(
                @"<html><body>" +
                    @"<a href='/api/v1/advertisingplatforms/ru'>/ru</a></br></br>" +
                    @"<a href='/api/v1/advertisingplatforms/ru/msk'>/ru/msk</a></br></br>" +
                    @"<a href='/api/v1/advertisingplatforms/ru/svrd/revda'>/ru/svrd/revda</a></br></br></br></br>" +

                    @"<form enctype='multipart/form-data' method='post' action='/api/v1/advertisingplatforms'>" +
                        @"<input type='file' name='file' accept='text/plain' required />" +
                        @"<input type='submit' value='Send file'/>" +
                    @"</form></br></br></br>" +
                    @"<a href='/swagger'>swagger</a>" +
                @"</body></html>", "text/html"));
        }
    }
}
