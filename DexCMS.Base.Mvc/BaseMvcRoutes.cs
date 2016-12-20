using DexCMS.Base.Mvc.Enums;
using DexCMS.Core.Infrastructure.Models;
using System.Web.Mvc;
using System.Web.Routing;

namespace DexCMS.Base.Mvc
{
    public static class BaseMvcRoutes
    {
        public static void CreateDefaultRoutes(RouteCollection routes, DexCMSConfiguration config)
        {
            routes.MapRoute("sitemap", "sitemap.xml", new { controller = "Sitemap", action = "Index" });

            routes.MapRoute(
                name: "Contact",
                url: "contact",
                defaults: new { category = "none", controller = "Contact", action = "Index", urlSegment = "contact" }
            );

            routes.MapRoute(
                name: "ContactSuccess",
                url: "contact/success",
                defaults: new { category = "contact", controller = "Contact", action = "Success", urlSegment = "success" }
            );

            if (!config.RetrieveValue<bool>(BaseRouteOptions.DisableAccountRoutes.ToString()))
            {
                routes.MapRoute(
                    name: "Account",
                    url: "Account/{action}",
                    defaults: new { category = "account", controller = "Account" });

                routes.MapRoute(
                    name: "Manage",
                    url: "Manage",
                    defaults: new { category = "none", controller = "Manage", action = "Index", urlSegment = "manage" });


                routes.MapRoute(
                    name: "ManageActions",
                    url: "Manage/{action}",
                    defaults: new { category = "manage", controller = "Manage" });
            }

            //root page
            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { urlSegment = "index", controller = "PublicContent", action = "Index" }
            );

            //THESE are the catch all routes that display dynamic content
            routes.MapRoute(
                name: "Content",
                url: "{urlSegment}",
                defaults: new { controller = "PublicContent", action = "RetrieveContent" }
            );

            routes.MapRoute(
                name: "ContentCategory",
                url: "{category}/{urlSegment}",
                defaults: new { controller = "PublicContent", action = "RetrieveContentByCategory" }
            );

            routes.MapRoute(
                name: "ContentSubCategory",
                url: "{category}/{subCategory}/{urlSegment}",
                defaults: new { controller = "PublicContent", action = "RetrieveContentBySubCategory" }
            );
        }


        public static void ControlPanelDefaultRoutes(AreaRegistrationContext context, DexCMSConfiguration config)
        {
            context.MapRoute(
                "ControlPanel_default",
                "ControlPanel/{*routes}",
                new { action = "Index", controller = "ControlPanel", area = "ControlPanel" }
            );
        }
    }

}
