using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Data.Entity.Migrations;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Base.Globals.Initializers
{
    class ContentCategoryInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public ContentCategoryInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.ContentCategories.AddOrUpdate(x => x.Name,
                new ContentCategory { Name = "Account", UrlSegment = "account", IsActive = true },
                new ContentCategory { Name = "Contact", UrlSegment = "contact", IsActive = true },
                new ContentCategory { Name = "Manage Account", UrlSegment = "manage", IsActive = true }
            );
            Context.SaveChanges();
        }
    }
}
