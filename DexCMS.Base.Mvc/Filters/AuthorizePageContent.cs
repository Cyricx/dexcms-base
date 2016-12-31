using DexCMS.Base.HelperModels;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Models;
using DexCMS.Base.Mvc.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DexCMS.Base.Mvc.Filters
{
    public class AuthorizePageContent: AuthorizeAttribute
    {
        IPageContentRepository repository;
        private PageContent PageContent;

        public AuthorizePageContent(IPageContentRepository _repo)
        {
            repository = _repo;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                PageContent = PageContentFactory.RetrievePageRequest(filterContext, repository).PageContent;
                base.OnAuthorization(filterContext);
            }
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (PageContent == null)
            {
                return true;
            } 
            else
            {
                return IsAuthorizedForPageContent(httpContext);
            }
        }

        private bool IsAuthorizedForPageContent(HttpContextBase httpContext)
        {
            if (PageContent.RequiresLogin)
            {
                if (!httpContext.User.Identity.IsAuthenticated)
                {
                    return false;
                }
                else if (PageContent.PageContentPermissions.Count == 0)
                {
                    return true;
                }
                else
                {
                    bool hasAtLeastOne = false;
                    foreach (PageContentPermission item in PageContent.PageContentPermissions)
                    {
                        if (!hasAtLeastOne)
                        {
                            hasAtLeastOne = httpContext.User.IsInRole(item.ApplicationRole.Name);
                        }
                    }

                    return hasAtLeastOne;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
