using System.Threading.Tasks;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Interfaces;

namespace DexCMS.Base.Interfaces
{
    public interface IPageContentRepository: IRepository<PageContent>
    {
        Task<PageContent> RetrieveAsync(string urlSegment, string contentArea, string contentCategory = "", string contentSubCategory = "");
        Task<PageContent> RetrieveAsync(string urlSegment, int contentAreaID, int? contentCategoryID = null, int? contentSubCategoryID = null);
        Task<PageContent> RetrieveRedirectAsync(string url);
    }

}
