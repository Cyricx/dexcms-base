using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.WebApi.ApiModels
{

    public class ContentBlockApiModel
    {
        public int ContentBlockID { get; set; }

        public string BlockTitle { get; set; }

        public bool ShowTitle { get; set; }

        public string BlockBody { get; set; }

        public int PageContentID { get; set; }

        public string CssClass { get; set; }

        public int DisplayOrder { get; set; }

    }
}
