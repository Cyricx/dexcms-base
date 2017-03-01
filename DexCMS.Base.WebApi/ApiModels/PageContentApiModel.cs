using System;
using System.Collections.Generic;
using DexCMS.Base.Enums;
using DexCMS.Base.Models;
using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class PageContentApiModel:DexCMSViewModel<PageContentApiModel, PageContent>
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

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("ContentArea", "Name")]
        public string ContentAreaName { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("ContentCategory", "Name")]
        public string ContentCategoryName { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("ContentSubCategory", "Name")]
        public string ContentSubCategoryName { get; set; }

        public string UrlSegment { get; set; }

        public int? PageTypeID { get; set; }
        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("PageType", "Name")]
        public string PageTypeName { get; set; }

        public int? LayoutTypeID { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("LayoutType", "Name")]
        public string LayoutTypeName { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedClassMapping(typeof(ContentBlockApiModel), true)]
        public List<ContentBlockApiModel> ContentBlocks { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedClassMapping(typeof(PageContentImageApiModel), true)]
        public List<PageContentImageApiModel> PageContentImages { get; set; }
        public bool IsDisabled { get; set; }
        public bool RequiresLogin { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedClassMapping(typeof(PageContentPermissionApiModel), true)]
        public List<PageContentPermissionApiModel> PageContentPermissions { get; set; }
    }
}
