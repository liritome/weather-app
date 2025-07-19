using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class OpenMeteoGeocodingData
    {
        [JsonPropertyName("results")]
        public List<Location> Locations { get; set; }

        [JsonPropertyName("generationtime_ms")]
        public double GenerationTime { get; set; }
    }
}
