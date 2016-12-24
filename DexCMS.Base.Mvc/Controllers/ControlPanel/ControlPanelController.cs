using DexCMS.Base.Interfaces;
using DexCMS.Core.Mvc.Globals;
using System.Web.Mvc;

namespace DexCMS.Base.Mvc.Controllers.ControlPanel
{
    [Authorize(Roles = "Admin")]
    public class ControlPanelController : DexCMSController
    {
        private IPageContentRepository repository;

        public ControlPanelController(IPageContentRepository repo)
        {
            repository = repo;
        }

        //
        // GET: /ControlPanel/Panel/
        public ActionResult Index()
        {
            //action filter will add viewbag item
            return View();
        }
    }
}
