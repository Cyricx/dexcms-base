using DexCMS.Base.Contexts;
using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace DexCMS.Base.Initializers.Helpers
{
    public class RolesReference
    {
        public string Admin { get; set; }
        public string Installer { get; set; }

        public RolesReference(DexCMSContext Context)
        {
            RoleManager<ApplicationRole> roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(Context));

            Admin = roleManager.FindByName("Admin").Id;
            Installer = roleManager.FindByName("Installer").Id;
        }
    }
}
