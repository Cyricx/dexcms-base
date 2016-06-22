using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexCMS.Base.Models
{
    public partial class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Phone { get; set; }

        [Required]
        [StringLength(250)]
        [EmailAddress]
        [RegularExpression("^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"
        + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$")]
        public string Email { get; set; }

        [NotMapped]
        [Required]
        [Compare("Email")]
        [StringLength(250)]
        public string ConfirmEmail { get; set; }

        [Required]
        [StringLength(2000)]
        public string Message { get; set; }


        [StringLength(250)]
        public string OtherSubject { get; set; }

        [Required]
        public DateTime SubmitDate { get; set; }

        [StringLength(400)]
        public string Referrer { get; set; }

        public int ContactTypeID { get; set; }
        
        //! NOT MAPPED
        [NotMapped]
        public List<string> VisitedUrlsToAdd { get; set; }
        [NotMapped]
        public int[] VisitsToRemove { get; set; }

        //! Relationships
        public virtual ICollection<VisitedPage> VisitedPages { get; set; }
        public virtual ContactType ContactType { get; set; }

    }
}
