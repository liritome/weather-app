using Microsoft.AspNetCore.Mvc;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class GeocoderController : Controller
    {
        private readonly WeatherApiService weatherApiService;
        private readonly LocationService locationService;

        public GeocoderController(WeatherApiService weatherApiService, LocationService locationService)
        {
            this.weatherApiService = weatherApiService;
            this.locationService = locationService;
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

        [HttpGet]
        public async Task<IActionResult> GetLocationByIp()
        {
            double tolerance = 0.1;
            var result = await weatherApiService.GetGeocodingByIp(String.Empty);
            var geocodingData = await weatherApiService.GetGeocodingData(result.City);
            var location = geocodingData.Locations.FirstOrDefault(l =>
                Math.Abs(l.Latitude - result.Latitude) < tolerance &&
                Math.Abs(l.Longitude - result.Longitude) < tolerance
            );
            return Json(location);
        }

        [HttpGet]
        public async Task<bool> LocationExists(string location)
        {
            var cityParsed = locationService.ParseLocation(location);
            if(cityParsed == null)
            {
                return false;
            }
            string cityName = cityParsed.Value.name;
            int cityId = cityParsed.Value.id;
            var geocodingData = await weatherApiService.GetGeocodingData(cityName);
            bool exists = geocodingData.Locations != null && geocodingData.Locations.Any(l => l.Id == cityId);
            return exists;
        }
    }
}
