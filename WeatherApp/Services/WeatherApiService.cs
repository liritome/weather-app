using Microsoft.AspNetCore.WebUtilities;
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

        public async Task<OpenMeteoWeatherData?> GetWeatherData(double lat, double lon)
        {
            string cacheKey = $"weather_{lat}_{lon}";
            if (memoryCache.TryGetValue(cacheKey, out OpenMeteoWeatherData cachedData))
            {
                return cachedData;
            }

            var queryParams = new Dictionary<string, string?>
            {
                ["latitude"] = lat.ToString(),
                ["longitude"] = lon.ToString(),
                ["daily"] = "sunrise,sunset,weather_code,temperature_2m_max,wind_speed_10m_max,wind_direction_10m_dominant,uv_index_max,precipitation_sum,temperature_2m_min,wind_gusts_10m_max,precipitation_probability_max,pressure_msl_max,pressure_msl_min,relative_humidity_2m_mean,cloud_cover_mean,apparent_temperature_max,apparent_temperature_min",
                ["hourly"] = "temperature_2m,relative_humidity_2m,apparent_temperature,precipitation_probability,precipitation,weather_code,cloud_cover,wind_speed_10m,wind_direction_10m,uv_index,wind_gusts_10m,pressure_msl,is_day",
                ["current"] = "temperature_2m,relative_humidity_2m,apparent_temperature,weather_code,cloud_cover,precipitation,wind_speed_10m,wind_direction_10m,pressure_msl,wind_gusts_10m",
                ["timezone"] = "auto",
                ["past_days"] = WeatherHelper.PastDays.ToString(),
                ["forecast_days"] = WeatherHelper.Days.ToString(),
                ["wind_speed_unit"] = "ms"
            };
            string url = QueryHelpers.AddQueryString("https://api.open-meteo.com/v1/forecast", queryParams);

            try
            {
                var res = await httpClient.GetAsync(url);
                if (!res.IsSuccessStatusCode)
                {
                    return null;
                }

                var json = await res.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(json))
                {
                    return null;
                }

                var data = JsonSerializer.Deserialize<OpenMeteoWeatherData>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                if(data != null)
                {
                    memoryCache.Set(cacheKey, data, TimeSpan.FromMinutes(15));
                }
                return data;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Weather API error: {ex.ToString()}");
                return null;
            }
        }

        public async Task<OpenMeteoGeocodingData?> GetGeocodingData(string location)
        {
            string cacheKey = $"geocoding_{location.Trim().ToLower()}";
            if (memoryCache.TryGetValue(cacheKey, out OpenMeteoGeocodingData cachedData))
            {
                return cachedData;
            }

            var queryParams = new Dictionary<string, string?>
            {
                ["name"] = location,
                ["count"] = "10",
                ["language"] = "en",
                ["format"] = "json"
            };
            string url = QueryHelpers.AddQueryString("https://geocoding-api.open-meteo.com/v1/search", queryParams);

            try
            {
                var res = await httpClient.GetAsync(url);
                if (!res.IsSuccessStatusCode)
                {
                    return null;
                }

                var json = await res.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(json))
                {
                    return null;
                }

                var data = JsonSerializer.Deserialize<OpenMeteoGeocodingData>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                if(data != null)
                {
                    memoryCache.Set(cacheKey, data, TimeSpan.FromMinutes(15));
                }
                return data;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Geocoding API error: {ex.ToString()}");
                return null;
            }
        }

        public async Task<Coordinates?> GetGeocodingByIp(string ip)
        {
            string baseUrl = "http://ip-api.com";
            string url = string.IsNullOrEmpty(ip)
                ? $"{baseUrl}/json?fields=city,lat,lon"
                : $"{baseUrl}/{ip}/json?fields=city,lat,lon";

            try
            {
                var res = await httpClient.GetAsync(url);
                if (!res.IsSuccessStatusCode)
                {
                    return null;
                }

                var json = await res.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(json))
                {
                    return null;
                }

                var data = JsonSerializer.Deserialize<Coordinates>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                });
                return data;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Geocoding by IP API error: {ex.ToString()}");
                return null;
            }
        }
    }

    public class Coordinates
    {
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}
