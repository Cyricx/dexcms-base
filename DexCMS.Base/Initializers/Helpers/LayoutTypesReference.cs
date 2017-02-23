using DexCMS.Base.Contexts;
using System.Linq;

namespace DexCMS.Base.Initializers.Helpers
{
    public class LayoutTypesReference
    {
        public int OneColumn { get; set; }
        public int TwoColumn { get; set; }
        public int ThreeColumn { get; set; }
        public int RightSidebar { get; set; }
        public int LeftSidebar { get; set; }
        public int RightSidebarOnly { get; set; }
        public int LeftSidebarOnly { get; set; }

        public LayoutTypesReference(IDexCMSBaseContext Context)
        {
            OneColumn = Context.LayoutTypes.Where(x => x.Name == "One Column").Select(x => x.LayoutTypeID).SingleOrDefault();
            TwoColumn = Context.LayoutTypes.Where(x => x.Name == "Two Column").Select(x => x.LayoutTypeID).SingleOrDefault();
            ThreeColumn = Context.LayoutTypes.Where(x => x.Name == "Three Column").Select(x => x.LayoutTypeID).SingleOrDefault();
            RightSidebar = Context.LayoutTypes.Where(x => x.Name == "Right Sidebar with Content").Select(x => x.LayoutTypeID).SingleOrDefault();
            LeftSidebar = Context.LayoutTypes.Where(x => x.Name == "Left Sidebar with Content").Select(x => x.LayoutTypeID).SingleOrDefault();
            RightSidebarOnly = Context.LayoutTypes.Where(x => x.Name == "Right Sidebar Only").Select(x => x.LayoutTypeID).SingleOrDefault();
            LeftSidebarOnly = Context.LayoutTypes.Where(x => x.Name == "Left Sidebar Only").Select(x => x.LayoutTypeID).SingleOrDefault();
        }
    }
}
