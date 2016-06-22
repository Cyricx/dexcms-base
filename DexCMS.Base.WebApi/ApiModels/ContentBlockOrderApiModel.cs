using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.WebApi.ApiModels
{

    public class ContentBlockOrderModel
    {
        public int? ContentBlockID1 { get; set; }
        public int? DisplayOrder1 { get; set; }
        public int? ContentBlockID2 { get; set; }
        public int? DisplayOrder2 { get; set; }
        public int? ContentBlockID3 { get; set; }
        public int? DisplayOrder3 { get; set; }
    }

}
