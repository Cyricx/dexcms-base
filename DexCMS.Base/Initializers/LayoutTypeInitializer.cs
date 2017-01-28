using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Extensions;

namespace DexCMS.Base.Initializers
{
    class LayoutTypeInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public LayoutTypeInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            if (addDemoContent)
            {
                Context.LayoutTypes.AddIfNotExists(x => x.Name,
                    new LayoutType { Name = "One Column", CssClass = "one-column-layout" },
                    new LayoutType { Name = "Two Column", CssClass = "two-column-layout" },
                    new LayoutType { Name = "Three Column", CssClass = "three-column-layout" },
                    new LayoutType { Name = "Right Sidebar with Content", CssClass = "right-sidebar-layout" },
                    new LayoutType { Name = "Left Sidebar with Content", CssClass = "left-sidebar-layout" },
                    new LayoutType { Name = "Right Sidebar Only", CssClass = "right-sidebar-only-layout" },
                    new LayoutType { Name = "Left Sidebar Only", CssClass = "left-sidebar-only-layout" }
                );
                Context.SaveChanges();
            }
        }
    }
}
