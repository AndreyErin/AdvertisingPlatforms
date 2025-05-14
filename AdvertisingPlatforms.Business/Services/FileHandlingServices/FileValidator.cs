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
        /// <summary>
        /// Validation check.
        /// </summary>
        /// <param name="data">Data for validation.</param>
        /// <returns>(True + null) or (false + error).</returns>
        public (bool result, string? error) IsValidAdvertisingData(string? data)
        {
            if(string.IsNullOrEmpty(data))
                return (false, Messages.Error.NoDataFile);

            if (!data.Contains(Messages.FileConstants.Spliter))
                return (false, Messages.Error.FileNoHaveSplitter);

            if(data.Length < 5)
                return (false, Messages.Error.FileHaveShortData);

            if(Regex.Matches(data, Messages.FileConstants.RowsSpliter).Count == 0 &&
               !Regex.IsMatch(data, Messages.FileConstants.RowPattern))
                return (false, Messages.Error.NoCorrectFileData);

            return (true, null);
        }
    }
}
