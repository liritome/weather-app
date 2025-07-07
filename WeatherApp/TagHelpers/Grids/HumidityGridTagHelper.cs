using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("humidity-grid")]
    public class HumidityGridTagHelper : GridTagHelper<int>
    {
        protected override string BuildGridItem(int hour)
        {
            var humidity = Data[hour];
            var humidityBoxColor = WeatherHelper.GetHumidityColor(humidity);
            return $@"
                <div class=""text-center"" style=""font-size: 20px; background-color: {humidityBoxColor};"">
                    <span>{humidity}</span>
                </div>
            ";
        }
    }
}
