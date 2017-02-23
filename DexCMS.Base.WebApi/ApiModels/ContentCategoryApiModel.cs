using DexCMS.Base.Models;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class ContentCategoryApiModel
    {
        public int ContentCategoryID { get; set; }

        public string Name { get; set; }

        public string UrlSegment { get; set; }

        public bool IsActive { get; set; }

        public int ContentCount { get; set; }

        public ContentCategoryApiModel() { }

        public ContentCategoryApiModel(ContentCategory contentCategory)
        {
            ContentCategoryID = contentCategory.ContentCategoryID;
            Name = contentCategory.Name;
            IsActive = contentCategory.IsActive;
            UrlSegment = contentCategory.UrlSegment;
            ContentCount = contentCategory.PageContents.Count;
        }
    }
}
