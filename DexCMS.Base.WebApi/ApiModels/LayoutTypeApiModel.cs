using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class LayoutTypeApiModel
    {
        public int LayoutTypeID { get; set; }
        public string Name { get; set; }
        public string CssClass { get; set; }
        public int PageContentCount { get; set; }
        public string ReplacementFileName { get; set; }
        public string ExampleImage { get; set; }
    }
}
