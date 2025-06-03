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

        public async Task<IActionResult> Now(string city = "Krasylivka")
        {
            ViewData["ActiveTab"] = "Now";
            ViewData["City"] = city;
            var data = await weatherService.GetOpenMeteoData(city);
            return View(data);
        }

        public async Task<IActionResult> Day(string city = "Krasylivka", int day = 1)
        {
            ViewData["ActiveTab"] = day switch
            {
                0 => "Yesterday",
                1 => "Today",
                2 => "Tomorrow",
                _ => ""
            };
            ViewData["City"] = city;
            var data = await weatherService.GetOpenMeteoData(city);
            return View(data);
        }
    }
}
