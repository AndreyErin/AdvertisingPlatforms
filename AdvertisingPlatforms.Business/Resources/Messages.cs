using System.Reflection;
using System.Resources;

namespace AdvertisingPlatforms.Business.Resources
{
    public static class Messages
    {
        private static ResourceManager _errorManager;

        static Messages()
        {
            _errorManager = new ResourceManager("AdvertisingPlatforms.Business.Resources.ErrorMessages", Assembly.GetExecutingAssembly());
        }

        public static class Error
        {
            public static string NoCorrectFileData  => _errorManager.GetString("NoCorrectFileData") ?? "";
            public static string InvalidFile => _errorManager.GetString("InvalidFile") ?? "";
        }

        public static class Information 
        {

        }
    }
}
