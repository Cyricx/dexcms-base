using System.Linq;
using System.Threading.Tasks;
using DexCMS.Base.Models;
using System.Data.Entity;
using DexCMS.Base.Contexts;
using DexCMS.Base.Interfaces;
using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Repositories;

namespace DexCMS.Base.Repositories
{
    public class PageContentRepository : AbstractRepository<PageContent>, IPageContentRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSBaseContext _ctx { get; set; }

        public PageContentRepository(IDexCMSBaseContext ctx)
        {
            _ctx = ctx;
        }

        public Task<PageContent> RetrieveAsync(string urlSegment, string contentArea, string contentCategory = "", string contentSubCategory = "")
        {
            if (string.IsNullOrEmpty(contentCategory))
            {
                return _ctx.PageContents.Where(
                x => x.UrlSegment == urlSegment
                && x.ContentArea.UrlSegment == contentArea
                && x.IsDisabled != true).SingleOrDefaultAsync();
            }
            else
            {
                if (string.IsNullOrEmpty(contentSubCategory))
                {
                    return _ctx.PageContents.Where(
                        x => x.UrlSegment == urlSegment
                        && x.ContentArea.UrlSegment == contentArea
                        && x.ContentCategory.UrlSegment == contentCategory
                        && x.IsDisabled != true).SingleOrDefaultAsync();
                }
                else
                {
                    return _ctx.PageContents.Where(
                        x => x.UrlSegment == urlSegment
                        && x.ContentArea.UrlSegment == contentArea
                        && x.ContentCategory.UrlSegment == contentCategory
                        && x.ContentSubCategory.UrlSegment == contentSubCategory
                        && x.IsDisabled != true).SingleOrDefaultAsync();
                }
            }
        }
        public Task<PageContent> RetrieveAsync(string urlSegment, int contentAreaID, int? contentCategoryID = null, int? contentSubCategoryID = null)
        {
            if (!contentCategoryID.HasValue)
            {
                return _ctx.PageContents.Where(
                    x => x.UrlSegment == urlSegment
                    && x.ContentAreaID == contentAreaID
                    && x.IsDisabled != true).SingleOrDefaultAsync();
            }
            else
            {
                if (!contentSubCategoryID.HasValue)
                {
                    return _ctx.PageContents.Where(
                        x => x.UrlSegment == urlSegment
                        && x.ContentAreaID == contentAreaID
                        && x.ContentCategoryID == contentCategoryID
                        && x.IsDisabled != true).SingleOrDefaultAsync();
                }
                else
                {
                    return _ctx.PageContents.Where(
                        x => x.UrlSegment == urlSegment
                        && x.ContentAreaID == contentAreaID
                        && x.ContentCategoryID == contentCategoryID
                        && x.ContentSubCategoryID == contentSubCategoryID
                        && x.IsDisabled != true).SingleOrDefaultAsync();
                }
            }
        }

        public override Task<int> DeleteAsync(PageContent item)
        {

            //delete content blocks
            if (item.ContentBlocks.Count > 0)
            {
                _ctx.ContentBlocks.RemoveRange(item.ContentBlocks);
            }

            //delete content scripts
            if (item.ContentScripts.Count > 0)
            {
                _ctx.ContentScripts.RemoveRange(item.ContentScripts);
            }

            //delete content styles
            if (item.ContentStyles.Count > 0)
            {
                _ctx.ContentStyles.RemoveRange(item.ContentStyles);
            }

            //delete content images
            if (item.PageContentImages.Count > 0)
            {
                _ctx.PageContentImages.RemoveRange(item.PageContentImages);
            }

            return base.DeleteAsync(item);
        }
    }
}
