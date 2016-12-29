using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Extensions;
using System.Linq;
using DexCMS.Base.Initializers.Helpers;
using System.Collections.Generic;
using DexCMS.Core.Infrastructure.Contexts;

namespace DexCMS.Base.Initializers
{
    class PageContentPermissionInitializer : DexCMSInitializer<IDexCMSBaseContext>
    {
        private ContentsReference Contents { get; set; }
        private RolesReference Roles { get; set; }

        public PageContentPermissionInitializer(IDexCMSBaseContext context, DexCMSContext coreContext) : base(context)
        {
            Contents = new ContentsReference(context);
            Roles = new RolesReference(coreContext);
        }

        public override void Run()
        {
            if (Context.PageContentPermissions.Count() == 0)
            {
                Context.PageContentPermissions.AddRange(new List<PageContentPermission>
                {
                    new PageContentPermission { PageContentID = Contents.ControlPanel, Id = Roles.Admin },
                    new PageContentPermission { PageContentID = Contents.ControlPanel, Id = Roles.Installer },
                });
                Context.SaveChanges();
            }
        }

    }

}
