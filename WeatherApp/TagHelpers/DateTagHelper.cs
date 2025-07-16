using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("date")]
    public class DateTagHelper : TagHelper
    {
        [HtmlAttributeName("date")]
        public DateTime Date { get; set; }

        [HtmlAttributeName("format")]
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
                "day" => Date.Day == 1 ? Date.ToString("d MMM") : Date.ToString("%d"),
                "dayWeekday" => Date.Day == 1 ? Date.ToString("ddd, d MMM") : Date.ToString("ddd, d"),
                "dayWeekdayMonthShort" => Date.ToString("ddd, d MMM"),
                "dayWeekdayMonthLong" => Date.ToString("ddd, d MMMM"),
                _ => Date.ToString("ddd, d MMMM")
            };
            output.Content.SetContent(date);
        }
    }
}
