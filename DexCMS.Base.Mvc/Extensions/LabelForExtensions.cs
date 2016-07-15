using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace DexCMS.Base.Mvc.Extensions
{
    public static class LabelForExtensions
    {
        public static MvcHtmlString DexCMSLabelFor<TModel, TProperty>(
            this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> ex, string addClasses = "")
        {
            string cssClasses = "form-label hide-xs hide-sm";
            if (!string.IsNullOrEmpty(addClasses))
            {
                cssClasses += " " + addClasses;
            }

            return LabelExtensions.LabelFor(htmlHelper, ex, new { @class = cssClasses });

        }
    }
}
