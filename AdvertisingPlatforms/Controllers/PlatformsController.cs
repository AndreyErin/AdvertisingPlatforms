using AdvertisingPlatforms.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatforms.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PlatformsController : Controller
    {
        private IPlatformsService _pfService;
        private IReader _reader;
        private const string prefLocationName = @"/";

        public PlatformsController(IPlatformsService platformsService, IReader reader)
        {
            _pfService = platformsService;
            _reader = reader;
        }

        [HttpGet("{*location}")]
        public IActionResult GetPlatforms(string location)
        {
            string locationName = prefLocationName + location;
            var result = _pfService.GetPlatforms(locationName);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromForm] IFormFile file)
        {
            var data = await _reader.GetDataFromFileAsync(file);

            if (data == null)
            {
                return new StatusCodeResult(500);
            }
            else if (data.Count() == 0)
            {
                return UnprocessableEntity("Файл прочитан. В файле нет корректных данных.");
            }

            //update database PlatformsService
            int count = _pfService.SetDbPlatforms(data);

            return Ok($"База успешно обновлена. Количество локаций: {count}");

        }
    }
}
