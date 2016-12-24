using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.WebApi.ApiModels
{

    public class PageContentRedirectApiModel
    {
        public int PageContentRedirectID { get; set; }

        public string Url { get; set; }

        public int PageContentID { get; set; }

        public int DisplayOrder { get; set; }
        public PageContentRedirectPageContentInfoModel PageContent { get; set; }
    }

    public class PageContentRedirectPageContentInfoModel
    {
        public int PageContentID { get; set; }
        public string Heading { get; set; }
    }
}
