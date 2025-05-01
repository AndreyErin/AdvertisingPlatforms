using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Domain.Models;


namespace AdvertisingPlatforms.Business.Services.FileHandlingServices
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

        /// <summary>
        /// Get data from file.
        /// </summary>
        /// <param name="file">File with data.</param>
        /// <returns>Return data or exeption.</returns>
        public async Task<AdvertisingInformation?> GetDataFromFileAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            using StreamReader streamReader = new(file.OpenReadStream());

            try
            {
                var fileContent = await streamReader.ReadToEndAsync();

                if (_validator.IsValidAdvertisingData(fileContent) == false)
                {
                    //Exeption
                }

                var result = _parser.GetParseData(fileContent);

                return result;
            }
            catch (ArgumentOutOfRangeException)
            {
                //Loging
                return null;
            }
            catch (ObjectDisposedException)
            {
                //Loging
                return null;
            }
            catch (InvalidOperationException)
            {
                //Loging
                return null;
            }
            catch (Exception) 
            {
                //Loging, Horrified
                //Send on
                throw;
            }
        }
    }
}
