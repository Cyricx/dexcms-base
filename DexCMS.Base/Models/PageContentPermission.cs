using DexCMS.Core.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DexCMS.Base.Models
{
    public class PageContentPermission
    {
        [Key, Column(Order = 0)]
        public int PageContentID { get; set; }

        [Key, Column(Order = 1)]
        public string Id { get; set; }

        public virtual PageContent PageContent { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
