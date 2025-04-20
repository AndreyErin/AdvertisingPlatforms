using AdvertisingPlatforms.Domain.Interfaces;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AdvertisingPlatforms.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AdvertisingPlatformsController : Controller
    {
        private IAdvertisingPlatformsService _advertisitngPlatformsService;
        private ILocationsService _locationsService;
        private IFileReader _reader;
        private const string prefLocationName = @"/";

        public AdvertisingPlatformsController(IAdvertisingPlatformsService platformsService, ILocationsService locationsService, IFileReader reader)
        {
            _advertisitngPlatformsService = platformsService;
            _locationsService = locationsService;
            _reader = reader;
        }

        [HttpGet("{*location}")]
        public IActionResult GetAdvertisingPlatforms(string location)
        {
            string locationName = prefLocationName + location;
            var result = _advertisitngPlatformsService.GetAdvertisingPlatformsForLocation(locationName);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UploadingAndReplacingDataOfRepositoryFromFileAsync([FromForm] IFormFile file)
        {
            

            var data = await _reader.GetDataFromFileAsync(file);

            ////It will need to be moved to general error checking.
            ////Exeption in FileReader
            //if (data == null)
            //{
            //    return new StatusCodeResult(500);
            //}

            ////It will need to be moved to general error checking.
            ////Exeption in FileReader
            //if (data?.AdvertisingPlatforms.Count() == 0)
            //{
            //    return UnprocessableEntity("Файл прочитан. В файле нет корректных данных.");
            //}

            //update databases for services
            int countAdvertisingPlatforms = _advertisitngPlatformsService.ReplaceAllData(data.AdvertisingPlatforms);
            int countLocations = _locationsService.ReplaceAllData(data.Locations);

            string message = $"База успешно обновлена!\n" +
                             $"Количество рекламных площадок: {countAdvertisingPlatforms}.\n" +
                             $"Количество локаций: {countLocations}.";

            return Ok(message);

        }
    }
}
