using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class PageContentImageApiModel
    {
        public int ImageID { get; set; }
        public int PageContentID { get; set; }
        public int DisplayOrder { get; set; }
        public string Alt { get; set; }
        public string Thumbnail { get; set; }
    }

    public class PageContentImagesUpdateModel
    {
        public int PageContentID { get; set; }
        public PageContentImageData[] PageContentImages { get; set; }
    }
    public class PageContentImageData
    {
        public int ImageID { get; set; }
        public int DisplayOrder { get; set; }
    }
}
