using System.Collections.Generic;
using DexCMS.Base.Contexts;
using DexCMS.Base.Models;

namespace DexCMS.Base.Globals.Initializers
{
    class ContentCategoryInitializer
    {
        public static void Run(IDexCMSBaseContext context)
        {
            var contentCategories = new List<ContentCategory>
            {
                new ContentCategory { Name = "Account", UrlSegment = "account", IsActive = true },
                new ContentCategory { Name = "Contact", UrlSegment = "contact", IsActive = true },
                new ContentCategory { Name = "Manage Account", UrlSegment = "manage", IsActive = true }
            };
            contentCategories.ForEach(t => context.ContentCategories.Add(t));
            context.SaveChanges();
        }
    }
}
