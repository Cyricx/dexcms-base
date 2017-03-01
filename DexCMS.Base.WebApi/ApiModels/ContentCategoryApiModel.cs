using DexCMS.Base.Models;
using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class ContentCategoryApiModel:DexCMSViewModel<ContentCategoryApiModel, ContentCategory>
    {
        public int ContentCategoryID { get; set; }

        public string Name { get; set; }

        public string UrlSegment { get; set; }

        public bool IsActive { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("PageContents", "Count")]
        public int ContentCount { get; set; }
    }
}
