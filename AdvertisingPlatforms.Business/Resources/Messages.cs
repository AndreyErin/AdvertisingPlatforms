using System.Reflection;
using System.Resources;

namespace AdvertisingPlatforms.Business.Resources
{
    /// <summary>
    /// Сlass for working with message resources.
    /// </summary>
    public static class Messages
    {
        private static ResourceManager _errorManager;
        private static ResourceManager _informationManager;

        static Messages()
        {
            _errorManager = new ResourceManager("AdvertisingPlatforms.Business.Resources.ErrorMessages", Assembly.GetExecutingAssembly());
            _informationManager = new ResourceManager("AdvertisingPlatforms.Business.Resources.InformationMessages", Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Messages for errors.
        /// </summary>
        public static class Error
        {
            public static string NoCorrectFileData  => _errorManager.GetString("NoCorrectFileData") ?? "";
            public static string InvalidFile => _errorManager.GetString("InvalidFile") ?? "";

            public static string NotFound => _errorManager.GetString("NotFound") ?? "";
        }

        /// <summary>
        /// Messages for information.
        /// </summary>
        public static class Information 
        {
            public static string UpdateDatabase => _informationManager.GetString("UpdateDatabase") ?? "";
        }
    }
}
