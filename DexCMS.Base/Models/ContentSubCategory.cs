using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Base.Models
{
    public class ContentSubCategory
    {
        [Key]
        public int ContentSubCategoryID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        [RegularExpression("^[a-zA-Z0-9-]+$")]
        public string UrlSegment { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<PageContent> PageContents { get; set; }
    }
}
