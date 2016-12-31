using DexCMS.Base.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.HelperModels
{
    [NotMapped]
    public class RoutePageRequest
    {
        public string UrlSegment { get; set; }
        public string Area { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public PageContent PageContent { get; set; }
    }
}
