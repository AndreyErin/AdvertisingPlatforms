using AdvertisingPlatforms.Models;

namespace AdvertisingPlatforms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            //регистрируем наши сервисы
            builder.Services.AddSingleton<IPlatformsService, PlatformsService>();
            builder.Services.AddScoped<IReader, Reader>();

            var app = builder.Build();

            app.UseRouting();
            app.MapControllers();


            app.MapGet("/", () => "Server is run");
            app.Run();
        }
    }
}
