using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DexCMS.Base.Globals.Initializers
{
    class ContentCategoryInitializer
    {
        public static void Run(IDexCMSBaseContext context)
        {
            if (context.ContentCategories.Count() == 0)
            {
                context.ContentCategories.AddOrUpdate(x => x.Name,
                    new ContentCategory { Name = "Account", UrlSegment = "account", IsActive = true },
                    new ContentCategory { Name = "Contact", UrlSegment = "contact", IsActive = true },
                    new ContentCategory { Name = "Manage Account", UrlSegment = "manage", IsActive = true }
                );
            }
        }
    }
}
