namespace WeatherApp.Models
{
    public class Weather
    {
        public float TemperatureC { get; set; }
        public float WindSpeed { get; set; }
        public WindDirection WindDir { get; set; }
        public float Humidity { get; set; }
        public float Pressure { get; set; }
        public float PrecipitationPercent { get; set; }
        public float PrecipitationVolume { get; set; }
        public int GeomagneticLevel { get; set; }
        public int IconId { get; set; }
        public WeatherIcon Icon { get; set; }
    }

    public enum WindDirection
    {
        North,
        NorthEast,
        East,
        SouthEast,
        South,
        SouthWest,
        West,
        NorthWest
    }
}
