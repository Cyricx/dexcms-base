using System.Web;
using System.Web.Mvc;
using DexCMS.Base.Models;
using DexCMS.Base.Interfaces;

namespace DexCMS.Base.Mvc.Controllers
{
    public class PublicContentController : Controller
    {
        IPageContentRepository repository;

        public PublicContentController(IPageContentRepository _repo)
        {
            repository = _repo;
        }

        public ActionResult RetrieveContent(string urlSegment)
        {
            PageContent content = repository.RetrieveAsync(urlSegment.ToLower(), "").Result;
            if (content == null || content.PageType.Name != "Site Content")
            {

                throw new HttpException(404, "HTTP/1.1 404 Not Found");
            }
            return View("DisplayContent");
        }

        public ActionResult Index()
        {
            PageContent content = repository.RetrieveAsync("index", "").Result;
            if (content == null || content.PageType.Name != "Site Content")
            {

                throw new HttpException(404, "HTTP/1.1 404 Not Found");
            }
            return View();
        }

        public ActionResult RetrieveContentByCategory(string category, string urlSegment)
        {
            PageContent content = repository.RetrieveAsync(urlSegment.ToLower(), "", category.ToLower()).Result;
            if (content == null)
            {

                throw new HttpException(404, "HTTP/1.1 404 Not Found");
            }
            return View("DisplayContent");
        }
        public ActionResult RetrieveContentBySubCategory(string category, string subCategory, string urlSegment)
        {
            PageContent content = repository.RetrieveAsync(urlSegment.ToLower(), "", category.ToLower(), subCategory.ToLower()).Result;
            if (content == null)
            {

                throw new HttpException(404, "HTTP/1.1 404 Not Found");
            }
            return View("DisplayContent");
        }

    }
}