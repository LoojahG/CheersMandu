using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CheersMandu.TagHelpers
{
    public class MyBoldTagHelper:TagHelper
    {
             public string Content { get; set; }

            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                output.TagName = "b";
            }
    }
}
