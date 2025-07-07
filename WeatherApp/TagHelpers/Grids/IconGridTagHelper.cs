using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers.Grids
{
    [HtmlTargetElement("icon-grid")]
    public class IconGridTagHelper : GridTagHelper<(int Code, byte IsDay)>
    {
        protected override string BuildGridItem(int hour)
        {
            var code = Data[hour].Code;
            WeatherConditionSvgPair weatherPair = WeatherHelper.GetWeatherSvgPair(code);
            string dayOrNight = Data[hour].IsDay == 1 ? "d" : "n";
            string weatherDescription = WeatherHelper.GetWeatherDescription(code);

            return $@"
                <div class=""text-center"">
                    <div title=""{weatherDescription}"">
                        <div>
                            <img src=""/svg/weather/{weatherPair.Clouds} {dayOrNight}.svg"" width=""50"" />
                        </div>
                        <div>
                            <img src=""/svg/weather/{weatherPair.Precipitation}.svg"" width=""32"" />
                        </div>
                    </div>
                </div>
            ";
        }
    }
}
