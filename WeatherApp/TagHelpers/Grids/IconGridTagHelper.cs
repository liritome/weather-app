using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers.Grids
{
    [HtmlTargetElement("icon-grid")]
    public class IconGridTagHelper : GridTagHelper<(int Code, byte IsDay)>
    {
        [HtmlAttributeName("width")]
        public double Width { get; set; }

        protected override string BuildGridItem(int hour)
        {
            double ratio = 0.64;
            var code = Data[hour].Code;
            WeatherConditionSvgPair weatherPair = WeatherHelper.GetWeatherSvgPair(code);
            string isDay = Data[hour].IsDay == 1 ? "d" : "n";
            string weatherDescription = WeatherHelper.GetWeatherDescription(code);

            return $@"
                <div class=""text-center"">
                    <div title=""{weatherDescription}"">
                        <div>
                            <img src=""/svg/weather/{weatherPair.Clouds} {isDay}.svg"" width=""{Width}"" />
                        </div>
                        <div>
                            <img src=""/svg/weather/{weatherPair.Precipitation}.svg"" width=""{Width * ratio}"" />
                        </div>
                    </div>
                </div>
            ";
        }
    }
}
