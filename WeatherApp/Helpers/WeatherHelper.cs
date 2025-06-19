using System.Text;

namespace WeatherApp.Helpers
{
    public static class WeatherHelper
    {
        public static readonly Dictionary<int, string> CodeDescriptionMap = new()
        {
            { 0, "Clear" },
            { 1, "Mainly clear" },
            { 2, "Partly cloudy" },
            { 3, "Overcast" },
            { 45, "Fog" },
            { 48, "Depositing rime fog" },
            { 51, "Light drizzle" },
            { 53, "Moderate drizzle" },
            { 55, "Dense drizzle" },
            { 56, "Light freezing drizzle" },
            { 57, "Dense freezing drizzle" },
            { 61, "Slight rain" },
            { 63, "Moderate rain" },
            { 65, "Heavy rain" },
            { 66, "Light freezing rain" },
            { 67, "Heavy freezing rain" },
            { 71, "Slight snowfall" },
            { 73, "Moderate snowfall" },
            { 75, "Heavy snowfall" },
            { 77, "Snow grains" },
            { 80, "Slight rain showers" },
            { 81, "Moderate rain showers" },
            { 82, "Violent rain showers" },
            { 85, "Slight snow showers" },
            { 86, "Heavy snow showers" },
            { 95, "Thunderstorm" },
            { 96, "Thunderstorm with slight hail" },
            { 99, "Thunderstorm with heavy hail" }
        };

        public static readonly Dictionary<int, WeatherSvgPair> CodeSvgMap = new()
        {
            { 0, new("clear") },
            { 1, new("cloud1") },
            { 2, new("cloud2") },
            { 3, new("cloud3") },
            { 45, new("fog") },
            { 48, new("fog") },
            { 51, new("cloud1", "rain1") },
            { 53, new("cloud2", "rain2") },
            { 55, new("cloud3", "rain3") },
            { 56, new("cloud1", "rain-snow1") },
            { 57, new("cloud3", "rain-snow3") },
            { 61, new("cloud1", "rain1") },
            { 63, new("cloud2", "rain2") },
            { 65, new("cloud3", "rain3") },
            { 66, new("cloud1", "rain-snow1") },
            { 67, new("cloud3", "rain-snow3") },
            { 71, new("cloud1", "snow1") },
            { 73, new("cloud2", "snow2") },
            { 75, new("cloud3", "snow3") },
            { 77, new("cloud3", "hail2") },
            { 80, new("cloud1", "rain1") },
            { 81, new("cloud2", "rain2") },
            { 82, new("cloud3", "rain3") },
            { 85, new("cloud1", "snow1") },
            { 86, new("cloud3", "snow3") },
            { 95, new("cloud3", "storm") },
            { 96, new("cloud3", "hail1") },
            { 99, new("cloud3", "hail3") }
        };

        public static readonly string[] Directions =
        {
            "N", "NNE", "NE", "ENE",
            "E", "ESE", "SE", "SSE",
            "S", "SSW", "SW", "WSW",
            "W", "WNW", "NW", "NNW"
        };

        public static Dictionary<int, string> Days = new()
    {
        { -1, "Yesterday" },
        { 0, "Today" },
        { 1, "Tomorrow" },
        { 2, "in 2 days" },
        { 3, "in 3 days" },
        { 4, "in 4 days" },
        { 5, "in 5 days" },
        { 6, "in 6 days" },
        { 7, "in 7 days" },
        { 8, "in 8 days" },
        { 9, "in 9 days" },
        { 10, "in 10 days" },
        { 11, "in 11 days" },
        { 12, "in 12 days" },
        { 13, "in 13 days" }
    };

        public static string GetWeatherDescription(int code)
        {
            return CodeDescriptionMap.TryGetValue(code, out var description) ? description : "Unknown";
        }

        public static WeatherSvgPair GetWeatherSvg(int code)
        {
            return CodeSvgMap.TryGetValue(code, out var svg) ? svg : new WeatherSvgPair("unknown");
        }

        public static string GetWindDirection(int degrees)
        {
            int degreesMax = 360;
            int sectionsCount = Directions.Length;
            int section = (int)Math.Round(degrees / ((double)degreesMax / sectionsCount)) % sectionsCount;
            return Directions[section];
        }

        public static double GetSunAngle(DateTime now, DateTime sunrise, DateTime sunset)
        {
            double angle = 0;
            if (sunrise != sunset)
            {
                if (now >= sunrise && now <= sunset)
                {
                    angle = (now - sunrise) / (sunset - sunrise) * 180 - 90;
                }
                else if (now > sunset)
                {
                    angle = (now - sunset) / (sunrise.AddDays(1) - sunset) * 180 + 90;
                }
                else
                {
                    angle = (now - sunset.AddDays(-1)) / (sunrise - sunset.AddDays(-1)) * 180 + 90;
                }
            }
            return angle;
        }
    }

    public record WeatherSvgPair(string Condition, string? Precipitation = "none");
}