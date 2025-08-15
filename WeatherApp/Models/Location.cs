using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class Location
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("elevation")]
        public double Elevation { get; set; }

        [JsonPropertyName("feature_code")]
        public string FeatureCode { get; set; } = string.Empty;

        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; } = string.Empty;

        [JsonPropertyName("admin1_id")]
        public int Admin1Id { get; set; }

        [JsonPropertyName("admin2_id")]
        public int Admin2Id { get; set; }

        [JsonPropertyName("admin3_id")]
        public int Admin3Id { get; set; }

        [JsonPropertyName("admin4_id")]
        public int Admin4Id { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; } = string.Empty;

        [JsonPropertyName("population")]
        public int Population { get; set; }

        [JsonPropertyName("postcodes")]
        public List<string> Postcodes { get; set; } = new List<string>();

        [JsonPropertyName("country_id")]
        public int CountryId { get; set; }

        [JsonPropertyName("country")]
        public required string Country { get; set; }

        [JsonPropertyName("admin1")]
        public string Admin1 { get; set; } = string.Empty;

        [JsonPropertyName("admin2")]
        public string Admin2 { get; set; } = string.Empty;

        [JsonPropertyName("admin3")]
        public string Admin3 { get; set; } = string.Empty;

        [JsonPropertyName("admin4")]
        public string Admin4 { get; set; } = string.Empty;
    }
}
