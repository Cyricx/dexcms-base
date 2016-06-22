using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Models;
using DexCMS.Base.WebApi.ApiModels;

namespace DexCMS.Base.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PageContentImagesController : ApiController
    {
        private IPageContentImageRepository repository;

        public PageContentImagesController(IPageContentImageRepository repo)
        {
            repository = repo;
        }

        // GET api/PageContentImages
        public List<PageContentImageApiModel> GetPageContentImages()
        {
            var items = repository.Items.Select(x => new PageContentImageApiModel
            {
                ImageID = x.ImageID,
                PageContentID = x.PageContentID,
                DisplayOrder = x.DisplayOrder,
                Alt = x.Image.Alt,
                Thumbnail = x.Image.Thumbnail
            }).ToList();

            return items;
        }

        // GET api/PageContentImages/5
        public List<PageContentImageApiModel> GetPageContentImage(int id)
        {
            var items = repository.Items.Where(x => x.PageContentID == id).Select(x => new PageContentImageApiModel
            {
                ImageID = x.ImageID,
                PageContentID = x.PageContentID,
                DisplayOrder = x.DisplayOrder,
                Alt = x.Image.Alt,
                Thumbnail = x.Image.Thumbnail
            }).ToList();

            return items;
        }

        // PUT api/PageContentImages/5
        public async Task<IHttpActionResult> PutPageContentImage(PageContentImagesUpdateModel pageContentImagesUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await repository.ClearPageContentImages(pageContentImagesUpdate.PageContentID);

            if (pageContentImagesUpdate.PageContentImages.Length > 0)
            {
                foreach (var item in pageContentImagesUpdate.PageContentImages)
                {
                    var add = await repository.AddAsync(new PageContentImage
                    {
                        PageContentID = pageContentImagesUpdate.PageContentID,
                        ImageID = item.ImageID,
                        DisplayOrder = item.DisplayOrder
                    });
                }
            }

            return StatusCode(HttpStatusCode.NoContent);

        }

        // DELETE api/PageContentImages/5
        [ResponseType(typeof(PageContentImage))]
        public async Task<IHttpActionResult> DeletePageContentImage(int id, int secondKey)
        {
            int pageContentID = secondKey;
            int imageID = id;

            PageContentImage pageContentImage = await repository.RetrieveAsync(pageContentID, imageID);

            if (pageContentImage == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(pageContentImage);

            return Ok(HttpStatusCode.NoContent);
        }

    }



}