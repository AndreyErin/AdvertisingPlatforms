using AdvertisingPlatforms.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatforms.Controllers.Api.v1
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PlatformsController : Controller
    {
        private IPlatformsService _pfService;

        public PlatformsController(IPlatformsService platformsService)
        {
            _pfService = platformsService;
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
        public async Task<IActionResult> LoadDataAsync([FromForm] IFormFile file)
        {
            //пытаемся получить короректные данные из файла
            Reader reader = new();
            var data = await reader.GetValidDataAsync(file);

            if (data == null || data.Count() == 0)
            {
                return UnprocessableEntity("В файле нет корректных данных.");
            }

            //обновляем базу
            int count = _pfService.SetDbPlatforms(data);

            return Ok($"База успешно обновлена. Количество локаций: {count}");
         
        }
    }
}
