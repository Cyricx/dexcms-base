using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Base.Models
{
    public partial class ContactType
    {
        //Properties
        [Key]
        public int ContactTypeID { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public int DisplayOrder { get; set; }

        [Required]
        public bool IsActive { get; set; }

        //Relationships
        public virtual ICollection<Contact> Contacts { get; set; }

    }
}
