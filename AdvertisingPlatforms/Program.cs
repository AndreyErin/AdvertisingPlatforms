using AdvertisingPlatforms.DAL.Repositories;
using AdvertisingPlatforms.Domain.Interfaces;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.Domain.Services;

namespace AdvertisingPlatforms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            //registering our services
            builder.Services.AddScoped<IPlatformsService, PlatformsService>();
            builder.Services.AddScoped<IReader, FileReader>();
            builder.Services.AddScoped<FileRepository<Location>, LocationsFileRepository>();
            builder.Services.AddScoped<FileRepository<Advertising>, AdvertisingsFileRepository>();


            var app = builder.Build();

            app.UseRouting();
            app.MapControllers();

            app.MapGet("/", () =>  Results.Content(
                @"<html><body>" +
                    @"<a href='/api/v1/platforms/ru'>/ru</a></br></br>" +
                    @"<a href='/api/v1/platforms/ru/msk'>/ru/msk</a></br></br>" +
                    @"<a href='/api/v1/platforms/ru/svrd/revda'>/ru/svrd/revda</a></br></br></br></br>" +

                    @"<form enctype='multipart/form-data' method='post' action='/api/v1/platforms'>" +
                        @"<input type='file' name='file' accept='text/plain' required />" +
                        @"<input type='submit' value='Send file'/>" + 
                    @"</form>" +
                @"</body></html>", "text/html"));

            app.Run();
        }
    }
}
