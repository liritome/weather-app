using System.Text;

namespace WeatherApp.Helpers
{
    public static class WeatherHelper
    {
        public static readonly Dictionary<int, string> CodeMap = new()
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

        public static readonly string[] Directions =
        {
            "N", "NNE", "NE", "ENE",
            "E", "ESE", "SE", "SSE",
            "S", "SSW", "SW", "WSW",
            "W", "WNW", "NW", "NNW"
        };

        public static string GetWeatherDescription(int code)
        {
            return CodeMap.TryGetValue(code, out var description) ? description : string.Empty;
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
}