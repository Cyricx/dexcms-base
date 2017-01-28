using DexCMS.Base.Models;
using DexCMS.Base.Interfaces;
using DexCMS.Core.Contexts;
using DexCMS.Core.Repositories;

namespace DexCMS.Base.Repositories
{
    public class PageTypeRepository : AbstractRepository<PageType>, IPageTypeRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public PageTypeRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }
    }
}
