using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("wind-grid")]
    public class WindGridTagHelper : TagHelper
    {
        [HtmlAttributeName("data")]
        public List<double> WindSpeed { get; set; }

        [HtmlAttributeName("step")]
        public int Step { get; set; }

        [HtmlAttributeName("item-width")]
        public double ItemWidth { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "d-grid");
            int hours = WindSpeed.Count;
            int itemsTotal = (int)Math.Ceiling(hours / (double)Step);
            output.Attributes.SetAttribute("style", $"grid-template-columns: repeat({itemsTotal}, {ItemWidth}px);");
            
            var content = new StringBuilder();
            for (int hour = 0; hour < hours; hour += Step)
            {
                double wind = WindSpeed[hour];
                string windColor = WeatherHelper.GetWindColor(wind);
                content.Append($@"
                    <div class=""mx-2 text-center"" style=""font-size: 20px; background: linear-gradient(to right, transparent, {windColor}); transform: skew(-12deg);"">
                        <span>{wind}</span>
                    </div>
                ");
            }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
