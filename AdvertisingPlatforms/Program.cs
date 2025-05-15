using AdvertisingPlatforms.DAL.Configuration;
using AdvertisingPlatforms.WebAppExtensions;

namespace AdvertisingPlatforms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.ConfigureBuilder();

            var app = builder.Build();
            app.ConfigureApp();

            DbConfig.Initialize(app.Configuration);

            app.Run();
        }
    }
}
