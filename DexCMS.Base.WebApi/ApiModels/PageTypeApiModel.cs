using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class PageTypeApiModel
    {
        public int PageTypeID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int ContentCount { get; set; }
    }
}
