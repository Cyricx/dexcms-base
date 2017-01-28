using System;
using System.Collections.Generic;
using DexCMS.Base.Contexts;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Base.Initializers
{
    public class BaseInitializer: DexCMSLibraryInitializer<IDexCMSBaseContext>
    {
        public BaseInitializer(IDexCMSBaseContext context) : base(context)
        {

        }

        public override List<Type> Initializers
        {
            get
            {
                return new List<Type>
                {
                    typeof(ContactTypeInitializer),
                    typeof(ContentAreaInitializer),
                    typeof(ContentCategoryInitializer),
                    typeof(LayoutTypeInitializer),
                    typeof(PageTypeInitializer),
                    typeof(PageContentInitializer),
                    typeof(ContentBlockInitializer),
                    typeof(PageContentImageInitializer),
                    typeof(PageContentPermissionInitializer)
                };
            }
        }
    }
}
