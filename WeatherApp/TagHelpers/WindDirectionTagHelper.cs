using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("wind-direction-grid")]
    public class WindDirectionTagHelper : TagHelper
    {
        [HtmlAttributeName("data")]
        public List<int> DirectionDegree { get; set; }

        [HtmlAttributeName("step")]
        public int Step { get; set; }

        [HtmlAttributeName("item-width")]
        public double ItemWidth { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "d-grid");
            int hours = DirectionDegree.Count;
            int itemsTotal = (int)Math.Ceiling(hours / (double)Step);

            output.Attributes.SetAttribute("style", $"grid-template-columns: repeat({itemsTotal}, {ItemWidth}px);");

            var content = new StringBuilder();
            for (int hour = 0; hour < hours; hour += Step)
            {
                int windDirectionDegree = DirectionDegree[hour];
                string windDirection = WeatherHelper.GetWindDirection(windDirectionDegree);
                content.Append($@"
                    <div class=""text-center"">
                        <div>
                            <img src=""/svg/arrow-gray.svg"" width=""25"" style=""transform: rotate({windDirectionDegree}deg);"" />
                        </div>
                        <div style=""font-size: 14px;"">
                            <span>{windDirection}</span>
                        </div>
                    </div>
                ");
            }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
