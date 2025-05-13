namespace WeatherApp.Models
{
    public class DayForecast
    {
        public Dictionary<byte, Weather> ForecastPerHour { get; set; } = new();
        public DateTime Date { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public byte MoonPhasePercent { get; set; }
    }
}
