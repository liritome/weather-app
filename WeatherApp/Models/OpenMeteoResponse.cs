using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class OpenMeteoResponse
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
        public CurrentUnits CurrentUnits { get; set; }
        [JsonPropertyName("current")]
        public CurrentWeather CurrentWeather { get; set; }
        [JsonPropertyName("daily_units")]
        public DailyUnits DailyUnits { get; set; }
        [JsonPropertyName("daily")]
        public DailyWeather DailyWeather { get; set; }
    }
}
