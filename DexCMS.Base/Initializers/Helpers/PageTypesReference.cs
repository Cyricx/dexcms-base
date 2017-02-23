using DexCMS.Base.Contexts;
using System.Linq;

namespace DexCMS.Base.Initializers.Helpers
{
    public class PageTypesReference
    {
        public int SiteContent { get; set; }

        public PageTypesReference(IDexCMSBaseContext Context)
        {
            SiteContent = Context.PageTypes.Where(x => x.Name == "Site Content").Select(x => x.PageTypeID).SingleOrDefault();
        }
    }
}
