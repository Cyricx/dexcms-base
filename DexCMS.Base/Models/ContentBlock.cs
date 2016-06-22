using System.ComponentModel.DataAnnotations;

namespace DexCMS.Base.Models
{
    public class ContentBlock
    {

        //Properties
        [Key]
        public int ContentBlockID { get; set; }


        [Required]
        [StringLength(150)]
        public string BlockTitle { get; set; }

        [Required]
        public bool ShowTitle { get; set; }

        [Required]
        public string BlockBody { get; set; }


        [Required]
        public int PageContentID { get; set; }

        [StringLength(100)]
        public string CssClass { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        //Relationships
        public virtual PageContent PageContent { get; set; }

    }
}
