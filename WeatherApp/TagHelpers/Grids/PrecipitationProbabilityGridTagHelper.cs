using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("precip-probab-grid")]
    public class PrecipitationProbabilityGridTagHelper : GridTagHelper<int>
    {
        protected override string BuildGridItem(int hour)
        {
            var precipProb = Data[hour];
            var precipProbTextColor = WeatherHelper.GetPrecipProbColor(precipProb);
            return $@"
                <div class=""text-center"" style=""font-size: 20px;"">
                    <span style=""color: {precipProbTextColor}"">{precipProb}</span>
                </div>
            ";
        }
    }
}
