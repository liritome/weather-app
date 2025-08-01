using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("min-max-temperature-grid")]
    public class MinMaxTemperatureGridTagHelper : GridTagHelper<(double Min, double Max)>
    {
        [HtmlAttributeName("unit")]
        public string Unit { get; set; }

        protected double MinTempInData => Data.Min(d => d.Min);
        protected double MaxTempInData => Data.Max(d => d.Max);

        protected override string BuildGridItem(int hour)
        {
            double tempMin = Data[hour].Min;
            double tempMax = Data[hour].Max;
            string tempFormattedMin = WeatherHelper.ConvertTemperature(tempMin, Unit);
            string tempFormattedMax = WeatherHelper.ConvertTemperature(tempMax, Unit);
            int positionFromTop = (int)(MaxTempInData - tempMax) * 2;
            string tempBoxColor = WeatherHelper.GetTemperatureColor(tempMax);
            int TempBoxHeight = (int)(tempMax - tempMin) * 2;
            return $@"
                <div class=""position-relative"">
                    <div class=""position-absolute w-100 text-center"" style=""font-size: 20px; top: {positionFromTop}px;"">
                        <span>{tempFormattedMax}</span>
                        <div style=""background-color: {tempBoxColor}; height: {TempBoxHeight}px;""></div>
                        <span>{tempFormattedMin}</span>
                    </div>
                </div>
            ";
        }
        protected override string GetAdditionalStyle()
        {
            double tempDifference = MaxTempInData - MinTempInData;
            return $"height: {tempDifference * 2 + 72}px";
        }
    }
}
