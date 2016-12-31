using DexCMS.Base.HelperModels;
using DexCMS.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DexCMS.Base.Mvc.Helpers
{
    public static class PageContentFactory
    {
        public static RoutePageRequest RetrievePageRequest(ControllerContext filterContext, IPageContentRepository repository)
        {
            RoutePageRequest routeRequest = new RoutePageRequest();

            routeRequest.UrlSegment = filterContext.RouteData.Values["urlSegment"] == null ? filterContext.RouteData.Values["action"].ToString() : filterContext.RouteData.Values["urlSegment"].ToString();

            routeRequest.Area = filterContext.RouteData.Values["area"] == null ? "" : filterContext.RouteData.Values["area"].ToString();

            routeRequest.Category = filterContext.RouteData.Values["category"]?.ToString();
            if (string.IsNullOrEmpty(routeRequest.Category))
            {
                string controller = filterContext.RouteData.Values["controller"].ToString();
                routeRequest.Category = controller != "PublicContent" ? controller : null;
            }

            routeRequest.Category = routeRequest.Category == "none" ? null : routeRequest.Category;

            routeRequest.SubCategory = filterContext.RouteData.Values["subCategory"]?.ToString();

            routeRequest.PageContent = repository.RetrieveAsync(routeRequest).Result;
            return routeRequest;
        }

    }
}
