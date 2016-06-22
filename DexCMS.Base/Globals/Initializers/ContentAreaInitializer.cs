using System.Collections.Generic;
using DexCMS.Base.Contexts;
using DexCMS.Base.Models;

namespace DexCMS.Base.Globals.Initializers
{
    class ContentAreaInitializer
    {
        public static void Run(IDexCMSBaseContext context)
        {
            var contentAreas = new List<ContentArea>
            {
                new ContentArea { Name = "Public", UrlSegment = "", IsActive = true },
                new ContentArea { Name = "Control Panel", UrlSegment = "controlpanel", IsActive = true }
            };
            contentAreas.ForEach(t => context.ContentAreas.Add(t));
            context.SaveChanges();
        }
    }
}
