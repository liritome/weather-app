using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("temperature")]
    public class TemperatureTagHelper : TagHelper
    {
        [HtmlAttributeName("value")]
        public double Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string temperature = (Value > 0 ? "+" : "") + Value;
            output.TagName = "span";
            output.Content.SetContent(temperature);
        }
    }
}
