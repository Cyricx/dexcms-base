using DexCMS.Base.Contexts;
using System.Linq;

namespace DexCMS.Base.Initializers.Helpers
{
    public class ContentsReference
    {
        public int OneColumn { get; set; }
        public int TwoColumn { get; set; }
        public int ThreeColumn { get; set; }
        public int RightSidebar { get; set; }
        public int LeftSidebar { get; set; }
        public int RightSidebarOnly { get; set; }
        public int LeftSidebarOnly { get; set; }
        public int ControlPanel { get; set; }

        public ContentsReference(IDexCMSBaseContext Context)
        {
            OneColumn = Context.PageContents.Where(x => x.PageTitle == "One Column").Select(x => x.PageContentID).Single();
            TwoColumn = Context.PageContents.Where(x => x.PageTitle == "Two Column").Select(x => x.PageContentID).Single();
            ThreeColumn = Context.PageContents.Where(x => x.PageTitle == "Three Column").Select(x => x.PageContentID).Single();
            RightSidebar = Context.PageContents.Where(x => x.PageTitle == "Right Sidebar").Select(x => x.PageContentID).Single();
            LeftSidebar = Context.PageContents.Where(x => x.PageTitle == "Left Sidebar").Select(x => x.PageContentID).Single();
            RightSidebarOnly = Context.PageContents.Where(x => x.PageTitle == "Right Sidebar Only").Select(x => x.PageContentID).Single();
            LeftSidebarOnly = Context.PageContents.Where(x => x.PageTitle == "Left Sidebar Only").Select(x => x.PageContentID).Single();
            ControlPanel = Context.PageContents.Where(x => x.PageTitle == "Control Panel").Select(x => x.PageContentID).Single();
        }
    }
}
