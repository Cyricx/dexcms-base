using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Contexts;
using System.Data.Entity;

namespace DexCMS.Base.Contexts
{
    public interface IDexCMSBaseContext : IDexCMSContext, IDexCMSCoreContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<ContactType> ContactTypes { get; set; }
        DbSet<ContentBlock> ContentBlocks { get; set; }
        DbSet<ContentScript> ContentScripts { get; set; }
        DbSet<ContentStyle> ContentStyles { get; set; }
        DbSet<ContentArea> ContentAreas { get; set; }
        DbSet<ContentCategory> ContentCategories { get; set; }
        DbSet<ContentSubCategory> ContentSubCategories { get; set; }
        DbSet<PageContentImage> PageContentImages { get; set; }
        DbSet<PageContent> PageContents { get; set; } 
        DbSet<PageType> PageTypes { get; set; }
        DbSet<VisitedPage> VisitedPages { get; set; }
    }
}
