using System.ComponentModel.DataAnnotations;

namespace DexCMS.Base.Models
{
    public class ContentScript
    {

        //Properties
        [Key]
        public int ContentScriptID { get; set; }


        [Required]
        public int PageContentID { get; set; }


        [Required]
        [StringLength(250)]
        public string Path { get; set; }

        //Relationships
        public virtual PageContent PageContent { get; set; }

        ////Non-Mapped Properties
        //[NotMapped]
        //public string FileContent { get; set; }
    }
}
