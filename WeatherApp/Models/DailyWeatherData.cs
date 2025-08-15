using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class DailyWeatherData
    {
        [JsonPropertyName("time")]
        public List<DateTime> Time { get; set; }

        [JsonPropertyName("sunrise")]
        public List<DateTime> Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public List<DateTime> Sunset { get; set; }

        [JsonPropertyName("weather_code")]
        public List<int> Code { get; set; }

        [JsonPropertyName("temperature_2m_max")]
        public List<double> TemperatureMax { get; set; }

        [JsonPropertyName("temperature_2m_min")]
        public List<double> TemperatureMin { get; set; }

        [JsonPropertyName("apparent_temperature_max")]
        public List<double> ApparentTemperatureMax { get; set; }

        [JsonPropertyName("apparent_temperature_min")]
        public List<double> ApparentTemperatureMin { get; set; }

        [JsonPropertyName("wind_speed_10m_max")]
        public List<double> WindSpeedMax { get; set; }

        [JsonPropertyName("wind_gusts_10m_max")]
        public List<double> WindGustsMax { get; set; }

        [JsonPropertyName("wind_direction_10m_dominant")]
        public List<int> WindDirectionDegreeDominant { get; set; }

        [JsonPropertyName("uv_index_max")]
        public List<double> UvIndexMax { get; set; }

        [JsonPropertyName("precipitation_sum")]
        public List<double> PrecipitationSum { get; set; }

        [JsonPropertyName("precipitation_probability_max")]
        public List<int> PrecipitationProbabilityMax { get; set; }

        [JsonPropertyName("pressure_msl_max")]
        public List<double> PressureMax { get; set; }

        [JsonPropertyName("pressure_msl_min")]
        public List<double> PressureMin { get; set; }

        [JsonPropertyName("relative_humidity_2m_mean")]
        public List<int> Humidity { get; set; }

        [JsonPropertyName("cloud_cover_mean")]
        public List<int> CloudCover { get; set; }

        public DailyWeatherData(List<DateTime> time, List<DateTime> sunrise, List<DateTime> sunset, List<int> code,
            List<double> temperatureMax, List<double> temperatureMin, List<double> apparentTemperatureMax, List<double> apparentTemperatureMin, List<double> windSpeedMax, List<double> windGustsMax,
            List<int> windDirectionDegreeDominant, List<double> uvIndexMax, List<double> precipitationSum, List<int> precipitationProbabilityMax,
            List<double> pressureMax, List<double> pressureMin, List<int> humidity, List<int> cloudCover)
        {
            Time = time;
            Sunrise = sunrise;
            Sunset = sunset;
            Code = code;
            TemperatureMax = temperatureMax.Select(t => Math.Round(t)).ToList();
            TemperatureMin = temperatureMin.Select(t => Math.Round(t)).ToList();
            ApparentTemperatureMax = apparentTemperatureMax.Select(t => Math.Round(t)).ToList();
            ApparentTemperatureMin = apparentTemperatureMin.Select(t => Math.Round(t)).ToList();
            WindSpeedMax = windSpeedMax.Select(t => Math.Round(t)).ToList();
            WindGustsMax = windGustsMax.Select(t => Math.Round(t)).ToList();
            WindDirectionDegreeDominant = windDirectionDegreeDominant;
            UvIndexMax = uvIndexMax.Select(t => Math.Round(t)).ToList();
            PrecipitationSum = precipitationSum;
            PrecipitationProbabilityMax = precipitationProbabilityMax;
            // hPa to mmhg
            PressureMax = pressureMax.Select(t => Math.Round(t * 0.75)).ToList(); ;
            PressureMin = pressureMin.Select(t => Math.Round(t * 0.75)).ToList(); ;
            Humidity = humidity;
            CloudCover = cloudCover;
        }

        public SingleDayWeather GetSingleDayWeather(DateTime dateTime)
        {
            int index = Time.IndexOf(dateTime.Date);
            return new SingleDayWeather(Time[index], Sunrise[index], Sunset[index], Code[index], TemperatureMax[index],
                TemperatureMin[index], ApparentTemperatureMax[index], ApparentTemperatureMin[index], WindSpeedMax[index], WindGustsMax[index], WindDirectionDegreeDominant[index],
                UvIndexMax[index], PrecipitationSum[index], PrecipitationProbabilityMax[index],
                PressureMax[index], PressureMin[index], Humidity[index], CloudCover[index]);
        }

        public DailyWeather GetDailyWeather(DateTime dateTime, int days)
        {
            int index = Time.IndexOf(dateTime.Date);
            return new DailyWeather(
                Time.GetRange(index, days),
                Sunrise.GetRange(index, days),
                Sunset.GetRange(index, days),
                Code.GetRange(index, days),
                TemperatureMax.GetRange(index, days),
                TemperatureMin.GetRange(index, days),
                ApparentTemperatureMax.GetRange(index, days),
                ApparentTemperatureMin.GetRange(index, days),
                WindSpeedMax.GetRange(index, days),
                WindGustsMax.GetRange(index, days),
                WindDirectionDegreeDominant.GetRange(index, days),
                UvIndexMax.GetRange(index, days),
                PrecipitationSum.GetRange(index, days),
                PrecipitationProbabilityMax.GetRange(index, days),
                PressureMax.GetRange(index, days),
                PressureMin.GetRange(index, days),
                Humidity.GetRange(index, days),
                CloudCover.GetRange(index, days)
            );
    }
    }

    public class DailyWeatherUnits
    {
        [JsonPropertyName("time")]
        public string Time { get; set; } = string.Empty;

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; } = string.Empty;

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; } = string.Empty;

        [JsonPropertyName("weather_code")]
        public string Code { get; set; } = string.Empty;

        [JsonPropertyName("temperature_2m_max")]
        public string TemperatureMax { get; set; } = string.Empty;

        [JsonPropertyName("temperature_2m_min")]
        public string TemperatureMin { get; set; } = string.Empty;

        [JsonPropertyName("apparent_temperature_max")]
        public string ApparentTemperatureMax { get; set; } = string.Empty;

        [JsonPropertyName("apparent_temperature_min")]
        public string ApparentTemperatureMin { get; set; } = string.Empty;

        [JsonPropertyName("wind_speed_10m_max")]
        public string WindSpeedMax { get; set; } = string.Empty;

        [JsonPropertyName("wind_gusts_10m_max")]
        public string WindGustsMax { get; set; } = string.Empty;

        [JsonPropertyName("wind_direction_10m_dominant")]
        public string WindDirectionDegreeDominant { get; set; } = string.Empty;

        [JsonPropertyName("uv_index_max")]
        public string UvIndexMax { get; set; } = string.Empty;

        [JsonPropertyName("precipitation_sum")]
        public string PrecipitationSum { get; set; } = string.Empty;

        [JsonPropertyName("precipitation_probability_max")]
        public string PrecipitationProbabilityMax { get; set; } = string.Empty;

        [JsonPropertyName("pressure_msl_max")]
        public string PressureMax { get; set; } = string.Empty;

        [JsonPropertyName("pressure_msl_min")]
        public string PressureMin { get; set; } = string.Empty;

        [JsonPropertyName("relative_humidity_2m_mean")]
        public string Humidity { get; set; } = string.Empty;

        [JsonPropertyName("cloud_cover_mean")]
        public string CloudCover { get; set; } = string.Empty;
    }

    public record SingleDayWeather(
        DateTime Time,
        DateTime Sunrise,
        DateTime Sunset,
        int Code,
        double TemperatureMax,
        double TemperatureMin,
        double ApparentTemperatureMax,
        double ApparentTemperatureMin,
        double WindSpeedMax,
        double WindGustsMax,
        int WindDirectionDegreeDominant,
        double UvIndexMax,
        double PrecipitationSum,
        int PrecipitationProbabilityMax,
        double PressureMax,
        double PressureMin,
        int Humidity,
        int CloudCover
    );

    public record DailyWeather(
        List<DateTime> Time,
        List<DateTime> Sunrise,
        List<DateTime> Sunset,
        List<int> Code,
        List<double> TemperatureMax,
        List<double> TemperatureMin,
        List<double> ApparentTemperatureMax,
        List<double> ApparentTemperatureMin,
        List<double> WindSpeedMax,
        List<double> WindGustsMax,
        List<int> WindDirectionDegreeDominant,
        List<double> UvIndexMax,
        List<double> PrecipitationSum,
        List<int> PrecipitationProbabilityMax,
        List<double> PressureMax,
        List<double> PressureMin,
        List<int> Humidity,
        List<int> CloudCover
    );
}
