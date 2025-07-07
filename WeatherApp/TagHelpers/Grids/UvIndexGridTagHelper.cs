using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("uv-index-grid")]
    public class UvIndexGridTagHelper : TagHelper
    {
        [HtmlAttributeName("data")]
        public List<double> UvIndex { get; set; }

        [HtmlAttributeName("step")]
        public int Step { get; set; }

        [HtmlAttributeName("item-width")]
        public double ItemWidth { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "d-grid");
            int hours = UvIndex.Count;
            int itemsTotal = (int)Math.Ceiling(hours / (double)Step);
            output.Attributes.SetAttribute("style", $"grid-template-columns: repeat({itemsTotal}, {ItemWidth}px);");

            var content = new StringBuilder();
            for (int hour = 0; hour < hours; hour += Step)
            {
                var uv = UvIndex[hour];
                var uvBoxColor = WeatherHelper.GetUvColor(uv);
                content.Append($@"
                    <div class=""text-center"" style=""font-size: 20px; background-color: {uvBoxColor};"">
                        <span>{uv}</span>
                    </div>
                ");
            }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
