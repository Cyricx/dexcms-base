using DexCMS.Base.Contexts;
using DexCMS.Base.Globals.Initializers;

namespace DexCMS.Base.Globals
{
    public class BaseInitializer
    {
        public void Initialize(IDexCMSBaseContext context)
        {
            //! Contact Types
            (new ContactTypeInitializer(context)).Run();

            //! Content Areas
            (new ContentAreaInitializer(context)).Run();

            //! Content Categories
            (new ContentCategoryInitializer(context)).Run();

            //! PageTypes
            (new PageTypeInitializer(context)).Run();

            //! Page Contents!!
            (new PageContentInitializer(context)).Run();

        }
    }
}
