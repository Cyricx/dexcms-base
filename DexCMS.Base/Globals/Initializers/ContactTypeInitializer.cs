using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Data.Entity.Migrations;
using DexCMS.Core.Infrastructure.Globals;

namespace DexCMS.Base.Globals.Initializers
{
    class ContactTypeInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        public ContactTypeInitializer(IDexCMSBaseContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.ContactTypes.AddOrUpdate(x => x.Name,
                new ContactType { Name = "General", DisplayOrder = 0, IsActive = true });
            Context.SaveChanges();
        }
    }
}
