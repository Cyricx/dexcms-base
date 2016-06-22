using System;
using System.Text;
using System.Web.Mvc;

namespace DexCMS.Base.Mvc.Controllers
{

    public class ErrorController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            WriteLog(Server.MapPath("~/Error.txt"), filterContext.Exception.ToString());

        }

        static void WriteLog(string logFile, string text)
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine(DateTime.Now.ToString());
            message.AppendLine(text);
            message.AppendLine("===========================");
            System.IO.File.AppendAllText(logFile, message.ToString());
            
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult NotFound()
        {
            System.IO.File.AppendAllText(
                Server.MapPath("~/Areas/Admin/Error.txt"),
                string.Format("Invalid Page Request - {0} - {1:F}\n",
                Request.Url.ToString(),
                DateTime.Now));
            

            return View();
        }
	}
}