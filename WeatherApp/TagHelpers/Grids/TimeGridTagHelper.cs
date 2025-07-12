using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("time-grid")]
    public class TimeGridTagHelper : GridTagHelper<DateTime>
    {
        [HtmlAttributeName("local-now")]
        public DateTime LocalNow { get; set; }

        [HtmlAttributeName("day-date")]
        public DateTime SelectedDayDate { get; set; }

        protected override string BuildGridItem(int hour)
        {
            var time = Data[hour];
            var backgroundColor = LocalNow > time ? "#ededed" : "transparent";
            return $@"
                <div class=""text-center"" style=""background-color:{backgroundColor}"">
                    <div>
                        <span>{time.ToString("HH:mm")}</span>
                    </div>
                </div>
            ";
        }
    }
}
