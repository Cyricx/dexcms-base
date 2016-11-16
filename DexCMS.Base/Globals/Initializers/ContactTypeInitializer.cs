using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using System.Linq;
using System.Data.Entity.Migrations;

namespace DexCMS.Base.Globals.Initializers
{
    class ContactTypeInitializer
    {
        public static void Run(IDexCMSBaseContext context)
        {
            if (context.ContactTypes.Count() == 0)
            {
                context.ContactTypes.AddOrUpdate(x => x.Name,
                    new ContactType { Name = "General", DisplayOrder = 0, IsActive = true });
            }
        }
    }
}
