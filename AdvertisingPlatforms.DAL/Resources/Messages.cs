using System.Reflection;
using System.Resources;

namespace AdvertisingPlatforms.DAL.Resources
{
    /// <summary>
    /// Class for working with message resources.
    /// </summary>
    public static class Messages
    {
        private static readonly ResourceManager ErrorManager;
        private static readonly ResourceManager InformationManager;

        static Messages()
        {
            ErrorManager = new ResourceManager("AdvertisingPlatforms.DAL.Resources.ErrorMessages", Assembly.GetExecutingAssembly());
            InformationManager = new ResourceManager("AdvertisingPlatforms.DAL.Resources.InformationMessages", Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Messages for errors.
        /// </summary>
        public static class Error
        {
            public static string NoCorrectFileData  => ErrorManager.GetString("NoCorrectFileData") ?? "";
            public static string InvalidFile => ErrorManager.GetString("InvalidFile") ?? "";
            public static string NotFound => ErrorManager.GetString("NotFound") ?? "";
            public static string ConfigRead => ErrorManager.GetString("ConfigRead") ?? "";
            public static string ReadRepository => ErrorManager.GetString("ReadRepository") ?? "";
            public static string WriteRepository => ErrorManager.GetString("WriteRepository") ?? "";
            public static string EntityNotFound => ErrorManager.GetString("EntityNotFound") ?? "";
            public static string Argument => ErrorManager.GetString("Argument") ?? "";
            public static string AdvertisingPlatformsServiceGetData => ErrorManager.GetString("AdvertisingPlatformsServiceGetData") ?? "";
            public static string AdvertisingPlatformsServiceReplaceRepository => ErrorManager.GetString("AdvertisingPlatformsServiceReplaceRepository") ?? "";
            public static string LocationsServiceGetData => ErrorManager.GetString("LocationsServiceGetData") ?? "";
            public static string LocationsServiceReplaceRepository => ErrorManager.GetString("LocationsServiceReplaceRepository") ?? "";
            public static string NoDataFile => ErrorManager.GetString("NoDataFile") ?? "";
            public static string FileNoHaveSplitter => ErrorManager.GetString("FileNoHaveSplitter") ?? "";
            public static string FileHaveShortData => ErrorManager.GetString("FileHaveShortData") ?? "";
            public static string ServerError => ErrorManager.GetString("ServerError") ?? "";

        }

        /// <summary>
        /// Messages for information.
        /// </summary>
        public static class Information 
        {
            public static string UpdateDatabase => InformationManager.GetString("UpdateDatabase") ?? "";
            public static string Fail => InformationManager.GetString("Fail") ?? "";
        }
    }
}
