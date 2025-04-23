using AdvertisingPlatforms.ServiceCollection;

namespace AdvertisingPlatforms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();          
            
            builder.Services.AddAdvertisingServices();
            builder.Services.AddRepositoryServices();
            builder.Services.AddFileServices();



            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();



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

            app.Run();
        }
    }
}
