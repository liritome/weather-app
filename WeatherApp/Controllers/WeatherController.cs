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

        public async Task<IActionResult> Day(string city = "Krasylivka", int day = 0)
        {
            ViewData["ActiveTab"] = day switch
            {
                -1 => "Yesterday",
                0 => "Today",
                1 => "Tomorrow",
                _ => ""
            };
            ViewData["City"] = city;
            ViewData["DayNumber"] = day;
            var data = await weatherService.GetOpenMeteoData(city);
            return View(data);
        }
    }
}
