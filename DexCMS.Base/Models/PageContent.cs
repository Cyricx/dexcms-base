using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DexCMS.Base.Enums;

namespace DexCMS.Base.Models
{
    public class PageContent
    {
        [Key]
        public int PageContentID { get; set; }

        [Required]
        [StringLength(250)]
        public string Heading { get; set; }

        [Required]
        [StringLength(50)]
        public string PageTitle { get; set; }
        
        [StringLength(500)]
        public string MetaKeywords { get; set; }

        [StringLength(500)]
        public string MetaDescription { get; set; }

        public int ContentAreaID { get; set; }

        public int? ContentCategoryID { get; set; }

        public int? ContentSubCategoryID { get; set; }

        [Required]
        [StringLength(150)]
        [RegularExpression("^[a-zA-Z0-9-]+$")]
        public string UrlSegment { get; set; }

        public string Body { get; set; }

        public int? MaximumImages { get; set; }

        public SEOChangeFrequency ChangeFrequency { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }

        [Range(typeof(double), "0.0", "1.0")]
        public double? Priority { get; set; }

        public bool AddToSitemap { get; set; }

        public int? LayoutTypeID { get; set; }

        public bool IsDisabled { get; set; }

        public bool RequiresLogin { get; set; }
        
        //Relationships
        public virtual ICollection<PageContentImage> PageContentImages { get; set; }

        public virtual ICollection<ContentBlock> ContentBlocks { get; set; }

        public virtual ICollection<ContentScript> ContentScripts { get; set; }

        public virtual ICollection<ContentStyle> ContentStyles { get; set; }

        public virtual ICollection<PageContentRedirect> PageContentRedirects { get; set; }

        public virtual ContentArea ContentArea { get; set; }
        public virtual ContentCategory ContentCategory { get; set; }
        public virtual ContentSubCategory ContentSubCategory { get; set; }

        public virtual LayoutType LayoutType { get; set; }

        public int PageTypeID { get; set; }
        public virtual PageType PageType { get; set; }

        public virtual ICollection<PageContentPermission> PageContentPermissions { get; set; }

        //Not mapped
        //Will be in the UI
        //[NotMapped]
        //public int[] cbImages { get; set; }

        //[NotMapped]
        //public string NewScriptName { get; set; }

        //[NotMapped]
        //public string NewScriptData { get; set; }

        //[NotMapped] 
        //public string NewStyleName { get; set; }

        //[NotMapped]
        //public string NewStyleData { get; set; }

        //[NotMapped]
        //public System.Web.HttpPostedFileBase[] ScriptFiles { get; set; }

        //[NotMapped]
        //public System.Web.HttpPostedFileBase[] StyleFiles { get; set; }

    }
}
