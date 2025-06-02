using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class OpenMeteoData
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [JsonPropertyName("generationtime_ms")]
        public double GenerationTime { get; set; }
        [JsonPropertyName("utc_offset_seconds")]
        public int UtcOffsetSeconds { get; set; }
        public string Timezone { get; set; }
        [JsonPropertyName("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }
        public double Elevation { get; set; }
        [JsonPropertyName("current_units")]
        public CurrentWeatherUnits CurrentWeatherUnits { get; set; }
        [JsonPropertyName("current")]
        public CurrentWeatherData CurrentWeather { get; set; }
        [JsonPropertyName("hourly_units")]
        public HourlyWeatherUnits HourlyWeatherUnits { get; set; }
        [JsonPropertyName("hourly")]
        public HourlyWeatherData HourlyWeatherData { get; set; }
        [JsonPropertyName("daily_units")]
        public DailyWeatherUnits DailyWeatherUnits { get; set; }
        [JsonPropertyName("daily")]
        public DailyWeatherData DailyWeatherData { get; set; }
    }
}
