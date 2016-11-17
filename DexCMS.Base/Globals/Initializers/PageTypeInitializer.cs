using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Linq;
using System.Data.Entity.Migrations;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Base.Globals.Initializers
{
    class PageTypeInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public PageTypeInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.PageTypes.AddOrUpdate(x => x.Name,
                new PageType { Name = "Site Content", IsActive = true }
            );
            Context.SaveChanges();
        }
    }
}
