using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("uv-index-grid")]
    public class UvIndexGridTagHelper : GridTagHelper<double>
    {
        protected override string BuildGridItem(int hour)
        {
            var uv = Data[hour];
            var uvBoxColor = WeatherHelper.GetUvColor(uv);
            return $@"
                <div class=""text-center"" style=""font-size: 20px; background-color: {uvBoxColor};"">
                    <span>{uv}</span>
                </div>
            ";
        }
    }
}
