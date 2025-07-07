using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WeatherApp.TagHelpers
{
    [HtmlTargetElement("time-grid")]
    public class TimeGridTagHelper : GridTagHelper<DateTime>
    {
        [HtmlAttributeName("current-local-date")]
        public DateTime CurrentLocalDate { get; set; }

        [HtmlAttributeName("day-date")]
        public DateTime DayDate { get; set; }

        protected override string BuildGridItem(int hour)
        {
            var time = Data[hour];
            var backgroundColor = CurrentLocalDate > DayDate.AddHours(hour) ? "#ededed" : "transparent";
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
