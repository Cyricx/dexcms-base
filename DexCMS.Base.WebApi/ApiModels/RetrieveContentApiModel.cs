using System.Collections.Generic;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class RetrieveContentApiModel
    {
        public string PageTitle { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public List<RetrieveContentBlockApiModel> ContentBlocks { get; set; }
    }

    public class RetrieveContentBlockApiModel
    {
        public string BlockBody { get; set; }
    }
}
