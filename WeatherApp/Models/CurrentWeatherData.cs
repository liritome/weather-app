using System.Text.Json.Serialization;
using WeatherApp.Helpers;

namespace WeatherApp.Models
{
    public class CurrentWeatherData
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }
        [JsonPropertyName("interval")]
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
        [JsonPropertyName("pressure_msl")]
        public double Pressure { get; set; }
        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }
        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed { get; set; }
        [JsonPropertyName("wind_gusts_10m")]
        public double WindGusts { get; set; }
        [JsonPropertyName("wind_direction_10m")]
        public int WindDirectionDegree { get; set; }

        [JsonConstructor]
        public CurrentWeatherData(DateTime time, int interval, int code, double temperature,
            double apparentTemperature, int humidity, int cloudCover, double pressure,
            double precipitation, double windSpeed, double windGusts, int windDirectionDegree)
        {
            Time = time;
            Interval = interval;
            Code = code;
            Temperature = Math.Round(temperature);
            ApparentTemperature = Math.Round(apparentTemperature);
            Humidity = humidity;
            CloudCover = cloudCover;
            // hPa to mmhg
            Pressure = Math.Round(pressure * 0.75);
            Precipitation = precipitation;
            WindSpeed = Math.Round(windSpeed);
            WindGusts = Math.Round(windGusts);
            WindDirectionDegree = windDirectionDegree;
        }
    }

    public class CurrentWeatherUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }
        [JsonPropertyName("interval")]
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
        [JsonPropertyName("precipitation")]
        public string Precipitation { get; set; }
        [JsonPropertyName("wind_speed_10m")]
        public string WindSpeed { get; set; }
        [JsonPropertyName("wind_gusts_10m")]
        public string WindGusts { get; set; }
        [JsonPropertyName("wind_direction_10m")]
        public string WindDirection { get; set; }
    }
}
