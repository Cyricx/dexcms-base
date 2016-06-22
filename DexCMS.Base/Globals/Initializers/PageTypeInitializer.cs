using System.Collections.Generic;
using DexCMS.Base.Contexts;
using DexCMS.Base.Models;

namespace DexCMS.Base.Globals.Initializers
{
    class PageTypeInitializer
    {
        public static void Run(IDexCMSBaseContext context)
        {
            var pageTypes = new List<PageType>
            {
                new PageType { Name = "Site Content", IsActive = true }
            };
            pageTypes.ForEach(x => context.PageTypes.Add(x));
            context.SaveChanges();
        }
    }
}
