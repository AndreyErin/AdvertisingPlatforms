using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Domain.Models.ResponseApi;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatforms.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AdvertisingPlatformsController : Controller
    {
        private readonly IAdvertisingInLocationService _advertisingsInLocationService;
        private readonly IAdvertisingPlatformsService _advertisitngPlatformsService;
        private readonly ILocationsService _locationsService;
        private readonly IFileReader _reader;
        private const string PrefLocationName = @"/";

        public AdvertisingPlatformsController(
            IAdvertisingInLocationService advertisingsInLocationService,
            IAdvertisingPlatformsService platformsService,
            ILocationsService locationsService,
            IFileReader reader)
        {
            _advertisingsInLocationService = advertisingsInLocationService;
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
            var advertisingPlatformsForLocation = _advertisingsInLocationService.GetAdvertisingPlatformsForLocation(locationName);

            if (advertisingPlatformsForLocation is { Count: > 0 })
            {
                var okResult = new AdvertisingsResult(advertisingPlatformsForLocation);
                return Ok(okResult);
            }
            else
            {
                throw new BusinessException(ErrorConstants.NotFound);
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
                _advertisingsInLocationService.ReplaceRepository(data.AdvertisingInLocations);
                var countAdvertisingPlatforms = _advertisitngPlatformsService.ReplaceRepository(data.AdvertisingPlatforms);
                var countLocations = _locationsService.ReplaceRepository(data.Locations);

                var okResult = new AdvertisingUpdateResult(countAdvertisingPlatforms, countLocations);
                return Ok(okResult);
            }
            else
            {
                throw new BusinessException(ErrorConstants.NoCorrectFileData);
            }
        }
    }
}
