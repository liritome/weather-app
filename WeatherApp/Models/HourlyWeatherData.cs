using System.Text.Json.Serialization;
using WeatherApp.Helpers;

namespace WeatherApp.Models
{
    public class HourlyWeatherData
    {
        [JsonPropertyName("time")]
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
        [JsonPropertyName("precipitation")]
        public List<double> Precipitation { get; set; }
        [JsonPropertyName("pressure_msl")]
        public List<double> Pressure { get; set; }
        [JsonPropertyName("cloud_cover")]
        public List<int> CloudCover { get; set; }
        [JsonPropertyName("uv_index")]
        public List<double> UvIndex { get; set; }
        [JsonPropertyName("wind_speed_10m")]
        public List<double> WindSpeed { get; set; }
        [JsonPropertyName("wind_gusts_10m")]
        public List<double> WindGusts { get; set; }
        [JsonPropertyName("wind_direction_10m")]
        public List<int> WindDirectionDegree { get; set; }

        public List<string> WindDirection => WindDirectionDegree.Select(t => WeatherHelper.GetWindDirection(t)).ToList();

        public List<string> WeatherDescription => Code.Select(t => WeatherHelper.GetWeatherDescription(t)).ToList();

        public HourlyWeatherData(List<DateTime> time, List<double> temperature, List<int> humidity, List<double> apparentTemperature,
            List<int> precipitationProbability, List<double> precipitation, List<int> code, List<double> pressure,
            List<int> cloudCover, List<double> windSpeed, List<double> windGusts, List<int> windDirectionDegree, List<double> uvIndex)
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
            UvIndex = uvIndex.Select(t => Math.Round(t)).ToList();
            WindSpeed = windSpeed.Select(t => Math.Round(t)).ToList();
            WindGusts = windGusts.Select(t => Math.Round(t)).ToList();
            WindDirectionDegree = windDirectionDegree;
        }

        public HourlyWeather GetHourlyWeatherByDate(DateTime dateTime, int days)
        {
            int hours = days * 24;
            int index = Time.IndexOf(dateTime);
            return new HourlyWeather(Time.GetRange(index, hours), Code.GetRange(index, hours), Temperature.GetRange(index, hours),
                ApparentTemperature.GetRange(index, hours), Humidity.GetRange(index, hours), PrecipitationProbability.GetRange(index, hours),
                Precipitation.GetRange(index, hours), Pressure.GetRange(index, hours), CloudCover.GetRange(index, hours),
                UvIndex.GetRange(index, hours), WindSpeed.GetRange(index, hours), WindGusts.GetRange(index, hours), WindDirectionDegree.GetRange(index, hours),
                WindDirection.GetRange(index, hours), WeatherDescription.GetRange(index, hours));
        }
    }

    public class HourlyWeatherUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }
        [JsonPropertyName("temperature_2m")]
        public string Temperature { get; set; }
        [JsonPropertyName("relative_humidity_2m")]
        public string Humidity { get; set; }
        [JsonPropertyName("apparent_temperature")]
        public string ApparentTemperature { get; set; }
        [JsonPropertyName("precipitation_probability")]
        public string PrecipitationProbability { get; set; }
        [JsonPropertyName("precipitation")]
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
        [JsonPropertyName("wind_gusts_10m")]
        public string WindGusts { get; set; }
        [JsonPropertyName("wind_direction_10m")]
        public string WindDirectionDegree { get; set; }
    }

    public class HourlyWeather
    {
        public List<DateTime> Time { get; set; }
        public List<int> Code { get; set; }
        public List<double> Temperature { get; set; }
        public List<double> ApparentTemperature { get; set; }
        public List<int> Humidity { get; set; }
        public List<int> PrecipitationProbability { get; set; }
        public List<double> Precipitation { get; set; }
        public List<double> Pressure { get; set; }
        public List<int> CloudCover { get; set; }
        public List<double> UvIndex { get; set; }
        public List<double> WindSpeed { get; set; }
        public List<double> WindGusts { get; set; }
        public List<int> WindDirectionDegree { get; set; }
        public List<string> WindDirection { get; set; }
        public List<string> WeatherDescription { get; set; }

        public HourlyWeather(List<DateTime> time, List<int> code, List<double> temperature,
            List<double> apparentTemperature, List<int> humidity, List<int> precipitationProbability,
            List<double> precipitation, List<double> pressure, List<int> cloudCover,
            List<double> uvIndex, List<double> windSpeed, List<double> windGusts, List<int> windDirectionDegree,
            List<string> windDirection, List<string> weatherDescription)
        {
            Time = time;
            Code = code;
            Temperature = temperature;
            ApparentTemperature = apparentTemperature;
            Humidity = humidity;
            PrecipitationProbability = precipitationProbability;
            Precipitation = precipitation;
            Pressure = pressure;
            CloudCover = cloudCover;
            UvIndex = uvIndex;
            WindSpeed = windSpeed;
            WindGusts = windGusts;
            WindDirectionDegree = windDirectionDegree;
            WindDirection = windDirection;
            WeatherDescription = weatherDescription;
        }
    }
}
