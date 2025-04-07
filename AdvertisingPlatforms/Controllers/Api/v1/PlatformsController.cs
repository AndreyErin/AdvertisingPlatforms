using AdvertisingPlatforms.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatforms.Controllers.Api.v1
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PlatformsController : Controller
    {
        private IPlatformsService _pfService;
        private IReader _reader;

        public PlatformsController(IPlatformsService platformsService, IReader reader)
        {
            _pfService = platformsService;
            _reader = reader;
        }

        [HttpGet("{*region}")]
        public IActionResult Get(string region)
        {
            var result = _pfService.GetPlatforms(region);

            if (result.Count() == 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromForm] IFormFile file)
        {
            //пытаемся получить короректные данные из файла
            var data = await _reader.GetValidDataAsync(file);

            if (data == null)
            {
                return new StatusCodeResult(500);
            }
            else if (data.Count() == 0)
            {
                return UnprocessableEntity("Файл прочитан. В файле нет корректных данных.");
            }

            //обновляем базу
            int count = _pfService.SetDbPlatforms(data);

            return Ok($"База успешно обновлена. Количество локаций: {count}");

        }
    }
}
