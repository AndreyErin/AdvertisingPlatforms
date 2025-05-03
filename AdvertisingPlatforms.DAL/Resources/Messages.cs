using System.Reflection;
using System.Resources;

namespace AdvertisingPlatforms.DAL.Resources
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
            _errorManager = new ResourceManager("AdvertisingPlatforms.DAL.Resources.ErrorMessages", Assembly.GetExecutingAssembly());
            _informationManager = new ResourceManager("AdvertisingPlatforms.DAL.Resources.InformationMessages", Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Messages for errors.
        /// </summary>
        public static class Error
        {
            public static string NoCorrectFileData  => _errorManager.GetString("NoCorrectFileData") ?? "";
            public static string InvalidFile => _errorManager.GetString("InvalidFile") ?? "";
            public static string NotFound => _errorManager.GetString("NotFound") ?? "";
            public static string ConfigRead => _errorManager.GetString("ConfigRead") ?? "";
            public static string ReadRepository => _errorManager.GetString("ReadRepository") ?? "";
            public static string WriteRepository => _errorManager.GetString("WriteRepository") ?? "";
            public static string EntityNotFound => _errorManager.GetString("EntityNotFound") ?? "";
            public static string Argument => _errorManager.GetString("Argument") ?? "";
        }

        /// <summary>
        /// Messages for information.
        /// </summary>
        public static class Information 
        {
            public static string UpdateDatabase => _informationManager.GetString("UpdateDatabase") ?? "";
            public static string Fail => _informationManager.GetString("Fail") ?? "";
        }
    }
}
