namespace WeatherApp.Models
{
    public class DailyWeather
    {
        public List<DateTime> Time { get; set; }
        public List<DateTime> Sunrise { get; set; }
        public List<DateTime> Sunset { get; set; }
    }

    public class DailyUnits
    {
        public string Time { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }
}
