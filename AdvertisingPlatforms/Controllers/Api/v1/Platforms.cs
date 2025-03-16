using AdvertisingPlatforms.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatforms.Controllers.Api.v1
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class Platforms : Controller
    {
        private IPlatformsService _pfService;

        public Platforms(IPlatformsService platformsService)
        {
            _pfService = platformsService;
        }

        [HttpGet("{*region}")]
        public JsonResult Get(string region)
        {
            var result = _pfService.GetPlatforms(region);

            return Json(result);
        }

        [HttpPost]
        public async Task<JsonResult> LoadData()
        {
            return Json("");
        }
    }
}
