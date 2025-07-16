using System.Drawing;
using System.Text;

namespace WeatherApp.Helpers
{
    public static class WeatherHelper
    {
        public static readonly int PastDays= 15;
        public static readonly int Days = 15;

        private static readonly Color waterDark = Color.FromArgb(28, 151, 252);
        private static readonly Color waterLight = Color.FromArgb(131, 199, 255);
        private static readonly Color gray = Color.FromArgb(173, 173, 173);
        private static readonly Color grayLight = Color.FromArgb(224, 224, 224);

        // Temperature
        private static readonly double maxTemperaturePossible = 60;
        private static readonly double minTemperaturePossible = -90;

        private static readonly Color violetT = Color.FromArgb(255, 90, 255);
        private static readonly Color deepBlueT = Color.FromArgb(0, 0, 225);
        private static readonly Color lightBlueT = Color.FromArgb(0, 174, 255);
        private static readonly Color greenT = Color.FromArgb(0, 204, 0);
        private static readonly Color yellowT = Color.FromArgb(235, 234, 0);
        private static readonly Color redT = Color.FromArgb(240, 39, 0);
        private static readonly Color magentaT = Color.FromArgb(184, 0, 156);

        private static readonly List<(double Value, Color Color)> TemperatureColorRanges = new()
        {
            (-90, redT),
            (-50, violetT),
            (-20, deepBlueT),
            (0, lightBlueT),
            (10, greenT),
            (20, yellowT),
            (40, redT),
            (60, magentaT)
        };

        // Wind
        private static readonly double maxWindPossible = 32;
        private static readonly double minWindPossible = 0;

        private static readonly Color whiteW = Color.FromArgb(255, 255, 255);
        private static readonly Color lightGrayW = Color.FromArgb(236, 237, 238);
        private static readonly Color yellowW = Color.FromArgb(255, 235, 168);
        private static readonly Color lightRedW = Color.FromArgb(255, 168, 168);
        private static readonly Color redW = Color.FromArgb(235, 0, 0);
        private static readonly Color darkRedW = Color.FromArgb(148, 0, 0);
        private static readonly Color darkGrayW = Color.FromArgb(102, 102, 102);

        private static readonly List<(double Value, Color Color)> WindColorRanges = new()
        {
            (0, whiteW),
            (5, lightGrayW),
            (10, yellowW),
            (15, lightRedW),
            (20, redW),
            (25, darkRedW),
            (32, darkGrayW)
        };

        // Pressure
        private static readonly double maxPressurePossible = 800;
        private static readonly double minPressurePossible = 700;

        private static readonly Color blueP = Color.FromArgb(121, 161, 255);
        private static readonly Color violetP = Color.FromArgb(208, 120, 255);
        private static readonly Color pinkP = Color.FromArgb(255, 120, 183);

        private static readonly List<(double Value, Color Color)> PressureColorRanges = new()
        {
            (700, blueP),
            (760, violetP),
            (800, pinkP)
        };

        // Humidity
        private static readonly double maxHumidityPossible = 100;
        private static readonly double minHumidityPossible = 0;

        private static readonly Color whiteH = Color.FromArgb(255, 255, 255);
        private static readonly Color blueH = Color.FromArgb(131, 199, 255);

        private static readonly List<(double Value, Color Color)> HumidityColorRanges = new()
        {
            (0, whiteH),
            (100, blueH)
        };

        // Precipitation Probability
        private static readonly double maxPrecipProbPossible = 100;
        private static readonly double minPrecipProbPossible = 0;

        private static readonly Color grayPP = Color.FromArgb(173, 173, 173);
        private static readonly Color bluePP = Color.FromArgb(28, 151, 252);
        private static readonly Color darkBluePP = Color.FromArgb(0, 76, 201);

        private static readonly List<(double Value, Color Color)> PrecipProbColorRanges = new()
        {
            (0, grayPP),
            (70, bluePP),
            (100, darkBluePP)
        };

        // UV
        private static readonly double maxUvPossible = 20;
        private static readonly double minUvPossible = 0;

        private static readonly Color whiteUV = Color.FromArgb(255, 255, 255);
        private static readonly Color grayUV = Color.FromArgb(242, 242, 242);
        private static readonly Color yellowUV = Color.FromArgb(250, 236, 171);
        private static readonly Color orangeUV = Color.FromArgb(255, 153, 0);
        private static readonly Color redUV = Color.FromArgb(255, 42, 0);
        private static readonly Color violetUV = Color.FromArgb(212, 0, 149);

        private static readonly List<(double Value, Color Color)> UvColorRanges = new()
        {
            (0, whiteUV),
            (4, grayUV),
            (6, yellowUV),
            (9, orangeUV),
            (12, redUV),
            (20, violetUV)
        };

        // Cloud cover
        private static readonly double maxCloudCoverPossible = 100;
        private static readonly double minCloudCoverPossible = 0;

        private static readonly Color blueCC = Color.FromArgb(131, 199, 255);
        private static readonly Color whiteCC = Color.FromArgb(255, 255, 255);
        private static readonly Color grayCC = Color.FromArgb(168, 168, 168);

        private static readonly List<(double Value, Color Color)> CloudCoverColorRanges = new()
        {
            (0, blueCC),
            (50, whiteCC),
            (100, grayCC)
        };

        private static readonly Dictionary<int, string> WeatherCodeDescriptionMap = new()
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

        private static readonly Dictionary<int, WeatherConditionSvgPair> WeatherCodeSvgPairMap = new()
        {
            { 0, new("clear") },
            { 1, new("cloud1") },
            { 2, new("cloud2") },
            { 3, new("cloud3") },
            { 45, new("fog") },
            { 48, new("fog") },
            { 51, new("cloud1", "rain1") },
            { 53, new("cloud1", "rain2") },
            { 55, new("cloud2", "rain3") },
            { 56, new("cloud1", "rain-snow1") },
            { 57, new("cloud3", "rain-snow3") },
            { 61, new("cloud2", "rain1") },
            { 63, new("cloud3", "rain2") },
            { 65, new("cloud3", "rain3") },
            { 66, new("cloud2", "rain-snow1") },
            { 67, new("cloud3", "rain-snow3") },
            { 71, new("cloud2", "snow1") },
            { 73, new("cloud2", "snow2") },
            { 75, new("cloud3", "snow3") },
            { 77, new("cloud3", "hail2") },
            { 80, new("cloud2", "rain2") },
            { 81, new("cloud3", "rain2") },
            { 82, new("cloud3", "rain3") },
            { 85, new("cloud2", "snow1") },
            { 86, new("cloud3", "snow3") },
            { 95, new("cloud3", "storm") },
            { 96, new("cloud3", "hail1") },
            { 99, new("cloud3", "hail3") }
        };

        private static readonly Dictionary<int, string> WeatherCodeImageMap = new()
        {
            { 0, "clear" },
            { 1, "cloud1" },
            { 2, "cloud2" },
            { 3, "cloud3" },
            { 45, "fog" },
            { 48, "fog" },
            { 51, "cloud1-rain1" },
            { 53, "cloud2-rain1" },
            { 55, "cloud2-rain2" },
            { 56, "cloud1-rain1" },
            { 57, "cloud3-rain2" },
            { 61, "cloud2-rain1" },
            { 63, "cloud3-rain1" },
            { 65, "cloud3-rain2" },
            { 66, "cloud2-rain1" },
            { 67, "cloud3-rain2" },
            { 71, "cloud2-snow1" },
            { 73, "cloud3-snow1" },
            { 75, "cloud3-snow2" },
            { 77, "cloud3-hail1" },
            { 80, "cloud2-rain2" },
            { 81, "cloud2-rain2" },
            { 82, "cloud3-rain3" },
            { 85, "cloud2-snow1" },
            { 86, "cloud3-snow2" },
            { 95, "cloud3-storm1" },
            { 96, "cloud3-hail1" },
            { 99, "cloud3-hail2" }
        };

        private static readonly string[] Directions =
        {
            "N", "NNE", "NE", "ENE",
            "E", "ESE", "SE", "SSE",
            "S", "SSW", "SW", "WSW",
            "W", "WNW", "NW", "NNW"
        };

        public static string GetDayLabel(int offset)
        {
            return offset switch
            {
                -1 => "yesterday",
                0 => "today",
                1 => "tomorrow",
                _ => $"in {offset} days"
            };
        }

        public static string GetWeatherDescription(int code)
        {
            return WeatherCodeDescriptionMap.TryGetValue(code, out var description) ? description : "Unknown";
        }

        public static WeatherConditionSvgPair GetWeatherSvgPair(int code)
        {
            return WeatherCodeSvgPairMap.TryGetValue(code, out var svg) ? svg : new WeatherConditionSvgPair("unknown");
        }

        public static string GetWeatherImage(int code)
        {
            return WeatherCodeImageMap.TryGetValue(code, out var image) ? image : "unknown";
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

        private static string MapValueToColorGradient(double value, double min, double max, List<(double, Color)> colors, double opacity)
        {
            value = Math.Clamp(value, min, max);
            for (int i = 0; i < colors.Count - 1; i++)
            {
                var (v1, c1) = colors[i];
                var (v2, c2) = colors[i + 1];

                if (value >= v1 && value <= v2)
                {
                    double normalized = (value - v1) / (v2 - v1);
                    var result = InterpolateColor(c1, c2, normalized);
                    return $"rgba({result.R}, {result.G}, {result.B}, {opacity})";
                }
            }
            return "rgba(128, 128, 128, 0.3)";
        }

        private static Color InterpolateColor(Color c1, Color c2, double t)
        {
            return Color.FromArgb(
                (int)(c1.R + (c2.R - c1.R) * t),
                (int)(c1.G + (c2.G - c1.G) * t),
                (int)(c1.B + (c2.B - c1.B) * t));
        }

        public static string GetTemperatureColor(double temperature)
        {
            return MapValueToColorGradient(temperature, minTemperaturePossible, maxTemperaturePossible, TemperatureColorRanges, 0.3);
        }

        public static string GetWindColor(double wind)
        {
            return MapValueToColorGradient(wind, minWindPossible, maxWindPossible, WindColorRanges, 1);
        }

        public static string GetPressureColor(double pressure)
        {
            return MapValueToColorGradient(pressure, minPressurePossible, maxPressurePossible, PressureColorRanges, 0.4);
        }

        public static string GetHumidityColor(double humidity)
        {
            return MapValueToColorGradient(humidity, minHumidityPossible, maxHumidityPossible, HumidityColorRanges, 1);
        }

        public static string GetPrecipProbColor(double prob)
        {
            return MapValueToColorGradient(prob, minPrecipProbPossible, maxPrecipProbPossible, PrecipProbColorRanges, 1);
        }

        public static string GetUvColor(double uv)
        {
            return MapValueToColorGradient(uv, minUvPossible, maxUvPossible, UvColorRanges, 1);
        }

        public static string GetCloudCoverColor(double uv)
        {
            return MapValueToColorGradient(uv, minCloudCoverPossible, maxCloudCoverPossible, CloudCoverColorRanges, 1);
        }

        public static string GetWaterDarkColor()
        {
            return $"rgba({waterDark.R}, {waterDark.G}, {waterDark.B}, 1)";
        }

        public static string GetWaterLightColor()
        {
            return $"rgba({waterLight.R}, {waterLight.G}, {waterLight.B}, 1)";
        }

        public static string GetGrayColor()
        {
            return $"rgba({gray.R}, {gray.G}, {gray.B}, 1)";
        }

        public static string GetGrayLightColor()
        {
            return $"rgba({grayLight.R}, {grayLight.G}, {grayLight.B}, 1)";
        }
    }

    public record WeatherConditionSvgPair(string Clouds, string? Precipitation = "none");
}