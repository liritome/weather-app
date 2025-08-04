using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("temperature-grid")]
    public class TemperatureGridTagHelper : GridTagHelper<double>
    {
        [HtmlAttributeName("unit")]
        public string Unit { get; set; }

        protected double MinTemp => Data.Min();
        protected double MaxTemp => Data.Max();
        protected int TempBoxHeight = 30;

        protected override string BuildGridItem(int hour)
        {
            double temperature = Data[hour];
            string tempBoxColor = WeatherHelper.GetTemperatureColor(temperature);
            string temperatureFormatted = WeatherHelper.ConvertTemperature(temperature, Unit);
            int positionFromTop = (int)(MaxTemp - temperature) * 2;
            return $@"
                <div class=""position-relative"">
                    <div class=""position-absolute w-100 text-center"" style=""background-color: {tempBoxColor}; font-size: 20px; height: {TempBoxHeight}px; top: {positionFromTop}px;"">
                        <span>{temperatureFormatted}</span>
                    </div>
                </div>
            ";
        }
        protected override string GetAdditionalStyle()
        {
            double tempDifferenceDay = MaxTemp - MinTemp;
            return $"height: {TempBoxHeight + tempDifferenceDay * 2}px";
        }
    }
}
