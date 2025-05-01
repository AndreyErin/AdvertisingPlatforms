using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;

namespace AdvertisingPlatforms.Business.Services.FileHandlingServices
{
    /// <summary>
    /// Validator for files.
    /// </summary>
    public class FileValidator : IFileValidator
    {
        const string Splitter = ":";

        /// <summary>
        /// Validation check.
        /// </summary>
        /// <param name="data">Data for validation.</param>
        /// <returns>True or false.</returns>
        public bool IsValidAdvertisingData(string? data)
        {
            if (data != null &&
                data.Trim().Length >= 3 &&
                data.Contains(Splitter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
