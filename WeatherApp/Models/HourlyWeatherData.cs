using System.Text.Json.Serialization;
using WeatherApp.Helpers;

namespace WeatherApp.Models
{
    public class HourlyWeatherData
    {
        public List<DateTime> Time { get; set; }
        [JsonPropertyName("weather_code")]
        public List<int> Code { get; set; }
        [JsonPropertyName("temperature_2m")]
        public List<double> Temperature { get; set; }
        [JsonPropertyName("apparent_temperature")]
        public List<double> ApparentTemperature { get; set; }
        [JsonPropertyName("relative_humidity_2m")]
        public List<int> Humidity { get; set; }
        [JsonPropertyName("precipitation_probability")]
        public List<int> PrecipitationProbability { get; set; }
        public List<double> Precipitation { get; set; }
        [JsonPropertyName("surface_pressure")]
        public List<double> Pressure { get; set; }
        [JsonPropertyName("cloud_cover")]
        public List<int> CloudCover { get; set; }
        [JsonPropertyName("uv_index")]
        public List<double> UvIndex { get; set; }
        [JsonPropertyName("wind_speed_10m")]
        public List<double> WindSpeed { get; set; }
        [JsonPropertyName("wind_direction_10m")]
        public List<int> WindDirectionDegree { get; set; }

        public List<string> WindDirection => WindDirectionDegree.Select(t => WeatherHelper.GetWindDirection(t)).ToList();

        public List<string> WeatherDescription => Code.Select(t => WeatherHelper.GetWeatherDescription(t)).ToList();

        public HourlyWeatherData(List<DateTime> time, List<double> temperature, List<int> humidity, List<double> apparentTemperature,
            List<int> precipitationProbability, List<double> precipitation, List<int> code, List<double> pressure,
            List<int> cloudCover, List<double> windSpeed, List<int> windDirectionDegree, List<double> uvIndex)
        {
            Time = time;
            Temperature = temperature.Select(t => Math.Round(t)).ToList();
            Humidity = humidity;
            ApparentTemperature = apparentTemperature.Select(t => Math.Round(t)).ToList();
            PrecipitationProbability = precipitationProbability;
            Precipitation = precipitation;
            Code = code;
            // hPa to mmhg
            Pressure = pressure.Select(t => Math.Round(t * 0.75)).ToList();
            CloudCover = cloudCover;
            UvIndex = uvIndex;
            WindSpeed = windSpeed.Select(t => Math.Round(t)).ToList();
            WindDirectionDegree = windDirectionDegree;
        }
    }

    public class HourlyWeatherUnits
    {
        public string Time { get; set; }
        [JsonPropertyName("temperature_2m")]
        public string Temperature { get; set; }
        [JsonPropertyName("relative_humidity_2m")]
        public string Humidity { get; set; }
        [JsonPropertyName("apparent_temperature")]
        public string ApparentTemperature { get; set; }
        [JsonPropertyName("precipitation_probability")]
        public string PrecipitationProbability { get; set; }
        public string Precipitation { get; set; }
        [JsonPropertyName("weather_code")]
        public string Code { get; set; }
        [JsonPropertyName("surface_pressure")]
        public string Pressure { get; set; }
        [JsonPropertyName("cloud_cover")]
        public string CloudCover { get; set; }
        [JsonPropertyName("uv_index")]
        public string UvIndex { get; set; }
        [JsonPropertyName("wind_speed_10m")]
        public string WindSpeed { get; set; }
        [JsonPropertyName("wind_direction_10m")]
        public string WindDirectionDegree { get; set; }
    }
}
