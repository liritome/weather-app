using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualBasic;
using System.Text;
using WeatherApp.Models;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("time-grid")]
    public class TimeGridTagHelper : TagHelper
    {
        [HtmlAttributeName("data")]
        public List<DateTime> Times { get; set; }

        [HtmlAttributeName("step")]
        public int Step { get; set; }

        [HtmlAttributeName("item-width")]
        public double ItemWidth { get; set; }

        [HtmlAttributeName("current-local-date")]
        public DateTime CurrentLocalDate { get; set; }

        [HtmlAttributeName("day-date")]
        public DateTime DayDate { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "d-grid");
            int hours = Times.Count;
            int itemsTotal = (int)Math.Ceiling(hours / (double)Step);
            output.Attributes.SetAttribute("style", $"grid-template-columns: repeat({itemsTotal}, {ItemWidth}px);");

            var content = new StringBuilder();
            for (int hour = 0; hour < hours; hour += Step)
            {
                var time = Times[hour];
                var backgroundColor = CurrentLocalDate > DayDate.AddHours(hour) ? "#ededed" : "transparent";
                content.Append($@"
                    <div class=""text-center"" style=""background-color:{backgroundColor}"">
                        <div>
                            <span>{time.ToString("HH:mm")}</span>
                        </div>
                    </div>
                ");
            }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
