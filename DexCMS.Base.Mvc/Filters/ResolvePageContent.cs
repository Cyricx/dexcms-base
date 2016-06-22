using System;
using System.Web.Mvc;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Models;

namespace DexCMS.Base.Mvc.Filters
{
    public class ResolvePageContent : ActionFilterAttribute
    {
        IPageContentRepository repository;

        public ResolvePageContent(IPageContentRepository _repo)
        {
            repository = _repo;
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Controller.ViewBag.PageContent == null)
            {
                PageContent content = new PageContent();
                string[] ContentSearchActions = { "RetrieveContent", "RetrieveContentByType" };

                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();
                string area = filterContext.RouteData.Values["area"]?.ToString();

                string subCategory = filterContext.RouteData.Values["subCategory"]?.ToString();
                string category = filterContext.RouteData.Values["category"]?.ToString();
                if (String.IsNullOrEmpty(category))
                {
                    category = controller == "PublicContent" ? null : controller;
                } else if (category == "none")
                {
                    category = null;
                }

                string routeUrlSegment = filterContext.RouteData.Values["urlSegment"]?.ToString();
                string urlSegment = !String.IsNullOrEmpty(routeUrlSegment) ? routeUrlSegment : action;

                area = area == null ? "" : area;

                content = repository.RetrieveAsync(urlSegment, area, category, subCategory).Result;
                
                if (content == null)
                {
                    content = new PageContent
                    {
                        Heading = urlSegment + " " + category,
                        PageTitle = urlSegment + " " + category,
                        PageContentID = -1,
                        ContentArea = new ContentArea { Name = area },
                        ContentCategory = new ContentCategory {  Name = category },
                        ContentSubCategory = new ContentSubCategory { Name = subCategory },
                        UrlSegment = urlSegment
                    };
                }

                filterContext.Controller.ViewBag.PageContent = content;
            }
        }//end on result executing

    }
}
