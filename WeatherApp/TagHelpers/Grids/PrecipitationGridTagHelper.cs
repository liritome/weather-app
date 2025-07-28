using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("precipitation-grid")]
    public class PrecipitationGridTagHelper : GridTagHelper<double>
    {
        protected override string BuildGridItem(int hour)
        {
            var precipitation = Data[hour];
            var numberColor = precipitation == 0 ? WeatherHelper.GetGrayColor() : WeatherHelper.GetWaterDarkColor();
            var waterColor = WeatherHelper.GetWaterLightColor();
            var display = precipitation == 0 ? "d-none" : "";
            return $@"
                <div class=""text-center"" style=""font-size: 20px;"">
                    <div class=""d-flex flex-column justify-content-end h-100"">
                        <span style=""color: {numberColor};"">{precipitation}</span>
                        <div>
                            <div>
                                <img src=""/svg/wave.svg"" class=""w-100 d-block {display}"" />
                            </div>
                            <div style=""width: auto; max-height: 50px; height: {precipitation * 10}px; background-color: {waterColor};""></div>
                        </div>
                    </div>
                </div>
            ";
        }
    }
}
