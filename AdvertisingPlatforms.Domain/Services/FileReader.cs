using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces;
using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Services
{
    /// <summary>
    /// Reader for files containing information about advertising platforms.
    /// </summary>
    public class FileReader: IFileReader
    {
        private IFileValidator _validator;
        private IFileParser _parser;
        public FileReader(IFileValidator validator, IFileParser parser)
        {
            _validator = validator;
            _parser = parser;
        }

        public async Task<DataFromFile?> GetDataFromFileAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            using StreamReader streamReader = new(file.OpenReadStream());

            var fileContent = await streamReader.ReadToEndAsync();

            if (!_validator.IsValid(fileContent))
            {
                throw new InvalidFileDataExeption("Некорректный файл.");                
            }

            DataFromFile result = _parser.GetParsedData(fileContent);

            if (result.AdvertisingPlatforms.Count == 0 ||
                result.Locations.Count == 0) 
            {
                throw new InvalidFileDataExeption("Файл прочитан. В файле нет корректных данных.");
            }

            return result;
        }
    }
}
