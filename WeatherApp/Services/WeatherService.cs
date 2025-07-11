using System.Text.Json;
using WeatherApp.Models;
using WeatherApp.Helpers;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;

        public WeatherService(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }

        public async Task<OpenMeteoData> GetOpenMeteoData(string city)
        {
            double lat = 0;
            double lon = 0;
            if(city == "Canberra")
            {
                lat = -36;
                lon = 147;
            }
            else if(city == "New-York")
            {
                lat = 40.59;
                lon = -73.97;
            }
            else if(city == "Krasylivka"){
                lat = 50.51;
                lon = 30.91;
            }

            string url = $"https://api.open-meteo.com/v1/forecast?" +
                $"latitude={lat}" +
                $"&longitude={lon}" +
                $"&daily=sunrise,sunset,weather_code,temperature_2m_max,wind_speed_10m_max,wind_direction_10m_dominant,uv_index_max,precipitation_sum,temperature_2m_min,wind_gusts_10m_max,precipitation_probability_max,pressure_msl_max,pressure_msl_min,relative_humidity_2m_mean,cloud_cover_mean" +
                $"&hourly=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation_probability,precipitation,weather_code,cloud_cover,wind_speed_10m,wind_direction_10m,uv_index,wind_gusts_10m,pressure_msl,is_day" +
                $"&current=temperature_2m,relative_humidity_2m,apparent_temperature,weather_code,cloud_cover,precipitation,wind_speed_10m,wind_direction_10m,pressure_msl,wind_gusts_10m" +
                $"&timezone=auto" +
                $"&past_days=1" +
                $"&forecast_days=14" +
                $"&wind_speed_unit=ms";
            string json = null;
            try
            {
                var res = await httpClient.GetAsync(url);
                if (res.IsSuccessStatusCode)
                {
                    json = await res.Content.ReadAsStringAsync();
                }
            }
            catch
            {
                // todo: WeatherService try..catch
            }
            if (string.IsNullOrWhiteSpace(json))
            {
                string fallbackPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "fallback.json");
                json = await File.ReadAllTextAsync(fallbackPath);
            }
            var data = JsonSerializer.Deserialize<OpenMeteoData>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return data;
        }
    }
}
