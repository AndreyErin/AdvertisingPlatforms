using System.Text.RegularExpressions;
using AdvertisingPlatforms.DAL.Resources;
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
        /// <returns>(True + null) or (false + error).</returns>
        public (bool result, string? error) IsValidAdvertisingData(string? data)
        {
            if(string.IsNullOrEmpty(data))
                return (false, Messages.Error.NoDataFile);

            if (!data.Contains(Splitter))
                return (false, Messages.Error.FileNoHaveSplitter);

            if(data.Length < 5)
                return (false, Messages.Error.FileHaveShortData);

            if(Regex.Matches(data, @"\r\n").Count == 0 &&
               !Regex.IsMatch(data, @"^[А-Яа-я.\- ]+:[A-Za-z,\/]+$"))
                return (false, Messages.Error.NoCorrectFileData);

            return (true, null);
        }
    }
}
