using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Base.Models
{
    public class PageType
    {
        [Key]
        public int PageTypeID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<PageContent> PageContents { get; set; }
    }
}
