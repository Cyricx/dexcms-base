using System.Linq;
using System.Threading.Tasks;
using DexCMS.Base.Models;
using System.Data.Entity;
using DexCMS.Base.Contexts;
using DexCMS.Base.Interfaces;
using DexCMS.Core.Contexts;
using DexCMS.Core.Repositories;
using System;
using DexCMS.Base.HelperModels;

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

        public Task<PageContent> RetrieveAsync(RoutePageRequest routeRequest)
        {
            return RetrieveAsync(routeRequest.UrlSegment, routeRequest.Area, routeRequest.Category, routeRequest.SubCategory);
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

        private void UpdatePageContentPermissions(PageContent item)
        {
            _ctx.PageContentPermissions.RemoveRange(_ctx.PageContentPermissions.Where(x => x.PageContentID == item.PageContentID));
            _ctx.SaveChanges();
            if (item.RequiresLogin && item.PageContentPermissions.Count > 0)
            {
                _ctx.PageContentPermissions.AddRange(item.PageContentPermissions);
                _ctx.SaveChanges();
            }
        }

        public override Task<int> UpdateAsync(PageContent item, int id)
        {
            UpdatePageContentPermissions(item);
            return base.UpdateAsync(item, id);
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

            if (item.PageContentPermissions.Count > 0)
            {
                _ctx.PageContentPermissions.RemoveRange(item.PageContentPermissions);
            }

            return base.DeleteAsync(item);
        }

        public Task<PageContent> RetrieveRedirectAsync(string url)
        {
            return _ctx.PageContentRedirects.Where(x => x.Url == url).Select(x => x.PageContent).SingleOrDefaultAsync();
        }
    }
}
