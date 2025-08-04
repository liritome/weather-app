using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace WeatherApp.TagHelpers
{
    public abstract class GridTagHelper<T> : TagHelper
    {
        [HtmlAttributeName("step")]
        public int Step { get; set; }

        [HtmlAttributeName("item-width")]
        public double ItemWidth { get; set; }

        [HtmlAttributeName("data")]
        public List<T> Data { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "d-grid");
            int hours = Data.Count;
            int itemsTotal = (int)Math.Ceiling(hours / (double)Step);
            string baseStyle = $"grid-template-columns: repeat({itemsTotal}, {ItemWidth}px);";
            output.Attributes.SetAttribute("style", baseStyle + GetAdditionalStyle());

            var content = new StringBuilder();
            for (int hour = 0; hour < hours; hour += Step)
            {
                content.Append(BuildGridItem(hour));
            }
            output.Content.SetHtmlContent(content.ToString());
        }

        protected abstract string BuildGridItem(int hour);
        protected virtual string GetAdditionalStyle() => "";
    }
}
