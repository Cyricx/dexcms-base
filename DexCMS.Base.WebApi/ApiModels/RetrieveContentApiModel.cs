using DexCMS.Base.Models;
using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;
using System.Collections.Generic;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class RetrieveContentApiModel:DexCMSViewModel<RetrieveContentApiModel, PageContent>
    {
        public string PageTitle { get; set; }

        public string Body { get; set; }

        public string Title { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedClassMapping(typeof(RetrieveContentBlockApiModel), true)]
        public List<RetrieveContentBlockApiModel> ContentBlocks { get; set; }
    }

    public class RetrieveContentBlockApiModel:DexCMSViewModel<RetrieveContentBlockApiModel, ContentBlock>
    {
        public string BlockBody { get; set; }
    }
}
