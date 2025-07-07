using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("wind-direction-grid")]
    public class WindDirectionGridTagHelper : GridTagHelper<int>
    {
        protected override string BuildGridItem(int hour)
        {
            int windDirectionDegree = Data[hour];
            string windDirection = WeatherHelper.GetWindDirection(windDirectionDegree);
            return $@"
                <div class=""text-center"">
                    <div>
                        <img src=""/svg/arrow-gray.svg"" width=""25"" style=""transform: rotate({windDirectionDegree}deg);"" />
                    </div>
                    <div style=""font-size: 14px;"">
                        <span>{windDirection}</span>
                    </div>
                </div>
            ";
        }
    }
}
