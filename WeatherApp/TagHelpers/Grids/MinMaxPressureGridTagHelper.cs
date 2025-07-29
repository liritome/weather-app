using Microsoft.AspNetCore.Razor.TagHelpers;
using WeatherApp.Helpers;

namespace WeatherApp.TagHelpers.Grids
{
    [HtmlTargetElement("min-max-pressure-grid")]

    public class MinMaxPressureGridTagHelper : GridTagHelper<(double Min, double Max)>
    {
        protected double MinPressureInData => Data.Min(d => d.Min);
        protected double MaxPressureInData => Data.Max(d => d.Max);

        protected override string BuildGridItem(int hour)
        {
            double pressureMin = Data[hour].Min;
            double pressureMax = Data[hour].Max;
            int positionFromTop = (int)(MaxPressureInData - pressureMax) * 2;
            string pressureBoxColor = WeatherHelper.GetPressureColor(pressureMax);
            int PressureBoxHeight = (int)(pressureMax - pressureMin) * 2;
            return $@"
                <div class=""position-relative"">
                    <div class=""position-absolute w-100 text-center"" style=""font-size: 20px; top: {positionFromTop}px;"">
                        <span>{pressureMax}</span>
                        <div style=""background-color: {pressureBoxColor}; height: {PressureBoxHeight}px;""></div>
                        <span>{pressureMin}</span>
                    </div>
                </div>
            ";
        }
        protected override string GetAdditionalStyle()
        {
            double pressureDifference = MaxPressureInData - MinPressureInData;
            return $"height: {pressureDifference * 2 + 72}px";
        }
    }
}
