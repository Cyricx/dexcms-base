using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DexCMS.Base.Globals.Initializers
{
    class ContentAreaInitializer
    {
        public static void Run(IDexCMSBaseContext context)
        {
            if (context.ContentAreas.Count() == 0)
            {
                context.ContentAreas.AddOrUpdate(x => x.Name,
                    new ContentArea { Name = "Public", UrlSegment = "", IsActive = true },
                    new ContentArea { Name = "Control Panel", UrlSegment = "controlpanel", IsActive = true }
                );
            }
        }
    }
}
