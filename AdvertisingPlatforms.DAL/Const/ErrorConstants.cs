namespace AdvertisingPlatforms.DAL.Const
{
    /// <summary>
    /// Messages for errors.
    /// </summary>
    public static class ErrorConstants
    {
        public const string Error = "Error.";
        public const string NoCorrectFileData = "File does not contain correct data.";
        public const string NotFound = "Data not found.";
        public const string ReadRepository = "Couldn't read repository data.";
        public const string WriteRepository = "Couldn't write data in repository.";
        public const string EntityNotFound = "Entity not found.";
        public const string Argument = "Invalid data received.";
        public const string ServiceGetData = "Couldn't get data from the service.";
        public const string ServiceReplaceRepository = "The repository data could not be overwritten.";
        public const string NoDataFile = "File does not contain data.";
        public const string FileNoHaveSplitter = "File does not contain the necessary delimiters.";
        public const string FileHaveShortData = "File contains less than 5 characters.";
        public const string ServerError = "Server error.";
    }
}
