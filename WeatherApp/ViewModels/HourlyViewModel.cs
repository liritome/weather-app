using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class HourlyViewModel
    {
        public OpenMeteoData OpenMeteoData { get; set; }
        public int FirstDayOffset { get; set; }
        public int DaysCount { get; set; }
        public int HourStep { get; set; }
    }
}
