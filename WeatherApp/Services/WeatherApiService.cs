using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherApiService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;
        private readonly IMemoryCache memoryCache;

        public WeatherApiService(HttpClient httpClient, IConfiguration config, IMemoryCache memoryCache)
        {
            this.httpClient = httpClient;
            this.config = config;
            this.memoryCache = memoryCache;
        }

        public async Task<OpenMeteoWeatherData> GetWeatherData(double lat, double lon)
        {
            string cacheKey = $"weather_{lat}_{lon}";
            if(memoryCache.TryGetValue(cacheKey, out OpenMeteoWeatherData cachedData))
            {
                return cachedData;
            }

            string url = $"https://api.open-meteo.com/v1/forecast?" +
                $"latitude={lat}" +
                $"&longitude={lon}" +
                $"&daily=sunrise,sunset,weather_code,temperature_2m_max,wind_speed_10m_max,wind_direction_10m_dominant,uv_index_max,precipitation_sum,temperature_2m_min,wind_gusts_10m_max,precipitation_probability_max,pressure_msl_max,pressure_msl_min,relative_humidity_2m_mean,cloud_cover_mean,apparent_temperature_max,apparent_temperature_min" +
                $"&hourly=temperature_2m,relative_humidity_2m,apparent_temperature,precipitation_probability,precipitation,weather_code,cloud_cover,wind_speed_10m,wind_direction_10m,uv_index,wind_gusts_10m,pressure_msl,is_day" +
                $"&current=temperature_2m,relative_humidity_2m,apparent_temperature,weather_code,cloud_cover,precipitation,wind_speed_10m,wind_direction_10m,pressure_msl,wind_gusts_10m" +
                $"&timezone=auto" +
                $"&past_days={WeatherHelper.PastDays}" +
                $"&forecast_days={WeatherHelper.Days}" +
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
            var data = JsonSerializer.Deserialize<OpenMeteoWeatherData>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            memoryCache.Set(cacheKey, data, TimeSpan.FromMinutes(15));
            return data;
        }

        public async Task<OpenMeteoGeocodingData> GetGeocodingData(string location)
        {
            string cacheKey = $"geocoding_{location.Trim().ToLower()}";
            if (memoryCache.TryGetValue(cacheKey, out OpenMeteoGeocodingData cachedData))
            {
                return cachedData;
            }

            string url = $"https://geocoding-api.open-meteo.com/v1/search?" +
                $"name={location}" +
                $"&count=10" +
                $"&language=en" +
                $"&format=json";
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
                string fallbackPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "geocodingFallback.json");
                json = await File.ReadAllTextAsync(fallbackPath);
            }
            var data = JsonSerializer.Deserialize<OpenMeteoGeocodingData>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            memoryCache.Set(cacheKey, data, TimeSpan.FromMinutes(15));
            return data;
        }

        public async Task<Coordinates> GetGeocodingByIp(string ip)
        {
            string baseUrl = "http://ip-api.com";
            string url;
            if (string.IsNullOrEmpty(ip))
            {
                url = $"{baseUrl}/json?fields=city,lat,lon";
            }
            else
            {
                url = $"{baseUrl}/{ip}/json?fields=city,lat,lon";
            }
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

            }
            if (string.IsNullOrWhiteSpace(json))
            {
                string fallbackPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "data", "geocodingByIpFallback.json");
                json = await File.ReadAllTextAsync(fallbackPath);
            }
            var data = JsonSerializer.Deserialize<Coordinates>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });
            return data;
        }
    }

    public class Coordinates
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}
