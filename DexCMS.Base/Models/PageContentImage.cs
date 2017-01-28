using DexCMS.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexCMS.Base.Models
{
    public class PageContentImage
    {
        [Key, Column(Order = 0)]
        public int PageContentID { get; set; }

        [Key, Column(Order = 1)]
        public int ImageID { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        public virtual PageContent PageContent { get; set; }
        public virtual Image Image { get; set; }
    }
}
