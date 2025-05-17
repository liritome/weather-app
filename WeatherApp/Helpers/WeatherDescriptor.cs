using System.Text;

namespace WeatherApp.Helpers
{
    public static class WeatherDescriptor
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

        public static string GetCondition(int code)
        {
            return CodeMap.TryGetValue(code, out var description) ? description : string.Empty;
        }

        public static readonly string[] Directions =
        {
            "E", "ENE", "NE", "NNE", "N", "NNW", "NW", "WNW",
            "W", "WSW", "SW", "SSW", "S", "SSE", "SE", "ESE"
        };

        public static string GetWindDirection(int degrees)
        {
            int degreesMax = 360;
            int sectionsCount = 16;
            int section = (int)Math.Round(degrees / ((double)degreesMax / sectionsCount));
            return Directions[section];
        }

        public static string DrawSunPosition(int sunrise, int sunset, int current)
        {
            bool space = true;
            StringBuilder sb = new StringBuilder();
            for(int i = sunrise; i < current; i++)
            {
                sb.Append('-');
            }
            sb.Append("☀︎");
            for (int i = current + 1; i < sunset; i++)
            {
                if(space)
                    sb.Append(' ');
                else
                    sb.Append('-');
                space = !space;
            }
            return sb.ToString();
        }
    }
}