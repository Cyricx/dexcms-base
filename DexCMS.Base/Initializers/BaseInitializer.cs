using DexCMS.Base.Contexts;
using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Base.Initializers
{
    public class BaseInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public DexCMSContext CoreContext { get; set; }
        public BaseInitializer(IDexCMSBaseContext context, DexCMSContext coreContext) : base(context)
        {
            CoreContext = coreContext;
        }

        public override void Run()
        {
            (new ContactTypeInitializer(Context)).Run();
            (new ContentAreaInitializer(Context)).Run();
            (new ContentCategoryInitializer(Context)).Run();
            (new LayoutTypeInitializer(Context)).Run();
            (new PageTypeInitializer(Context)).Run();
            (new PageContentInitializer(Context)).Run();
            (new ContentBlockInitializer(Context)).Run();
            (new PageContentImageInitializer(Context)).Run();
            (new PageContentPermissionInitializer(Context, CoreContext)).Run();
        }
    }
}
