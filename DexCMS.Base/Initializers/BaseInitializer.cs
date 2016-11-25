using DexCMS.Base.Contexts;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Base.Initializers
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

        public void Run(BaseInitializerConfig config)
        {
            this.Run();
            PageContentInitializer contentInitializer = new PageContentInitializer(Context);

            config.Modules.ForEach(x => contentInitializer.RunSubModules(x));
        }


    }
}
