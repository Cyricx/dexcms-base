using System;
using System.Threading.Tasks;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Models;
using DexCMS.Core.Contexts;
using DexCMS.Core.Repositories;
using System.Data.Entity;
using DexCMS.Base.Contexts;
using System.Linq;

namespace DexCMS.Base.Repositories
{
    public class PageContentRedirectRepository : AbstractRepository<PageContentRedirect>, IPageContentRedirectRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        public Task<PageContent> RetrieveAsync(string url)
        {
            return _ctx.PageContentRedirects.Where(x => string.Equals(x.Url, url, StringComparison.OrdinalIgnoreCase)).Select(x => x.PageContent).SingleOrDefaultAsync();
        }

        private IDexCMSBaseContext _ctx { get; set; }

        public PageContentRedirectRepository(IDexCMSBaseContext ctx)
        {
            _ctx = ctx;
        }

        
    }
}