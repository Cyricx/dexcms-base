using DexCMS.Base.Models;

namespace DexCMS.Base.WebApi.ApiModels
{

    public class ContentBlockApiModel
    {
        public int ContentBlockID { get; set; }

        public string BlockTitle { get; set; }

        public bool ShowTitle { get; set; }

        public string BlockBody { get; set; }

        public int PageContentID { get; set; }

        public string CssClass { get; set; }

        public int DisplayOrder { get; set; }

        public ContentBlockApiModel() { }

        public ContentBlockApiModel(ContentBlock contentBlock)
        {
            ContentBlockID = contentBlock.ContentBlockID;
            BlockTitle = contentBlock.BlockTitle;
            ShowTitle = contentBlock.ShowTitle;
            BlockBody = contentBlock.BlockBody;
            PageContentID = contentBlock.PageContentID;
            CssClass = contentBlock.CssClass;
            DisplayOrder = contentBlock.DisplayOrder;
        }
    }
}
