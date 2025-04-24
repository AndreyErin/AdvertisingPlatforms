using AdvertisingPlatforms.Business.Resources;
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


        /// <summary>
        /// Get advertising for location.
        /// </summary>
        /// <param name="location">Location to search for advertising platforms.</param>
        [HttpGet("{*location}")]
        [ProducesResponseType<ResponseApi<AdvertisingNullResult>>(StatusCodes.Status404NotFound)]
        [ProducesResponseType<ResponseApi<AdvertisingsResult>>(StatusCodes.Status200OK)]
        public IActionResult GetAdvertisingPlatforms(string location)
        {
            string locationName = prefLocationName + location;
            var advertisings = _advertisitngPlatformsService.GetAdvertisingPlatformsForLocation(locationName);

            if (advertisings.Count() == 0)
            {
                var notFoundResult = new ResponseApi<AdvertisingNullResult>(false, Messages.Error.NotFound);
                return NotFound(notFoundResult);
            }
            else
            {
                AdvertisingsResult advertisingsResult = new(advertisings);
                var okResult = new ResponseApi<AdvertisingsResult>(true, "", advertisingsResult);
                return Ok(okResult);
            }               
        }

        /// <summary>
        /// Replace the advertising data.
        /// </summary>
        /// <param name="file">File with new advertising data.</param>
        [HttpPost]
        [ProducesResponseType<ResponseApi<AdvertisingNullResult>>(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType<ResponseApi<AdvertisingUpdateResult>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ReplaceAdvertisingData(IFormFile file)
        {
            var data = await _reader.GetDataFromFileAsync(file);

            //It will need to be moved to general error checking.
            //Exeption in FileReader
            //if (data == null)
            //{
            //    return new StatusCodeResult(500);
            //}

            //It will need to be moved to general error checking.
            //Exeption in FileReader
            if (data?.AdvertisingPlatforms.Count() == 0)
            {
                var errorResult = new ResponseApi<AdvertisingNullResult>(false, Messages.Error.NoCorrectFileData);
                return UnprocessableEntity(errorResult);
            }

            //update databases for services
            var countAdvertisingPlatforms = _advertisitngPlatformsService.ReplaceRepository(data.AdvertisingPlatforms);
            var countLocations = _locationsService.ReplaceRepository(data.Locations);

            AdvertisingUpdateResult advertisingUpdateResult = new(countAdvertisingPlatforms, countLocations);

            var okResult = new ResponseApi<AdvertisingUpdateResult>(true, Messages.Information.UpdateDatabase, advertisingUpdateResult);

            return Ok(okResult);
        }
    }
}
