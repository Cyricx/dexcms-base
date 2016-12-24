using System.Web;
using System.Web.Mvc;
using DexCMS.Base.Models;
using DexCMS.Base.Interfaces;
using System.Threading.Tasks;

namespace DexCMS.Base.Mvc.Controllers
{
    public class ErrorsController : Controller
    {
        IPageContentRedirectRepository repository;

        public ErrorsController(IPageContentRedirectRepository _repo)
        {
            repository = _repo;
        }

        public async Task<ActionResult> NotFound(string url)
        {

            PageContent content = await repository.RetrieveAsync(url);
            if (content == null)
            {
                return View();
            }
            else
            {
                ViewBag.PageContent = content;
                return View("DisplayContent");
            }
            
        }
        public ActionResult GeneralError()
        {
            return View();
        }

    }
}