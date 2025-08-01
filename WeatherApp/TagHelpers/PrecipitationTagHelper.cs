using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("precipitation")]
    public class PrecipitationTagHelper : TagHelper
    {
        [HtmlAttributeName("value")]
        public double Value { get; set; }

        [HtmlAttributeName("unit")]
        public string Unit { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string precip = WeatherHelper.ConvertPrecip(Value, Unit);
            output.TagName = "span";
            output.Content.SetContent(precip);
        }
    }
}
