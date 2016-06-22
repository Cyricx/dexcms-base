using System.Web.Mvc;
using DexCMS.Base.Mvc.Filters;

namespace DexCMS.Base.Mvc.Globals
{
    public static class MvcFiltersConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SavePageRequest());
        }
    }
}
