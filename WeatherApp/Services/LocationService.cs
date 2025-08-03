namespace WeatherApp.Services
{
    public class LocationService
    {
        public (string name, int id)? ParseLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                return null;
            }
            int lastDashIndex = location.LastIndexOf('-');
            if (lastDashIndex <= 0)
            {
                return null;
            }
            string name = location.Substring(0, lastDashIndex);
            string id = location.Substring(lastDashIndex + 1);
            if (int.TryParse(id, out int idNum))
            {
                return (name, idNum);
            }
            return null;
        }
    }
}
