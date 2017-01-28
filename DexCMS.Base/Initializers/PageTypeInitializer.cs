﻿using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Extensions;

namespace DexCMS.Base.Initializers
{
    class PageTypeInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public PageTypeInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            Context.PageTypes.AddIfNotExists(x => x.Name,
                new PageType { Name = "Site Content", IsActive = true }
            );
            Context.SaveChanges();
        }
    }
}
