using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DexCMS.Base.Globals.Initializers
{
    class PageTypeInitializer
    {
        public static void Run(IDexCMSBaseContext context)
        {
            if(context.PageTypes.Count() == 0)
            {
                context.PageTypes.AddOrUpdate(x => x.Name,
                    new PageType { Name = "Site Content", IsActive = true }
                );
            }
        }
    }
}
