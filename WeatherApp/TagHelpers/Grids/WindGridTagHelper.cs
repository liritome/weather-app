using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("wind-grid")]
    public class WindGridTagHelper : GridTagHelper<double>
    {
        protected override string BuildGridItem(int hour)
        {
            double wind = Data[hour];
            string windColor = WeatherHelper.GetWindColor(wind);
            return $@"
                <div class=""mx-2 text-center"" style=""font-size: 20px; background: linear-gradient(to right, transparent, {windColor}); transform: skew(-12deg);"">
                    <span>{wind}</span>
                </div>
            ";
        }
    }
}
