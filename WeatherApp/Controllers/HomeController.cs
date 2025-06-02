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
            ViewData["ActiveTab"] = "Now";
            ViewData["City"] = city;
            var data = await weatherService.GetOpenMeteoData(city);
            return View(data);
        }

        /*public IActionResult Current()
        {
            return PartialView();
        }
        public IActionResult Menu()
        {
            return PartialView();
        }*/
    }
}
