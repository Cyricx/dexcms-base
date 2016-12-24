using System.Web.Mvc;
using DexCMS.Base.Models;
using DexCMS.Base.Interfaces;
using System.Threading.Tasks;
using DexCMS.Base.Mvc.Extensions;
using System;
using DexCMS.Core.Mvc.Globals;

namespace DexCMS.Base.Mvc.Controllers
{
    public class PublicContentController : DexCMSController
    {
        IPageContentRepository repository;

        public PublicContentController(IPageContentRepository _repo)
        {
            repository = _repo;
        }

        public ActionResult Boom()
        {
            throw new ApplicationException("Boom");
        }

        public async Task<ActionResult> RetrieveContent(string urlSegment)
        {
            PageContent content = repository.RetrieveAsync(urlSegment.ToLower(), "").Result;
            if (content == null || content.PageType.Name != "Site Content")
            {
                content = await CheckForRedirect();
                if (content != null)
                {
                    return RedirectPermanent(UrlBuilder.BuildUrl(content));
                }
                else
                {
                    return HttpNotFound();
                }
            }
            ViewBag.PageContent = content;

            return View("DisplayContent");
        }

        public async Task<ActionResult> Index()
        {
            PageContent content = repository.RetrieveAsync("index", "").Result;
            if (content == null || content.PageType.Name != "Site Content")
            {
                content = await CheckForRedirect();
                if (content != null)
                {
                    return RedirectPermanent(UrlBuilder.BuildUrl(content));
                }
                else
                {
                    return HttpNotFound();
                }
            }
            ViewBag.PageContent = content;

            return View();
        }

        public async Task<ActionResult> RetrieveContentByCategory(string category, string urlSegment)
        {
            PageContent content = repository.RetrieveAsync(urlSegment.ToLower(), "", category.ToLower()).Result;
            if (content == null)
            {
                content = await CheckForRedirect();
                if (content != null)
                {
                    return RedirectPermanent(UrlBuilder.BuildUrl(content));
                }
                else
                {
                    return HttpNotFound();
                }
            }
            ViewBag.PageContent = content;

            return View("DisplayContent");
        }
        public async Task<ActionResult> RetrieveContentBySubCategory(string category, string subCategory, string urlSegment)
        {
            PageContent content = repository.RetrieveAsync(urlSegment.ToLower(), "", category.ToLower(), subCategory.ToLower()).Result;
            if (content == null)
            {
                content = await CheckForRedirect();
                if (content != null)
                {
                    return RedirectPermanent(UrlBuilder.BuildUrl(content));
                }
                else
                {
                    return HttpNotFound();
                }
            }
            ViewBag.PageContent = content;

            return View("DisplayContent");
        }

        private async Task<PageContent> CheckForRedirect()
        {
            string url = HttpContext.Request.RawUrl;
            url = url.Length > 0 && url[0] == '/' ? url.Substring(1) : url;
            return await repository.RetrieveRedirectAsync(url);
        }
    }
}