using System.Web.Mvc;
using DexCMS.Base.Models;
using DexCMS.Base.Interfaces;
using System.Threading.Tasks;
using DexCMS.Base.Mvc.Extensions;
using System;
using DexCMS.Core.Mvc.Globals;
using DexCMS.Base.Mvc.Enums;

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

        public ActionResult RetrieveContent(string urlSegment)
        {
            return ProcessContent();
        }
        
        public ActionResult Index()
        {
            return ProcessContent("Index");
        }

        public ActionResult RetrieveContentByCategory(string category, string urlSegment)
        {
            return ProcessContent();
        }

        public ActionResult RetrieveContentBySubCategory(string category, string subCategory, string urlSegment)
        {
            return ProcessContent();
        }

        private ActionResult ProcessContent(string viewFile = "DisplayContent")
        {
            PageContent content = GetPageContent();
            PageResolution pageResolution = GetPageResolution();

            if (pageResolution == PageResolution.Retrieved && content.PageType != null && content.PageType.Name == "Site Content")
            {
                return View(viewFile);
            }
            else if (pageResolution == PageResolution.Redirect && content.PageType != null && content.PageType.Name == "Site Content")
            {
                return RedirectPermanent(UrlBuilder.BuildUrl(content));
            }
            else
            {
                return HttpNotFound();
            }
        }

        private PageContent GetPageContent()
        {
            return (PageContent)ViewBag.PageContent;
        }
        private PageResolution GetPageResolution()
        {
            return (PageResolution)ViewBag.PageResolution;
        }
    }
}