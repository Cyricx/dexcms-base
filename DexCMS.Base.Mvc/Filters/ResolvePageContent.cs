using System;
using System.Web.Mvc;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Models;
using DexCMS.Base.Mvc.Enums;
using DexCMS.Base.HelperModels;
using DexCMS.Base.Mvc.Helpers;

namespace DexCMS.Base.Mvc.Filters
{
    public class ResolvePageContent : ActionFilterAttribute
    {
        IPageContentRepository repository;

        public ResolvePageContent(IPageContentRepository _repo)
        {
            repository = _repo;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest() && filterContext.Controller.ViewBag.PageContent == null)
            {
                RetrivePageContent(filterContext);
            }
        }

        private void RetrivePageContent(ControllerContext filterContext)
        {
            RoutePageRequest routeRequest = PageContentFactory.RetrievePageRequest(filterContext, repository);

            if (routeRequest.PageContent == null)
            {
                string url = filterContext.HttpContext.Request.RawUrl;
                url = url.Length > 0 && url[0] == '/' ? url.Substring(1) : url;
                routeRequest.PageContent = repository.RetrieveRedirectAsync(url).Result;

                if (routeRequest.PageContent == null)
                {
                    routeRequest.PageContent = BuildDefaultPageContent(routeRequest);
                    SetPageResolution(filterContext, PageResolution.Generated);
                }
                else
                {
                    SetPageResolution(filterContext, PageResolution.Redirect);
                }
            }
            else
            {
                SetPageResolution(filterContext, PageResolution.Retrieved);
            }

            filterContext.Controller.ViewBag.PageContent = routeRequest.PageContent;
        }

        private static PageContent BuildDefaultPageContent(RoutePageRequest routeRequest)
        {
            return new PageContent
            {
                Heading = routeRequest.UrlSegment + " " + routeRequest.Category,
                PageTitle = routeRequest.UrlSegment + " " + routeRequest.Category,
                PageContentID = -1,
                ContentArea = new ContentArea { Name = routeRequest.Area },
                ContentCategory = new ContentCategory { Name = routeRequest.Category },
                ContentSubCategory = new ContentSubCategory { Name = routeRequest.SubCategory },
                UrlSegment = routeRequest.UrlSegment
            };
        }


        private void SetPageResolution(ControllerContext filterContext, PageResolution pageResolution)
        {
            filterContext.Controller.ViewBag.PageResolution = PageResolution.Retrieved;
        }
    }
}
