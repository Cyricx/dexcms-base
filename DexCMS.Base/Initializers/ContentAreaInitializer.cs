using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Extensions;

namespace DexCMS.Base.Initializers
{
    class ContentAreaInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public ContentAreaInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.ContentAreas.AddIfNotExists(x => x.Name,
                new ContentArea { Name = "Public", UrlSegment = "", IsActive = true },
                new ContentArea { Name = "Control Panel", UrlSegment = "controlpanel", IsActive = true }
            );
            Context.SaveChanges();
        }
    }
}
