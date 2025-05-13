using AdvertisingPlatforms.DAL.Resources;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using Microsoft.AspNetCore.Mvc;
using AdvertisingPlatforms.Domain.Models.ResponseApi;

namespace AdvertisingPlatforms.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AdvertisingPlatformsController : Controller
    {
        private readonly IAdvertisingPlatformsService _advertisitngPlatformsService;
        private readonly ILocationsService _locationsService;
        private readonly IFileReader _reader;
        private const string PrefLocationName = @"/";

        public AdvertisingPlatformsController(IAdvertisingPlatformsService platformsService, ILocationsService locationsService, IFileReader reader)
        {
            _advertisitngPlatformsService = platformsService;
            _locationsService = locationsService;
            _reader = reader;
        }

        /// <summary>
        /// Get advertising for location.
        /// </summary>
        /// <param name="location">Location to search for advertising platforms.</param>
        [HttpGet("{*location}")]
        [ProducesResponseType<AdvertisingsResult>(StatusCodes.Status200OK)]
        public IActionResult GetAdvertisingPlatforms(string location)
        {
            string locationName = PrefLocationName + location;
            var advertisingPlatformsForLocation = _advertisitngPlatformsService.GetAdvertisingPlatformsForLocation(locationName);

            if (advertisingPlatformsForLocation is { Count: > 0 })
            {
                var okResult = new AdvertisingsResult(advertisingPlatformsForLocation);
                return Ok(okResult);
            }
            else
            {
                throw new AdvertisingPlatformsControllerExeption(Messages.Error.NotFound);
            }               
        }

        /// <summary>
        /// Replace the advertising data.
        /// </summary>
        /// <param name="file">File with new advertising data.</param>
        [HttpPost]
        [ProducesResponseType<AdvertisingUpdateResult>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ReplaceAdvertisingData(IFormFile file)
        {
            var data = await _reader.GetDataFromFileAsync(file);

            if (data?.AdvertisingPlatforms.Count > 0)
            {
                var countAdvertisingPlatforms = _advertisitngPlatformsService.ReplaceRepository(data.AdvertisingPlatforms);
                var countLocations = _locationsService.ReplaceRepository(data.Locations);

                var okResult = new AdvertisingUpdateResult(countAdvertisingPlatforms, countLocations);
                return Ok(okResult);
            }
            else
            {
                throw new AdvertisingPlatformsControllerExeption(Messages.Error.NoCorrectFileData);
            }
        }
    }
}
