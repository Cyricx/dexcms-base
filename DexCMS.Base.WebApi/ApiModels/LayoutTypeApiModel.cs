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
    public class LayoutTypeApiModel:DexCMSViewModel<LayoutTypeApiModel, LayoutType>
    {
        public int LayoutTypeID { get; set; }
        public string Name { get; set; }
        public string CssClass { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("PageContents", "Count")]
        public int PageContentCount { get; set; }

        [OverrideMappingType(MappingType.NoMappings)]
        public string ReplacementFileName { get; set; }

        [OverrideMappingType(MappingType.NoMappings)]
        public string TemporaryFileName { get; set; }
                
        public string ExampleImage { get; set; }
    }
}
