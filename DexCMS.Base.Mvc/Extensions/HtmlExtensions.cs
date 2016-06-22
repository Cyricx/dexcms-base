using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DexCMS.Base.Models;
using DexCMS.Base.Mvc.Models;

namespace DexCMS.Base.Mvc.Extensions
{
    public static class HtmlExtension
    {
        public static string BuildContentUrl(this HtmlHelper html, ContentRequest request)
        {
            return UrlBuilder.BuildUrl(request);
        }

        public static string BuildContentUrl(this HtmlHelper html, PageContent content)
        {
            if (content != null)
            {
                return UrlBuilder.BuildUrl(content);
            }
            else
            {
                return null;
            }

        }

        public static MvcHtmlString BuildContentLink(this HtmlHelper html, string contentTitle, ContentRequest request)
        {
            TagBuilder tag = new TagBuilder("a");
            tag.Attributes["title"] = contentTitle;
            tag.Attributes["href"] = UrlHelper.GenerateContentUrl(html.BuildContentUrl(request).ToString(),
                new HttpContextWrapper(HttpContext.Current));
            tag.InnerHtml = contentTitle;
            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString CheckBoxList(this HtmlHelper html, string name, List<CheckBoxItem> items)
        {
            StringBuilder result = new StringBuilder();

            TagBuilder ul = new TagBuilder("ul");

            foreach (var item in items)
            {
                TagBuilder li = new TagBuilder("li");

                TagBuilder input = new TagBuilder("input");
                if (item.IsSelected)
                {
                    input.MergeAttribute("checked", "");
                }
                input.MergeAttribute("type", "checkbox");
                input.MergeAttribute("name", name);
                input.MergeAttribute("id", "cb" + item.ID);
                input.MergeAttribute("value", item.ID.ToString());
                li.InnerHtml += input.ToString();

                TagBuilder label = new TagBuilder("label");
                label.MergeAttribute("for", "cb" + item.ID);
                label.AddCssClass("form-lbl");
                TagBuilder pre = new TagBuilder("pre");
                pre.InnerHtml = HttpUtility.HtmlEncode(item.Name);
                label.InnerHtml = pre.ToString();
                li.InnerHtml += label.ToString();

                ul.InnerHtml += li.ToString();
            }
            result.Append(ul.ToString());

            return MvcHtmlString.Create(result.ToString());
        }

    }

}
