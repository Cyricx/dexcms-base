using DexCMS.Base.Contexts;
using DexCMS.Base.Globals.Initializers;

namespace DexCMS.Base.Globals
{
    public static class BaseInitializer
    {
        public static void Initialize(IDexCMSBaseContext context)
        {
            //! Contact Types
            ContactTypeInitializer.Run(context);

            //! Content Areas
            ContentAreaInitializer.Run(context);

            //! Content Categories
            ContentCategoryInitializer.Run(context);

            //! PageTypes
            PageTypeInitializer.Run(context);

            //! Page Contents!!
            PageContentInitializer.Run(context);
        }
    }
}
