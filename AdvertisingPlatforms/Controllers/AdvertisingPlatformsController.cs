using AdvertisingPlatforms.Business.Resources;
using AdvertisingPlatforms.Business.Models;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using Microsoft.AspNetCore.Mvc;
using AdvertisingPlatforms.Domain.Models;


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
        public async Task<IActionResult> ReplaceAdvertisingData(IFormFile file)
        {
            var data = await _reader.GetDataFromFileAsync(file);

            //It will need to be moved to general error checking.
            //Exeption in FileReader
            if (data == null)
            {
                return new StatusCodeResult(500);
            }

            //It will need to be moved to general error checking.
            //Exeption in FileReader
            if (data?.AdvertisingPlatforms.Count() == 0)
            {
                var errorResult = new ResponseModel(false, Messages.Error.NoCorrectFileData);
                return UnprocessableEntity(errorResult);
            }

            //update databases for services
            var countAdvertisingPlatforms = _advertisitngPlatformsService.ReplaceRepository(data.AdvertisingPlatforms);
            var countLocations = _locationsService.ReplaceRepository(data.Locations);

            AdvertisingUpdateResult advertisingUpdateResult = new(countAdvertisingPlatforms, countLocations);

            var message = new ResponseModel(true, Messages.Information.UpdateDatabase, advertisingUpdateResult);

            return Ok(message);
        }
    }
}
