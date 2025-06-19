using System.Security.Cryptography;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class DayTabsViewModel
    {
        public OpenMeteoData OpenMeteoData { get; set; }
        public int DayNumber { get; set; }
        public DayTabsViewModel(OpenMeteoData openMeteoData, int dayNumber)
        {
            OpenMeteoData = openMeteoData;
            DayNumber = dayNumber;
        }
        public DateTime DayDate => DateTime.Today.AddDays(DayNumber);
    }
}
