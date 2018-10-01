using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCProject.TagHelpers
{
    [HtmlTargetElement("email",TagStructure =TagStructure.NormalOrSelfClosing) ]
    public class EmailTagHelper : TagHelper
    {
        public string MailTo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            //output.TagMode
            output.Attributes.SetAttribute("href","mailto:"+MailTo+"@hexaware.com");
            output.Content.SetContent("Click Me");
           // base.Process(context, output);
        }

        //public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        //{
        //    return base.ProcessAsync(context, output);
        //}
    }

    [HtmlTargetElement("thumbnail", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class ThumbnailTagHelper : TagHelper
    {

        public string Caption { get; set; }
        public string ImagePath { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "thumbnail";
            output.TagMode = TagMode.StartTagAndEndTag;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class='col-sm-2'>");
            sb.AppendLine("<div style ='height:200Px'>");
            sb.AppendLine("<figure>");
            sb.AppendLine("<img src='/images/"+ ImagePath+"' class=thumbnail style=max-height:inherit; max-width:25px/>");
            sb.AppendLine("<figcaption>"+Caption+"</figcaption>");
            sb.AppendLine("</figure>");
            sb.AppendLine("<a href ='/images/"+ImagePath+"' class=btn btn - primary>View</a>");
            sb.Append(" </div>");
            sb.Append(" </div>");

            output.PreContent.SetHtmlContent(sb.ToString());

        }
    }
}
