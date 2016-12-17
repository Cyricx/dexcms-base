using DexCMS.Base.Contexts;
using System.Linq;

namespace DexCMS.Base.Initializers.Helpers
{
    public class CategoriesReference
    {
        public int Account { get; set; }
        public int Contact { get; set; }
        public int ManageAccount { get; set; }

        public CategoriesReference(IDexCMSBaseContext Context)
        {
            Account = Context.ContentCategories.Where(x => x.Name == "Account").Select(x => x.ContentCategoryID).Single();
            Contact = Context.ContentCategories.Where(x => x.Name == "Contact").Select(x => x.ContentCategoryID).Single();
            ManageAccount = Context.ContentCategories.Where(x => x.Name == "Manage Account").Select(x => x.ContentCategoryID).Single();
        }
    }
}
