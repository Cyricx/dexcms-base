using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Extensions;

namespace DexCMS.Base.Initializers
{
    class ContactTypeInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public ContactTypeInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            Context.ContactTypes.AddIfNotExists(x => x.Name,
                new ContactType { Name = "General", DisplayOrder = 0, IsActive = true });
            Context.SaveChanges();
        }
    }
}
