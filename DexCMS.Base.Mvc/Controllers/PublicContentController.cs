using System.Web;
using System.Web.Mvc;
using DexCMS.Base.Models;
using DexCMS.Base.Interfaces;
using System.Threading.Tasks;

namespace DexCMS.Base.Mvc.Controllers
{
    public class PublicContentController : Controller
    {
        IPageContentRepository repository;
        IPageContentRedirectRepository redirectRepository;

        public PublicContentController(IPageContentRepository _repo, IPageContentRedirectRepository _redirectRepo)
        {
            repository = _repo;
            redirectRepository = _redirectRepo;
        }

        public async Task<ActionResult> RetrieveContent(string urlSegment)
        {
            PageContent content = repository.RetrieveAsync(urlSegment.ToLower(), "").Result;
            if (content == null || content.PageType.Name != "Site Content")
            {
                content = await CheckForRedirect(urlSegment);
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

        private async Task<PageContent> CheckForRedirect(string url)
        {
            PageContent content = await redirectRepository.RetrieveAsync(url);
            if (content == null)
            {
                throw new HttpException(404, "HTTP/1.1 404 Not Found");
            }
            return content;
        }
    }
}