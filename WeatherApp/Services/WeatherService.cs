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
            // Canberra
            /*double lat = -36;
            double lon = 147;*/

            // New York
            /*double lat = 40.59;
            double lon = -73.97;*/

            // Krasylivka
            double lat = 50.51;
            double lon = 30.91;

            string url = $"https://api.open-meteo.com/v1/forecast?" +
                $"latitude={lat}" +
                $"&longitude={lon}" +
                $"&daily=sunrise,sunset,weather_code,temperature_2m_max,wind_speed_10m_max,temperature_2m_min,wind_direction_10m_dominant,uv_index_max,precipitation_sum" +
                $"&hourly=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation_probability,precipitation,weather_code,surface_pressure,cloud_cover,wind_speed_10m,wind_direction_10m,uv_index,wind_gusts_10m" +
                $"&current=temperature_2m,relative_humidity_2m,apparent_temperature,weather_code,cloud_cover,surface_pressure,precipitation,wind_speed_10m,wind_direction_10m" +
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
