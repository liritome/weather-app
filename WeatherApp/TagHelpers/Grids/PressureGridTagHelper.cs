using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("pressure-grid")]
    public class PressureGridTagHelper : GridTagHelper<double>
    {
        [HtmlAttributeName("unit")]
        public string Unit { get; set; }

        protected double MaxPressure => Data.Max();
        protected double MinPressure => Data.Min();
        protected int PressureBoxHeight = 30;

        protected override string BuildGridItem(int hour)
        {
            double pressure = Data[hour];
            string pressureBoxColor = WeatherHelper.GetPressureColor(pressure);
            string pressureFormatted = WeatherHelper.ConvertPressure(pressure, Unit);
            int positionFromTop = (int)(MaxPressure - pressure) * 2;
            return $@"
                <div class=""position-relative"">
                    <div class=""position-absolute w-100 text-center"" style=""background-color: {pressureBoxColor}; font-size: 20px; height: {PressureBoxHeight}px; top: {positionFromTop}px;"">
                        <span>{pressureFormatted}</span>
                    </div>
                </div>
            ";
        }

        protected override string GetAdditionalStyle()
        {
            double pressureDifferenceDay = MaxPressure - MinPressure;
            return $"height: {PressureBoxHeight + pressureDifferenceDay * 2}px;";
        }
    }
}
