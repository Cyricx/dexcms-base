using System.Collections.Generic;
using DexCMS.Base.Contexts;
using DexCMS.Base.Models;

namespace DexCMS.Base.Globals.Initializers
{
    class ContactTypeInitializer
    {
        public static void Run(IDexCMSBaseContext context)
        {
            var contactTypes = new List<ContactType>
            {
                new ContactType { Name = "General", IsActive = true, DisplayOrder = 0 },
            };
            contactTypes.ForEach(t => context.ContactTypes.Add(t));
            context.SaveChanges();
        }
    }
}
