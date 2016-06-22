using System.Collections.Generic;
using System.Web.Mvc;

namespace DexCMS.Base.Mvc.Filters
{
    public class SavePageRequest : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            List<string> pages = new List<string>();
            if (filterContext.HttpContext.Session["pages"] != null)
            {
                pages = (List<string>)filterContext.HttpContext.Session["pages"];
            }

            if (filterContext.RequestContext.HttpContext.Request.UrlReferrer != null)
            {
                if (pages.Count == 0 ||
                    (pages.Count > 0 &&
                    pages[pages.Count - 1] != filterContext.RequestContext.HttpContext.Request.UrlReferrer.ToString()))
                {
                    pages.Add(filterContext.RequestContext.HttpContext.Request.UrlReferrer.ToString());
                }
            }
            else
            {
                pages.Add("Type-in or bookmark");
            }
            filterContext.RequestContext.HttpContext.Session["pages"] = pages;
        }//end on action executing
    }

}
