using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexCMS.Base.Models
{
    public class PageContentRedirect
    {
        //Properties
        [Key]
        public int PageContentRedirectID { get; set; }

        [Required]
        public int PageContentID { get; set; }

        [Required]
        [StringLength(500)]
        [Index(IsUnique =true)]
        public string Url { get; set; }

        //Relationships
        public virtual PageContent PageContent { get; set; }

    }
}
