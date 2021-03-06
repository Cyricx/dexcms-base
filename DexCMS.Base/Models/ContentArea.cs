﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DexCMS.Base.Models
{
    public class ContentArea
    {
        [Key]
        public int ContentAreaID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(150)]
        [RegularExpression("^[a-zA-Z0-9-]*$")]
        public string UrlSegment { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public virtual ICollection<PageContent> PageContents { get; set; }
    }
}
