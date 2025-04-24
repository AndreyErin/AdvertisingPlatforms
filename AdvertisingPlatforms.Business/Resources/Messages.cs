using System.Reflection;
using System.Resources;

namespace AdvertisingPlatforms.Business.Resources
{
    public static class Messages
    {
        private static ResourceManager _errorManager;
        private static ResourceManager _informationManager;

        static Messages()
        {
            _errorManager = new ResourceManager("AdvertisingPlatforms.Business.Resources.ErrorMessages", Assembly.GetExecutingAssembly());
            _informationManager = new ResourceManager("AdvertisingPlatforms.Business.Resources.InformationMessages", Assembly.GetExecutingAssembly());
        }

        public static class Error
        {
            public static string NoCorrectFileData  => _errorManager.GetString("NoCorrectFileData") ?? "";
            public static string InvalidFile => _errorManager.GetString("InvalidFile") ?? "";

            public static string NotFound => _errorManager.GetString("NotFound") ?? "";
        }

        public static class Information 
        {
            public static string UpdateDatabase => _informationManager.GetString("UpdateDatabase") ?? "";
        }
    }
}
