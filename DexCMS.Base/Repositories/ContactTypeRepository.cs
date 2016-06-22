using DexCMS.Base.Contexts;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Repositories;

namespace DexCMS.Base.Repositories
{
    public class ContactTypeRepository : AbstractRepository<ContactType>, IContactTypeRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public ContactTypeRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }
    }
}
