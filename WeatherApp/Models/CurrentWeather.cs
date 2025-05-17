using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class CurrentWeather
    {
        public string Time { get; set; }
        public int Interval { get; set; }
        [JsonPropertyName("weather_code")]
        public int Code { get; set; }
        [JsonPropertyName("temperature_2m")]
        public double Temperature { get; set; }
        [JsonPropertyName("apparent_temperature")]
        public double ApparentTemperature { get; set; }
        [JsonPropertyName("relative_humidity_2m")]
        public int Humidity { get; set; }
        [JsonPropertyName("cloud_cover")]
        public int CloudCover { get; set; }
        [JsonPropertyName("surface_pressure")]
        public double Pressure { get; set; }
        public double Presipitation { get; set; }
        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed { get; set; }
        [JsonPropertyName("wind_direction_10m")]
        public int WindDirection { get; set; }
    }

    public class CurrentUnits
    {
        public string Time { get; set; }
        public string Interval { get; set; }
        [JsonPropertyName("weather_code")]
        public string Code { get; set; }
        [JsonPropertyName("temperature_2m")]
        public string Temperature { get; set; }
        [JsonPropertyName("apparent_temperature")]
        public string ApparentTemperature { get; set; }
        [JsonPropertyName("relative_humidity_2m")]
        public string Humidity { get; set; }
        [JsonPropertyName("cloud_cover")]
        public string CloudCover { get; set; }
        [JsonPropertyName("surface_pressure")]
        public string Pressure { get; set; }
        public string Presipitation { get; set; }
        [JsonPropertyName("wind_speed_10m")]
        public string WindSpeed { get; set; }
        [JsonPropertyName("wind_direction_10m")]
        public string WindDirection { get; set; }
    }
}
