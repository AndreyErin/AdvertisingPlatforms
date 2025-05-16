using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Domain.Models;


namespace AdvertisingPlatforms.Business.Services.FileHandlingServices
{
    /// <summary>
    /// Reader for files containing information about advertising platforms.
    /// </summary>
    public class FileReader: IFileReader
    {
        private readonly IFileValidator _validator;
        private readonly IFileParser _parser;

        public FileReader(IFileValidator validator, IFileParser parser)
        {
            _validator = validator;
            _parser = parser;
        }

        /// <summary>
        /// Get data from file.
        /// </summary>
        /// <param name="file">File with data.</param>
        /// <returns>Data or null.</returns>
        /// <exception cref="BusinessException"></exception>
        public async Task<AdvertisingInformation?> GetDataFromFileAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            using StreamReader streamReader = new(file.OpenReadStream());

            var fileContent = await streamReader.ReadToEndAsync();

            var isValid = _validator.IsValidAdvertisingData(fileContent);

            if (!isValid.result)
            {
                throw new BusinessException(isValid.error!);                
            }

            AdvertisingInformation result = _parser.GetParseData(fileContent);

            if (result.AdvertisingPlatforms.Count == 0 ||
                result.Locations.Count == 0) 
            {
                throw new BusinessException(ErrorConstants.NoCorrectFileData);
            }

            return result;
        }
    }
}
