using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;
using WeatherApp.Services;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherService weatherService;
        public HomeController(WeatherService weatherService)
        {
            this.weatherService = weatherService;
        }

        public async Task<IActionResult> Index(string city = "Krasylivka")
        {
            var weather = await weatherService.GetCurrentWeatherAsync(city);
            return View(weather);
        }
    }
}
