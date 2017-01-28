using System.Web.Http;
using DexCMS.Core.WebApi.Enums;
using DexCMS.Core.Models;

namespace DexCMS.Base.WebApi
{
    public static class WebApiRoutes
    {
        public static void CreateDefaultRoutes(HttpConfiguration httpConfig, DexCMSConfiguration config)
        {
            string baseApi = config.RetrieveValue<string>(CoreApiOptions.CoreApiUrl.ToString());
            if (string.IsNullOrEmpty(baseApi))
            {
                baseApi = "api";
            }

            httpConfig.Routes.MapHttpRoute(
                name: "RetrieveContent",
                routeTemplate: baseApi + "/retrievecontents/{contentName}",
                defaults: new { controller = "retrievecontents" });
        }
    }
}
