using System.Security.Principal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DexCMS.Core.Infrastructure.Models;

namespace DexCMS.Base.Mvc.Extensions
{
    public static class IIdentityExtensions
    {

        public static string GetName(this IIdentity identity)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(identity.GetUserId());
            if (currentUser == null)
            {
                return null;
            }
            else
            {

                return currentUser.FirstName;
            }
        }

        public static ApplicationUser GetAdditionalInfo(this IIdentity identity)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = manager.FindById(identity.GetUserId());
            if (currentUser == null)
            {
                return null;
            }
            else
            {

                return currentUser;
            }
        }
    }
}