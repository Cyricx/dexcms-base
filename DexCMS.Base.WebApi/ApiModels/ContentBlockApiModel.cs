using DexCMS.Base.Models;
using DexCMS.Core.Globals;

namespace DexCMS.Base.WebApi.ApiModels
{

    public class ContentBlockApiModel:DexCMSViewModel<ContentBlockApiModel, ContentBlock>
    {
        public int ContentBlockID { get; set; }

        public string BlockTitle { get; set; }

        public bool ShowTitle { get; set; }

        public string BlockBody { get; set; }

        public int PageContentID { get; set; }

        public string CssClass { get; set; }

        public int DisplayOrder { get; set; }

    }
}
