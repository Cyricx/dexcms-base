using System.Collections.Generic;
using System.Xml.Linq;

namespace DexCMS.Base.Infrastructure
{
    /// <summary>
    /// File originally created by Ben Foster: https://github.com/benfoster/Fabrik.Common/tree/master/src/Fabrik.Common.Web/SEO
    /// </summary>
    public interface ISitemapGenerator
    {
        XDocument GenerateSiteMap(IEnumerable<ISitemapItem> items);
    }
}