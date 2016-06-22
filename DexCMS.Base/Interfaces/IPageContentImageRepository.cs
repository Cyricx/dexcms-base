using System.Collections.Generic;
using System.Threading.Tasks;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Interfaces;
using DexCMS.Core.Infrastructure.Models;

namespace DexCMS.Base.Interfaces
{
    public interface IPageContentImageRepository: IRepository<PageContentImage>
    {
        List<Image> GetAllImages();
        Task<int> ClearPageContentImages(int pageContentID);
        Task<PageContentImage> RetrieveAsync(int? pageContentID, int? imageID);
    }
}
