using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DexCMS.Base.Globals.Initializers
{
    class PageTypeInitializer
    {
        private IDexCMSBaseContext context;

        public PageTypeInitializer(IDexCMSBaseContext ctx)
        {
            context = ctx;
        }

        public void Run()
        {
            if (context.PageTypes.Count() == 0)
            {
                context.PageTypes.AddOrUpdate(x => x.Name,
                    new PageType { Name = "Site Content", IsActive = true }
                );
            }
        }
    }
}
