using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class HourlyViewModel
    {
        public int FirstDayOffset { get; set; }
        public int DaysCount { get; set; }
        public int HourStep { get; set; }
        public OpenMeteoData OpenMeteoData { get; set; }
    }
}
