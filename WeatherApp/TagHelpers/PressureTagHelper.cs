using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("pressure")]
    public class PressureTagHelper : TagHelper
    {
        [HtmlAttributeName("value")]
        public double Value { get; set; }

        [HtmlAttributeName("unit")]
        public string Unit { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string pressure = WeatherHelper.ConvertPressure(Value, Unit);
            output.TagName = "span";
            output.Content.SetContent(pressure);
        }
    }
}
