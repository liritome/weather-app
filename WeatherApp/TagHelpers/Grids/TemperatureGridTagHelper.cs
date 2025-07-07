using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;
using WeatherApp.Helpers;
using WeatherApp.Models;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("temperature-grid")]
    public class TemperatureGridTagHelper : TagHelper
    {
        [HtmlAttributeName("data")]
        public List<double> Temperature { get; set; }

        [HtmlAttributeName("step")]
        public int Step { get; set; }

        [HtmlAttributeName("item-width")]
        public double ItemWidth { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "d-grid");
            int hours = Temperature.Count;
            int itemsTotal = (int)Math.Ceiling(hours / (double)Step);

            double minTemp = Temperature.Min();
            double maxTemp = Temperature.Max();
            double tempDifferenceDay = maxTemp - minTemp;
            int tempBoxHeight = 30;
            output.Attributes.SetAttribute("style", $"grid-template-columns: repeat({itemsTotal}, {ItemWidth}px); height: {tempBoxHeight + tempDifferenceDay * 2}px");

            var content = new StringBuilder();
            for (int hour = 0; hour < hours; hour += Step)
            {
                double temperature = Temperature[hour];
                string temperatureFormatted = (temperature > 0 ? "+" : "") + temperature;
                int positionFromTop = (int)(maxTemp - temperature) * 2;
                string tempBoxColor = WeatherHelper.GetTemperatureColor(temperature);
                content.Append($@"
                    <div class=""position-relative"">
                        <div class=""position-absolute w-100 text-center"" style=""background-color: {tempBoxColor}; font-size: 20px; height: {tempBoxHeight}px; top: {positionFromTop}px;"">
                            <span>{temperatureFormatted}</span>
                        </div>
                    </div>
                ");
            }
            output.Content.SetHtmlContent(content.ToString());
            /*for (int hour = 0; hour < hours; hour += Step)
            {
                double temp = Temperature[hour];
                int positionFromTop = (int)(maxTemp - temp) * 2;
                string tempBoxColor = WeatherHelper.GetTemperatureColor(temp);

                string temperatureTagHelper = TagHelperRenderer.Render(new TemperatureTagHelper { Value = temp });

                var tempDiv = new TagBuilder("div");
                tempDiv.AddCssClass("position-absolute w-100 text-center");
                tempDiv.Attributes.Add("style", $"background-color: {tempBoxColor}; font-size: 20px; height: {tempBoxHeight}px; top: {positionFromTop}px;");
                tempDiv.InnerHtml.AppendHtml(temperatureTagHelper);

                var mainDiv = new TagBuilder("div");
                mainDiv.AddCssClass("position-relative");
                mainDiv.InnerHtml.AppendHtml(tempDiv);

                output.Content.AppendHtml(mainDiv);
            }*/
        }
    }
}
