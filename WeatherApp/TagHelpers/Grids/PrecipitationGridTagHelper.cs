using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("precipitation-grid")]
    public class PrecipitationGridTagHelper : TagHelper
    {
        [HtmlAttributeName("data")]
        public List<double> Precipitation { get; set; }

        [HtmlAttributeName("step")]
        public int Step { get; set; }

        [HtmlAttributeName("item-width")]
        public double ItemWidth { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "d-grid");
            int hours = Precipitation.Count;
            int itemsTotal = (int)Math.Ceiling(hours / (double)Step);
            output.Attributes.SetAttribute("style", $"grid-template-columns: repeat({itemsTotal}, {ItemWidth}px);");

            var content = new StringBuilder();
            for (int hour = 0; hour < hours; hour += Step)
            {
                var precipitation = Precipitation[hour];
                var numberColor = precipitation == 0 ? "#adadad" : "#1c97fc";
                var waterColor = "#83c7ff";
                var display = precipitation == 0 ? "d-none" : "";
                content.Append($@"
                    <div class=""text-center"" style=""font-size: 20px;"">
                        <div class=""d-flex flex-column justify-content-end h-100"">
                            <span style=""color: {numberColor};"">{precipitation}</span>
                            <div>
                                <div>
                                    <img src=""/svg/wave.svg"" class=""w-100 d-block {display}"" />
                                </div>
                                <div style=""width: auto; height: {precipitation * 20}px; background-color: {waterColor};""></div>
                            </div>
                        </div>
                    </div>
                ");
            }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
