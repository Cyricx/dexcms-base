using System.Web.Mvc;

namespace DexCMS.Base.Mvc.Globals
{
    public class TTCMSViewEngine : RazorViewEngine
    {
        public TTCMSViewEngine()
        {

            AreaViewLocationFormats = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Views/TTCMS-Areas/{2}/{1}/{0}.cshtml",
                "~/Views/TTCMS-Areas/{2}/Shared/{0}.cshtml"
            };
            AreaMasterLocationFormats = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Views/TTCMS-Areas/{2}/{1}/{0}.cshtml",
                "~/Views/TTCMS-Areas/{2}/Shared/{0}.cshtml"
            };
            AreaPartialViewLocationFormats = new[]
            {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml",
                "~/Views/TTCMS-Areas/{2}/{1}/{0}.cshtml",
                "~/Views/TTCMS-Areas/{2}/Shared/{0}.cshtml"
            };

            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/TTCMS/{1}/{0}.cshtml",
                "~/Views/TTCMS/Shared/{0}.cshtml"
            };
            MasterLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/TTCMS/{1}/{0}.cshtml",
                "~/Views/TTCMS/Shared/{0}.cshtml"
            };
            PartialViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
                "~/Views/TTCMS/{1}/{0}.cshtml",
                "~/Views/TTCMS/Shared/{0}.cshtml"
            };

            FileExtensions = new[]
            {
                "cshtml"
            };

        }
    }
}
