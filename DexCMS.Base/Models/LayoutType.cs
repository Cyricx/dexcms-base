using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexCMS.Base.Models
{
    public class LayoutType
    {
        [Key]
        public int LayoutTypeID { get; set; }


        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [Required]
        [StringLength(50)]
        public string CssClass { get; set; }


        [StringLength(250)]
        public string ExampleImage { get; set; }

        [NotMapped]
        public string ReplacementFileName { get; set; }
        [NotMapped]
        public string TemporaryFileName { get; set; }

        public virtual ICollection<PageContent> PageContents { get; set; }
    }
}
