using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            ViewData["ErrorMessage"] = statusCode switch
            {
                404 => "The page you are looking for could not be found.",
                400 => "Bad request. Please check your input.",
                _ => "An unexpected error occurred."
            };
            var lastValidCity = HttpContext.Session.GetString("LastValidCity");
            ViewData["LastValidCity"] = lastValidCity;
            return View("Error");
        }
    }
}
