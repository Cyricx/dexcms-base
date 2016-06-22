using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DexCMS.Base.Mvc.Extensions
{
    public static class EditorForExtensions
    {
        public static MvcHtmlString TTCMSEditorFor<TModel, TValue>(
    this HtmlHelper<TModel> htmlHelper,
    Expression<Func<TModel, TValue>> ex, string iconClass = "", string addClasses = "")
        {
            var div = new TagBuilder("div");
            div.AddCssClass(addClasses);
            div.AddCssClass("form-item-group");
            if (!string.IsNullOrEmpty(iconClass))
            {
                var i = new TagBuilder("i");
                i.AddCssClass("form-item-icon");
                i.AddCssClass(iconClass);
                div.InnerHtml += i.ToString();
            }
            var metaData = ModelMetadata.FromLambdaExpression<TModel, TValue>(ex, htmlHelper.ViewData);
            if (!string.IsNullOrEmpty(metaData.Watermark))
            {
                div.InnerHtml += EditorExtensions.EditorFor<TModel, TValue>(htmlHelper, ex,
    new { htmlAttributes = new { placeholder = metaData.Watermark } });
            }
            else
            {
                div.InnerHtml += EditorExtensions.EditorFor<TModel, TValue>(htmlHelper, ex).ToHtmlString();
            }
            return MvcHtmlString.Create(div.ToString());
        }
    }

}
