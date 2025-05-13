using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private WeatherContext db;
        public HomeController(WeatherContext weatherContext)
        {
            db = weatherContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
