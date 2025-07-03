using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.VisualBasic;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("icon-grid")]
    public class IconGridTagHelper : TagHelper
    {
        [HtmlAttributeName("data")]
        public List<int> Codes { get; set; }

        [HtmlAttributeName("is-day")]
        public List<byte> IsDay { get; set; }

        [HtmlAttributeName("description")]
        public List<string> WeatherDescriptions { get; set; }

        [HtmlAttributeName("step")]
        public int Step { get; set; }

        [HtmlAttributeName("item-width")]
        public double ItemWidth { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "d-grid");
            int hours = Codes.Count;
            int itemsTotal = (int)Math.Ceiling(hours / (double)Step);
            output.Attributes.SetAttribute("style", $"grid-template-columns: repeat({itemsTotal}, {ItemWidth}px);");

            var content = new StringBuilder();
            for (int hour = 0; hour < hours; hour += Step)
            {
                var code = Codes[hour];
                WeatherConditionSvgPair weatherPair = WeatherHelper.GetWeatherSvgPair(code);
                string dayOrNight = IsDay[hour] == 1 ? "d" : "n";

                content.Append($@"
                    <div class=""text-center"">
                        <div title=""{WeatherDescriptions[hour]}"">
                            <div>
                                <img src=""/svg/weather/{weatherPair.Clouds} {dayOrNight}.svg"" width=""50"" />
                            </div>
                            <div>
                                <img src=""/svg/weather/{weatherPair.Precipitation}.svg"" width=""32"" />
                            </div>
                        </div>
                    </div>
                ");
            }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
