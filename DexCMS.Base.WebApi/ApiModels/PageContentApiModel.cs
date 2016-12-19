using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DexCMS.Base.Enums;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class PageContentApiModel
    {
        public int PageContentID { get; set; }

        public string Heading { get; set; }

        public string Body { get; set; }

        public string PageTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public int ContentAreaID { get; set; }
        public int? ContentCategoryID { get; set; }
        public int? ContentSubCategoryID { get; set; }

        public SEOChangeFrequency ChangeFrequency { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        public double? Priority { get; set; }

        public bool AddToSitemap { get; set; }

        public int? MaximumImages { get; set; }

        public string ContentAreaName { get; set; }
        public string ContentCategoryName { get; set; }
        public string ContentSubCategoryName { get; set; }
        public string UrlSegment { get; set; }

        public int? PageTypeID { get; set; }
        public string PageTypeName { get; set; }

        public int? LayoutTypeID { get; set; }
        public string LayoutTypeName { get; set; }

        public List<ContentBlockInfo> ContentBlocks { get; set; }
        public List<PageContentImageInfo> PageContentImages { get; set; }
        public bool IsDisabled { get; set; }

    }
    public class ContentBlockInfo
    {
        public int ContentBlockID { get; set; }
        public string BlockTitle { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class PageContentImageInfo
    {
        public int ImageID { get; set; }
        public string Alt { get; set; }
        public string Thumbnail { get; set; }
        public int DisplayOrder { get; set; }
    }
}
