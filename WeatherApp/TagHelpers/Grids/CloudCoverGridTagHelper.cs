using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("cloud-cover-grid")]
    public class CloudCoverGridTagHelper : GridTagHelper<int>
    {
        protected override string BuildGridItem(int hour)
        {
            var cloudCover = Data[hour];
            var cloudCoverColor = WeatherHelper.GetCloudCoverColor(cloudCover);
            return $@"
                <div class=""text-center"" style=""font-size: 20px; background-color: {cloudCoverColor};"">
                    <span>{cloudCover}</span>
                </div>
            ";
        }
    }
}
