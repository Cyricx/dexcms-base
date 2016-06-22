using System.ComponentModel.DataAnnotations;

namespace DexCMS.Base.Models
{
    public partial class VisitedPage
    {
        [Key]
        public int VisitedPageID { get; set; }

        [Required]
        [MaxLength(4000)]
        public string URL { get; set; }

        [Required]
        public int VisitOrder { get; set; }

        public int ContactID { get; set; }

        public virtual Contact Contact { get; set; }

    }
}
