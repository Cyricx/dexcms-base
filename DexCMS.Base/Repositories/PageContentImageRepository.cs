using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DexCMS.Base.Models;
using System.Data.Entity;
using DexCMS.Base.Contexts;
using DexCMS.Base.Interfaces;
using DexCMS.Core.Contexts;
using DexCMS.Core.Repositories;
using DexCMS.Core.Models;

namespace DexCMS.Base.Repositories
{
    public class PageContentImageRepository : AbstractRepository<PageContentImage>, IPageContentImageRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSBaseContext _ctx { get; set; }

        public PageContentImageRepository(IDexCMSBaseContext ctx)
        {
            _ctx = ctx;
        }

        public List<Image> GetAllImages()
        {
            return _ctx.Images.ToList();
        }

        public Task<int> ClearPageContentImages(int pageContentID)
        {
            var pageContentImages = Items.Where(i => i.PageContentID == pageContentID);
            if (pageContentImages != null && pageContentImages.Count() > 0)
            {
                _ctx.PageContentImages.RemoveRange(pageContentImages);
                return _ctx.SaveChangesAsync();
            }
            else
            {
                return Task.FromResult<int>(0);
            }
        }

        public Task<PageContentImage> RetrieveAsync(int? pageContentID, int? imageID)
        {
            if (pageContentID.HasValue && imageID.HasValue)
            {
                return _ctx.PageContentImages.Where(p => p.PageContentID == pageContentID && p.ImageID == imageID).SingleOrDefaultAsync();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// This method WILL THROW AN EXCEPTION. Use the overload that requires two int values.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Throws an application exception.</returns>
        public override Task<PageContentImage> RetrieveAsync(int? id)
        {
            throw new ApplicationException("You must provide a page content id and an image id");
        }
    }
}
