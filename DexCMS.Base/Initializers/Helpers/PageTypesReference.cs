using DexCMS.Base.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.Initializers.Helpers
{
    class PageTypesReference
    {
        public int SiteContent { get; set; }

        public PageTypesReference(IDexCMSBaseContext Context)
        {
            SiteContent = Context.PageTypes.Where(x => x.Name == "Site Content").Select(x => x.PageTypeID).Single();
        }
    }
}
