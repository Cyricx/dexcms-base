using DexCMS.Base.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.Initializers.Helpers
{
    class LayoutTypesReference
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
            OneColumn = Context.LayoutTypes.Where(x => x.Name == "One Column").Select(x => x.LayoutTypeID).Single();
            TwoColumn = Context.LayoutTypes.Where(x => x.Name == "Two Column").Select(x => x.LayoutTypeID).Single();
            ThreeColumn = Context.LayoutTypes.Where(x => x.Name == "Three Column").Select(x => x.LayoutTypeID).Single();
            RightSidebar = Context.LayoutTypes.Where(x => x.Name == "Right Sidebar with Content").Select(x => x.LayoutTypeID).Single();
            LeftSidebar = Context.LayoutTypes.Where(x => x.Name == "Left Sidebar with Content").Select(x => x.LayoutTypeID).Single();
            RightSidebarOnly = Context.LayoutTypes.Where(x => x.Name == "Right Sidebar Only").Select(x => x.LayoutTypeID).Single();
            LeftSidebarOnly = Context.LayoutTypes.Where(x => x.Name == "Left Sidebar Only").Select(x => x.LayoutTypeID).Single();
        }
    }
}
