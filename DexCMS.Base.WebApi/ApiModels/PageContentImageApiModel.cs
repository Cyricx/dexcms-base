using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DexCMS.Base.Models;
using DexCMS.Core.Globals;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class PageContentImageApiModel:DexCMSViewModel<PageContentImageApiModel, PageContentImage>
    {
        public int ImageID { get; set; }
        public int PageContentID { get; set; }
        public int DisplayOrder { get; set; }
        public string Alt { get; set; }
        public string Thumbnail { get; set; }
    }

    public class PageContentImagesUpdateApiModel
    {
        public int PageContentID { get; set; }
        public PageContentImageDataUpdateApiModel[] PageContentImages { get; set; }
    }
    public class PageContentImageDataUpdateApiModel
    {
        public int ImageID { get; set; }
        public int DisplayOrder { get; set; }
    }
}
