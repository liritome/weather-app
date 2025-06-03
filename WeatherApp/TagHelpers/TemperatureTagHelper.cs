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
            output.TagName = "div";
            output.Attributes.SetAttribute("class", output.Attributes["class"]?.Value ?? "");
            output.Attributes.SetAttribute("style", output.Attributes["style"]?.Value ?? "");
            output.Content.SetContent(temperature);
        }
    }
}
