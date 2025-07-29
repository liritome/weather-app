using Azure.Core;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("temperature")]
    public class TemperatureTagHelper : TagHelper
    {
        [HtmlAttributeName("value")]
        public double Value { get; set; }

        [HtmlAttributeName("unit")]
        public string Unit { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string temperature = "";
            if (Unit == "F")
            {
                temperature = $"{WeatherHelper.CelsiusToFahrenheit(Value)}";
            }
            else
            {
                temperature = (Value > 0 ? "+" : "") + Value;
            }
            output.TagName = "span";
            output.Content.SetContent(temperature);
        }
    }
}
