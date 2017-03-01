using DexCMS.Base.Models;
using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class PageTypeApiModel:DexCMSViewModel<PageTypeApiModel, PageType>
    {
        public int PageTypeID { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("PageContents", "Count")]
        public int ContentCount { get; set; }
    }
}
