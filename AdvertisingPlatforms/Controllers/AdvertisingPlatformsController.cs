using AdvertisingPlatforms.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatforms.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AdvertisingPlatformsController : Controller
    {
        private IAdvertisingPlatformsService _pfService;
        private IReader _reader;
        private const string prefLocationName = @"/";

        public AdvertisingPlatformsController(IAdvertisingPlatformsService platformsService, IReader reader)
        {
            _pfService = platformsService;
            _reader = reader;
        }

        [HttpGet("{*location}")]
        public IActionResult GetAdvertisingPlatforms(string location)
        {
            string locationName = prefLocationName + location;
            var result = _pfService.GetAdvertisingPlatforms(locationName);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDataForAdvertisingPlatformsAsync([FromForm] IFormFile file)
        {
            var data = await _reader.GetDataFromFileAsync(file);

            if (data == null)
            {
                return new StatusCodeResult(500);
            }
            else if (data.AdvertisingPlatforms.Count() == 0)
            {
                return UnprocessableEntity("Файл прочитан. В файле нет корректных данных.");
            }

            //update database PlatformsService
            int count = _pfService.SetDbAdvertisingPlatforms(data);

            return Ok($"База успешно обновлена. Количество локаций: {count}");

        }
    }
}
