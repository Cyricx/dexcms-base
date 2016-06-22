using System.Text;
using DexCMS.Base.Mvc.Models;

namespace DexCMS.Base.Mvc.Extensions
{
    public static class UrlBuilder
    {
        public static string BuildUrl(Base.Models.PageContent content)
        {
            ContentRequest request = new ContentRequest
            {
                UrlSegment = content.UrlSegment,
                Area = content.ContentArea.UrlSegment,
                Category = content.ContentCategory?.UrlSegment,
                SubCategory = content.ContentSubCategory?.UrlSegment
            };

            return BuildUrl(request);
        }

        public static string BuildUrl(ContentRequest request)
        {
            StringBuilder url = new StringBuilder();

            url.Append("~");

            if (request.Area != "public" && !string.IsNullOrEmpty(request.Area))
            {
                url.Append("/" + request.Area);
            }

            if (!string.IsNullOrEmpty(request.Category))
            {
                url.Append("/" + request.Category);
            }

            if (!string.IsNullOrEmpty(request.SubCategory))
            {
                url.Append("/" + request.SubCategory);
            }
            url.Append("/");
            if (request.UrlSegment != "index")
            {
                url.Append(request.UrlSegment);
            }


            return url.ToString();
        }
    }

}
