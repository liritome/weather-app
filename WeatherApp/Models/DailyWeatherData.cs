using System.Text.Json.Serialization;
using WeatherApp.Helpers;

namespace WeatherApp.Models
{
    public class DailyWeatherData
    {
        public List<DateTime> Time { get; set; }
        public List<DateTime> Sunrise { get; set; }
        public List<DateTime> Sunset { get; set; }
        [JsonPropertyName("weather_code")]
        public List<int> Code { get; set; }
        [JsonPropertyName("temperature_2m_max")]
        public List<double> TemperatureMax { get; set; }
        [JsonPropertyName("temperature_2m_min")]
        public List<double> TemperatureMin { get; set; }
        [JsonPropertyName("wind_speed_10m_max")]
        public List<double> WindSpeedMax { get; set; }
        [JsonPropertyName("wind_direction_10m_dominant")]
        public List<int> WindDirectionDegreeDominant { get; set; }
        [JsonPropertyName("uv_index_max")]
        public List<double> UvIndexMax { get; set; }
        [JsonPropertyName("precipitation_sum")]
        public List<double> PrecipitationSum { get; set; }

        public List<string> WindDirectionDominant => WindDirectionDegreeDominant.Select(t => WeatherHelper.GetWindDirection(t)).ToList();

        public List<string> WeatherDescription => Code.Select(t => WeatherHelper.GetWeatherDescription(t)).ToList();

        public DailyWeatherData(List<DateTime> time, List<DateTime> sunrise, List<DateTime> sunset, List<int> code,
            List<double> temperatureMax, List<double> windSpeedMax, List<double> temperatureMin,
            List<int> windDirectionDegreeDominant, List<double> uvIndexMax, List<double> precipitationSum)
        {
            Time = time;
            Sunrise = sunrise;
            Sunset = sunset;
            Code = code;
            TemperatureMax = temperatureMax.Select(t => Math.Round(t)).ToList();
            TemperatureMin = temperatureMin.Select(t => Math.Round(t)).ToList();
            WindSpeedMax = windSpeedMax.Select(t => Math.Round(t)).ToList();
            WindDirectionDegreeDominant = windDirectionDegreeDominant;
            UvIndexMax = uvIndexMax;
            PrecipitationSum = precipitationSum;
        }

        public DailyWeather GetDailyWeatherByDate(DateTime dateTime)
        {
            int index = Time.IndexOf(dateTime.Date);
            return new DailyWeather(dateTime, Sunrise[index], Sunset[index], Code[index], TemperatureMax[index],
                TemperatureMin[index], WindSpeedMax[index], UvIndexMax[index], PrecipitationSum[index],
                WindDirectionDominant[index], WeatherDescription[index]);
        }
    }

    public class DailyWeatherUnits
    {
        public string Time { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        [JsonPropertyName("weather_code")]
        public string Code { get; set; }
        [JsonPropertyName("temperature_2m_max")]
        public string TemperatureMax { get; set; }
        [JsonPropertyName("wind_speed_10m_max")]
        public string WindSpeedMax { get; set; }
        [JsonPropertyName("temperature_2m_min")]
        public string TemperatureMin { get; set; }
        [JsonPropertyName("wind_direction_10m_dominant")]
        public string WindDirectionDegreeDominant { get; set; }
        [JsonPropertyName("uv_index_max")]
        public string UvIndexMax { get; set; }
        [JsonPropertyName("precipitation_sum")]
        public string PrecipitationSum { get; set; }
    }

    public class DailyWeather
    {
        public DateTime Time { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public int Code { get; set; }
        public double TemperatureMax { get; set; }
        public double TemperatureMin { get; set; }
        public double WindSpeedMax { get; set; }
        public double UvIndexMax { get; set; }
        public double PrecipitationSum { get; set; }
        public string WindDirectionDominant { get; set; }
        public string WeatherDescription { get; set; }

        public DailyWeather(DateTime time, DateTime sunrise, DateTime sunset, int code,
            double temperatureMax, double temperatureMin, double windSpeedMax, double uvIndexMax,
            double precipitationSum, string windDirectionDominant, string weatherDescription)
        {
            Time = time;
            Sunrise = sunrise;
            Sunset = sunset;
            Code = code;
            TemperatureMax = temperatureMax;
            TemperatureMin = temperatureMin;
            WindSpeedMax = windSpeedMax;
            UvIndexMax = uvIndexMax;
            PrecipitationSum = precipitationSum;
            WindDirectionDominant = windDirectionDominant;
            WeatherDescription = weatherDescription;
        }
    }
}
