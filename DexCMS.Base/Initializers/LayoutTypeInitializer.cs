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

        public override void Run()
        {
            Context.LayoutTypes.AddIfNotExists(x => x.Name,
                new LayoutType { Name = "One Column", CssClass="one-column" },
                new LayoutType { Name = "Two Column", CssClass = "two-column" },
                new LayoutType { Name = "Three Column", CssClass = "three-column" },
                new LayoutType { Name = "Right Sidebar with Content", CssClass = "right-sidebar" },
                new LayoutType { Name = "Left Sidebar with Content", CssClass = "left-sidebar" },
                new LayoutType { Name = "Right Sidebar Only", CssClass = "right-sidebar-only" },
                new LayoutType { Name = "Left Sidebar Only", CssClass = "left-sidebar-only" }
            );
            Context.SaveChanges();
        }
    }
}
