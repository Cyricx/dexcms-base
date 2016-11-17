using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Data.Entity.Migrations;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Base.Globals.Initializers
{
    class ContentAreaInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public ContentAreaInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.ContentAreas.AddOrUpdate(x => x.Name,
                new ContentArea { Name = "Public", UrlSegment = "", IsActive = true },
                new ContentArea { Name = "Control Panel", UrlSegment = "controlpanel", IsActive = true }
            );
            Context.SaveChanges();
        }
    }
}
