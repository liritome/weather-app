using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherApiService weatherApiService;
        private readonly LocationService locationService;
        public WeatherController(WeatherApiService weatherApiService, LocationService locationService)
        {
            this.weatherApiService = weatherApiService;
            this.locationService = locationService;
        }

        public async Task<IActionResult> Now(string city)
        {
            ViewData["ActiveTab"] = "now";
            var (location, data) = await GetLocationWeatherAsync(city);
            ViewData["Location"] = location;
            return View(data);
        }

        public async Task<IActionResult> Day(string city, int day = 0)
        {
            ViewData["ActiveTab"] = day switch
            {
                -1 => "yesterday",
                0 => "today",
                1 => "tomorrow",
                _ => ""
            };
            ViewData["DayOffset"] = day;
            var (location, data) = await GetLocationWeatherAsync(city);
            ViewData["Location"] = location;
            return View(data);
        }

        public async Task<IActionResult> Hourly(string city)
        {
            ViewData["ActiveTab"] = "hourly";
            var (location, data) = await GetLocationWeatherAsync(city);
            ViewData["Location"] = location;
            return View(data);
        }

        public async Task<IActionResult> ThreeDays(string city)
        {
            ViewData["ActiveTab"] = "threeDays";
            var (location, data) = await GetLocationWeatherAsync(city);
            ViewData["Location"] = location;
            return View(data);
        }

        public async Task<IActionResult> SevenDays(string city)
        {
            ViewData["ActiveTab"] = "sevenDays";
            var (location, data) = await GetLocationWeatherAsync(city);
            ViewData["Location"] = location;
            return View(data);
        }

        public async Task<IActionResult> TwoWeeks(string city)
        {
            ViewData["ActiveTab"] = "twoWeeks";
            var (location, data) = await GetLocationWeatherAsync(city);
            ViewData["Location"] = location;
            return View(data);
        }

        private async Task<(Location location, OpenMeteoWeatherData data)> GetLocationWeatherAsync(string city)
        {
            var cityParsed = locationService.ParseLocation(city)!;
            string cityName = cityParsed.Value.name;
            int cityId = cityParsed.Value.id;

            var geocodingData = await weatherApiService.GetGeocodingData(cityName);
            var location = geocodingData.Locations.First(l => l.Id == cityId);

            var data = await weatherApiService.GetWeatherData(location.Latitude, location.Longitude);

            return (location, data);
        }
    }
}
