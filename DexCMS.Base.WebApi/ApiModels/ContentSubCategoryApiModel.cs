using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DexCMS.Base.Models;
using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class ContentSubCategoryApiModel:DexCMSViewModel<ContentSubCategoryApiModel, ContentSubCategory>
    {
        public int ContentSubCategoryID { get; set; }

        public string Name { get; set; }

        public string UrlSegment { get; set; }

        public bool IsActive { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("PageContents", "Count")]
        public int ContentCount { get; set; }

    }
}
