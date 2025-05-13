namespace WeatherApp.Models
{
    public class WeatherIcon
    {
        public int Id { get; set; }
        public WeatherCondition Condition { get; set; }
        public Precipitation Precipitation { get; set; }
        public string IconName { get; set; } = "";
    }

    public enum WeatherCondition
    {
        Clear,
        PartlyCloudy,
        Cloudy,
        Overcast
    }
    public enum Precipitation
    {
        None,
        LightRain,
        Rain,
        Thunderstorm,
        LightSnow,
        Snow,
        Snowstorm
    }
}
