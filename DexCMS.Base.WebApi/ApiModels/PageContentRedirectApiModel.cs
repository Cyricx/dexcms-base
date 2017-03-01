using DexCMS.Base.Models;
using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class PageContentRedirectApiModel:DexCMSViewModel<PageContentRedirectApiModel, PageContentRedirect>
    {
        public int PageContentRedirectID { get; set; }

        public string Url { get; set; }

        public int PageContentID { get; set; }

        public int DisplayOrder { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedClassMapping(typeof(PageContentRedirectPageContentApiModel))]
        public PageContentRedirectPageContentApiModel PageContent { get; set; }
    }

    public class PageContentRedirectPageContentApiModel: DexCMSViewModel<PageContentRedirectPageContentApiModel, PageContent>
    {
        public int PageContentID { get; set; }
        public string Heading { get; set; }
    }
}
