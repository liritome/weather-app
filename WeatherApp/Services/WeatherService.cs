using System.Globalization;
using System.Text.Json;
using WeatherApp.Models;

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

        public async Task<OpenMeteoResponse> GetCurrentWeatherAsync(string city)
        {
            double lat = 50.51;
            double lon = 30.91;
            string url = $"https://api.open-meteo.com/v1/forecast?" +
                $"latitude={lat}" +
                $"&longitude={lon}" +
                $"&daily=sunrise,sunset&current=temperature_2m,relative_humidity_2m,apparent_temperature,weather_code," +
                $"cloud_cover,surface_pressure,precipitation,wind_speed_10m,wind_direction_10m" +
                $"&timezone=auto&forecast_days=1&wind_speed_unit=ms";

            var res = await httpClient.GetAsync(url);
            if (!res.IsSuccessStatusCode)
            {
                return null;
            }
            var json = await res.Content.ReadAsStringAsync();
            var deserialized = JsonSerializer.Deserialize<OpenMeteoResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return deserialized;
        }
    }
}
