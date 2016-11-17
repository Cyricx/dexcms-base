using DexCMS.Base.Contexts;
using DexCMS.Base.Globals.Initializers;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Base.Globals
{
    public class BaseInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public BaseInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run()
        {
            (new ContactTypeInitializer(Context)).Run();
            (new ContentAreaInitializer(Context)).Run();
            (new ContentCategoryInitializer(Context)).Run();
            (new PageTypeInitializer(Context)).Run();
            (new PageContentInitializer(Context)).Run();
        }
    }
}
