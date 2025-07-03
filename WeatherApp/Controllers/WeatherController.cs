using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService weatherService;
        public WeatherController(WeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public async Task<IActionResult> Now(string city)
        {
            ViewData["ActiveTab"] = "now";
            ViewData["City"] = city;
            var data = await weatherService.GetOpenMeteoData(city);
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
            ViewData["City"] = city;
            ViewData["DayOffset"] = day;
            var data = await weatherService.GetOpenMeteoData(city);
            return View(data);
        }

        public async Task<IActionResult> ThreeDays(string city)
        {
            ViewData["ActiveTab"] = "threeDays";
            ViewData["City"] = city;
            var data = await weatherService.GetOpenMeteoData(city);
            return View(data);
        }

        public async Task<IActionResult> SevenDays(string city)
        {
            ViewData["ActiveTab"] = "sevenDays";
            ViewData["City"] = city;
            ViewData["Days"] = 7;
            var data = await weatherService.GetOpenMeteoData(city);
            return View("Daily", data);
        }
    }
}
