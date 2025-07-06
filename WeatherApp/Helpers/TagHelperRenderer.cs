using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;
using WeatherApp.TagHelpers;

namespace WeatherApp.Helpers
{
    public static class TagHelperRenderer
    {
        public static string Render<T>(T tagHelper) where T : TagHelper
        {
            var context = new TagHelperContext(
                allAttributes: [],
                items: new Dictionary<object, object>(),
                uniqueId: Guid.NewGuid().ToString("N")
            );
            var output = new TagHelperOutput(
                tagName: "",
                attributes: new TagHelperAttributeList(),
                getChildContentAsync: (useCachedResult, encoder) =>
                    Task.FromResult<TagHelperContent>(new DefaultTagHelperContent())
            );
            tagHelper.Process(context, output);
            using var writer = new StringWriter();
            output.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}
