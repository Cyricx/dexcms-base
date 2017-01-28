using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Core.Globals;
using DexCMS.Core.Extensions;

namespace DexCMS.Base.Initializers
{
    class ContentCategoryInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public ContentCategoryInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            Context.ContentCategories.AddIfNotExists(x => x.Name,
                new ContentCategory { Name = "Account", UrlSegment = "account", IsActive = true },
                new ContentCategory { Name = "Contact", UrlSegment = "contact", IsActive = true },
                new ContentCategory { Name = "Manage Account", UrlSegment = "manage", IsActive = true }
            );
            Context.SaveChanges();
        }
    }
}
