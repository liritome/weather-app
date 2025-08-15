using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class OpenMeteoWeatherData
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public double GenerationTime { get; set; }

        [JsonPropertyName("utc_offset_seconds")]
        public int UtcOffsetSeconds { get; set; }

        [JsonPropertyName("timezone")]
        public required string Timezone { get; set; }

        [JsonPropertyName("timezone_abbreviation")]
        public required string TimezoneAbbreviation { get; set; }

        [JsonPropertyName("elevation")]
        public double Elevation { get; set; }

        [JsonPropertyName("current_units")]
        public required CurrentWeatherUnits CurrentWeatherUnits { get; set; }

        [JsonPropertyName("current")]
        public required CurrentWeatherData CurrentWeatherData { get; set; }

        [JsonPropertyName("hourly_units")]
        public required HourlyWeatherUnits HourlyWeatherUnits { get; set; }

        [JsonPropertyName("hourly")]
        public required HourlyWeatherData HourlyWeatherData { get; set; }

        [JsonPropertyName("daily_units")]
        public required DailyWeatherUnits DailyWeatherUnits { get; set; }

        [JsonPropertyName("daily")]
        public required DailyWeatherData DailyWeatherData { get; set; }
    }
}
