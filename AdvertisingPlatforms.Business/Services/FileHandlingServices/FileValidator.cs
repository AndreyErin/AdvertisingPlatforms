using System.Text.RegularExpressions;
using AdvertisingPlatforms.DAL.Const;
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
                return (false, ErrorConstants.NoDataFile);

            if (!data.Contains(FileConstants.Spliter))
                return (false, ErrorConstants.FileNoHaveSplitter);

            if(data.Length < 5)
                return (false, ErrorConstants.FileHaveShortData);

            if(Regex.Matches(data, FileConstants.RowsSpliter).Count == 0 &&
               !Regex.IsMatch(data, FileConstants.RowPattern))
                return (false, ErrorConstants.NoCorrectFileData);

            return (true, null);
        }
    }
}
