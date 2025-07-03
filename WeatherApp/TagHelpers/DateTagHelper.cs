using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("date")]
    public class DateTagHelper : TagHelper
    {
        [HtmlAttributeName("date")]
        public DateTime Date { get; set; }

        [HtmlAttributeName("length")]
        public string Format { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            if(Date.DayOfWeek == DayOfWeek.Sunday || Date.DayOfWeek == DayOfWeek.Saturday)
            {
                output.Attributes.SetAttribute("style", "color: red;");
            }

            string date = Format switch
            {
                "day" => Date.ToString("dd"),
                "dayWeekday" => Date.ToString("ddd, dd"),
                "dayWeekdayMonthShort" => Date.ToString("ddd, dd MMM"),
                "dayWeekdayMonthLong" => Date.ToString("ddd, dd MMMM"),
                _ => Date.ToString("ddd, dd MMMM")
            };
            output.Content.SetContent(date);
        }
    }
}
