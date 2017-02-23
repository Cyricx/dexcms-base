using DexCMS.Base.Models;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class ContentAreaApiModel
    {
        public int ContentAreaID { get; set; }

        public string Name { get; set; }

        public string UrlSegment { get; set; }

        public bool IsActive { get; set; }

        public int ContentCount { get; set; }

        public ContentAreaApiModel() { }

        public ContentAreaApiModel(ContentArea contentArea)
        {
            ContentAreaID = contentArea.ContentAreaID;
            Name = contentArea.Name;
            IsActive = contentArea.IsActive;
            UrlSegment = contentArea.UrlSegment;
            ContentCount = contentArea.PageContents.Count;
        }
    }
}
