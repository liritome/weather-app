using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("pressure-grid")]
    public class PressureGridTagHelper : TagHelper
    {
        [HtmlAttributeName("data")]
        public List<double> Pressure { get; set; }

        [HtmlAttributeName("step")]
        public int Step { get; set; }

        [HtmlAttributeName("item-width")]
        public double ItemWidth { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "d-grid");
            int hours = Pressure.Count;
            int itemsTotal = (int)Math.Ceiling(hours / (double)Step);

            double minPressureDay = Pressure.Min();
            double maxPressureDay = Pressure.Max();
            double pressureDifferenceDay = maxPressureDay - minPressureDay;
            int pressureBoxHeight = 30;

            output.Attributes.SetAttribute("style", $"grid-template-columns: repeat({itemsTotal}, {ItemWidth}px); height: {pressureBoxHeight + pressureDifferenceDay * 2}px");

            var content = new StringBuilder();
            for (int hour = 0; hour < hours; hour += Step)
            {
                double pressure = Pressure[hour];
                int positionFromTop = (int)(maxPressureDay - pressure) * 2;
                string pressureBoxColor = WeatherHelper.GetPressureColor(pressure);
                content.Append($@"
                    <div class=""position-relative"">
                        <div class=""position-absolute w-100 text-center"" style=""background-color: {pressureBoxColor}; font-size: 20px; height: {pressureBoxHeight}px; top: {positionFromTop}px;"">
                            <span>{pressure}</span>
                        </div>
                    </div>
                ");
            }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
