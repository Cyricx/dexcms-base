using DexCMS.Base.Models;
using DexCMS.Core.Globals;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class VisitedPageApiModel:DexCMSViewModel<VisitedPageApiModel, VisitedPage>
    {
        public int VisitedPageID { get; set; }
        public string URL { get; set; }
        public int VisitOrder { get; set; }
        public int ContactID { get; set; }
    }
}
