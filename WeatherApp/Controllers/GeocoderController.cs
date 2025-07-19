using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class GeocoderController : Controller
    {
        private readonly WeatherApiService weatherApiService;

        public GeocoderController(WeatherApiService weatherApiService)
        {
            this.weatherApiService = weatherApiService;
        }

        [HttpGet]
        public async Task<IActionResult> SearchLocations(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                return null;
            }
            var result = await weatherApiService.GetGeocodingData(location);
            return Json(result.Locations);
        }
    }
}
