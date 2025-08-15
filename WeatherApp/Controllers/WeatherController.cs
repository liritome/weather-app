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
            return await ShowWeatherAsync(city, "now", "Now");
        }

        public async Task<IActionResult> Day(string city, int day = 0)
        {
            string activeTab = day switch
            {
                -1 => "yesterday",
                0 => "today",
                1 => "tomorrow",
                _ => ""
            };
            ViewData["DayOffset"] = day;
            return await ShowWeatherAsync(city, activeTab, "Day");
        }

        public async Task<IActionResult> Hourly(string city)
        {
            return await ShowWeatherAsync(city, "hourly", "Hourly");
        }

        public async Task<IActionResult> ThreeDays(string city)
        {
            return await ShowWeatherAsync(city, "threeDays", "ThreeDays");
        }

        public async Task<IActionResult> SevenDays(string city)
        {
            return await ShowWeatherAsync(city, "sevenDays", "SevenDays");
        }

        public async Task<IActionResult> TwoWeeks(string city)
        {
            return await ShowWeatherAsync(city, "twoWeeks", "TwoWeeks");
        }

        private async Task<IActionResult> ShowWeatherAsync(string city, string activeTab, string viewName)
        {
            try
            {
                if (string.IsNullOrEmpty(city))
                {
                    var lastValidCity = HttpContext.Session.GetString("LastValidCity");
                    if (lastValidCity != null)
                    {
                        return RedirectToAction("Now", new { city = lastValidCity });
                    }
                    using var client = new HttpClient();
                    var locationByIp = await client.GetFromJsonAsync<Location>(
                        $"{Request.Scheme}://{Request.Host}/Geocoder/GetLocationByIp"
                    );
                    if (locationByIp != null)
                    {
                        return RedirectToAction("Now", new { city = $"{locationByIp.Name}-{locationByIp.Id}" });
                    }
                    return RedirectTo404();
                }            
                ViewData["ActiveTab"] = activeTab;
                var (location, data) = await GetLocationWeatherAsync(city);
                if(location == null || data == null)
                {
                    return RedirectTo400();
                }
                ViewData["Location"] = location;
                return View(viewName, data);
            }
            catch
            {
                return RedirectTo404();
            }
        }

        private IActionResult RedirectTo404()
        {
            return RedirectToAction(
                actionName: "HttpStatusCodeHandler",
                controllerName: "Error",
                routeValues: new { statusCode = 404 }
            );
        }

        private IActionResult RedirectTo400()
        {
            return RedirectToAction(
                actionName: "HttpStatusCodeHandler",
                controllerName: "Error",
                routeValues: new { statusCode = 400 }
            );
        }

        private async Task<(Location? location, OpenMeteoWeatherData? data)> GetLocationWeatherAsync(string city)
        {
            var cityParsed = locationService.ParseLocation(city);
            if(cityParsed == null)
            {
                return (null, null);
            }
            string cityName = cityParsed.Value.name;
            int cityId = cityParsed.Value.id;

            var geocodingData = await weatherApiService.GetGeocodingData(cityName);
            if(geocodingData == null)
            {
                return (null, null);
            }
            var location = geocodingData.Locations.First(l => l.Id == cityId);

            HttpContext.Session.SetString("LastValidCity", $"{location.Name}-{location.Id}");

            var data = await weatherApiService.GetWeatherData(location.Latitude, location.Longitude);
            return (location, data);
        }
    }
}
