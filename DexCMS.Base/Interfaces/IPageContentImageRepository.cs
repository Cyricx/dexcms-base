using System.Collections.Generic;
using System.Threading.Tasks;
using DexCMS.Base.Models;
using DexCMS.Core.Interfaces;
using DexCMS.Core.Models;

namespace DexCMS.Base.Interfaces
{
    public interface IPageContentImageRepository: IRepository<PageContentImage>
    {
        List<Image> GetAllImages();
        Task<int> ClearPageContentImages(int pageContentID);
        Task<PageContentImage> RetrieveAsync(int? pageContentID, int? imageID);
    }
}
