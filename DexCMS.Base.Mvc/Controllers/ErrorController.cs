using DexCMS.Base.Interfaces;
using DexCMS.Core.Infrastructure;
using DexCMS.Core.Infrastructure.Enums;
using DexCMS.Core.Mvc.Globals;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DexCMS.Base.Mvc.Controllers
{
    public class ErrorController:DexCMSController
    {
        private IPageContentRepository repository;

        public ErrorController(IPageContentRepository _repo)
        {
            repository = _repo;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.PageContent = await repository.RetrieveAsync("error", "");
            return View();
        }

        public async Task<ActionResult> NotFound()
        {
            Logger.WriteLog(LogType.PageNotFound, "Page Not Found: " + HttpContext.Request.RawUrl);
            ViewBag.PageContent = await repository.RetrieveAsync("notfound", "");
            return View();
        }
    }
}
