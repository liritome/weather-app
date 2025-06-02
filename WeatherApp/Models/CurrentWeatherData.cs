using System.Text.Json.Serialization;
using WeatherApp.Helpers;

namespace WeatherApp.Models
{
    public class CurrentWeatherData
    {
        public DateTime Time { get; set; }
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
        public int WindDirectionDegree { get; set; }
        [JsonIgnore]
        public string WindDirection { get; set; }
        [JsonIgnore]
        public string WeatherDescription {  get; set; }

        [JsonConstructor]
        public CurrentWeatherData(DateTime time, int interval, int code, double temperature,
            double apparentTemperature, int humidity, int cloudCover, double pressure,
            double presipitation, double windSpeed, int windDirectionDegree)
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
            Presipitation = presipitation;
            WindSpeed = Math.Round(windSpeed);
            WindDirectionDegree = windDirectionDegree;
            WindDirection = WeatherHelper.GetWindDirection(windDirectionDegree);
            WeatherDescription = WeatherHelper.GetWeatherDescription(code);
        }
    }

    public class CurrentWeatherUnits
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
