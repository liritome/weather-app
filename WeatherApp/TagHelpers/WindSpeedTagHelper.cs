using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("wind-speed")]
    public class WindSpeedTagHelper : TagHelper
    {
        [HtmlAttributeName("value")]
        public double Value { get; set; }

        [HtmlAttributeName("unit")]
        public string Unit { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string speed = WeatherHelper.ConvertSpeed(Value, Unit);
            output.TagName = "span";
            output.Content.SetContent(speed);
        }
    }
}
