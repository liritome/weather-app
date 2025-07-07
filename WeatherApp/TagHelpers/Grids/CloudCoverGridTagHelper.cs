using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("cloud-cover-grid")]
    public class CloudCoverGridTagHelper : TagHelper
    {
        [HtmlAttributeName("data")]
        public List<int> CloudCover { get; set; }

        [HtmlAttributeName("step")]
        public int Step { get; set; }

        [HtmlAttributeName("item-width")]
        public double ItemWidth { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "d-grid");
            int hours = CloudCover.Count;
            int itemsTotal = (int)Math.Ceiling(hours / (double)Step);
            output.Attributes.SetAttribute("style", $"grid-template-columns: repeat({itemsTotal}, {ItemWidth}px);");

            var content = new StringBuilder();
            for (int hour = 0; hour < hours; hour += Step)
            {
                var cloudCover = CloudCover[hour];
                var cloudCoverColor = WeatherHelper.GetCloudCoverColor(cloudCover);
                content.Append($@"
                    <div class=""text-center"" style=""font-size: 20px; background-color: {cloudCoverColor};"">
                        <span>{cloudCover}</span>
                    </div>
                ");
            }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
