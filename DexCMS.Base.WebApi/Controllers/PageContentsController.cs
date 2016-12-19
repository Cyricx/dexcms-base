using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Base.Models;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Enums;
using DexCMS.Base.WebApi.ApiModels;

namespace DexCMS.Base.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PageContentsController : ApiController
    {
		private IPageContentRepository repository;

		public PageContentsController(IPageContentRepository repo) 
		{
			repository = repo;
		}

        // GET api/PageContents
        public List<PageContentApiModel> GetPageContents()
        {
			var items = repository.Items.Where(x => x.PageTypeID == 1)
                .Select(x => new PageContentApiModel {
				PageContentID = x.PageContentID,
				Heading = x.Heading,
				Body = x.Body,
				PageTitle = x.PageTitle,
				MetaKeywords = x.MetaKeywords,
				MetaDescription = x.MetaDescription,
				ContentAreaID = x.ContentAreaID,
                ContentAreaName = x.ContentArea.Name,
                ContentCategoryID = x.ContentCategoryID,
                ContentCategoryName = x.ContentCategory.Name,
                ContentSubCategoryID = x.ContentSubCategoryID,
                ContentSubCategoryName = x.ContentSubCategory.Name,
                UrlSegment = x.UrlSegment,
				ChangeFrequency = x.ChangeFrequency,
				LastModified = x.LastModified,
				LastModifiedBy = x.LastModifiedBy,
				Priority = x.Priority,
				AddToSitemap = x.AddToSitemap,
                PageTypeID = x.PageTypeID,
                PageTypeName = x.PageType.Name,
                MaximumImages = x.MaximumImages,
                LayoutTypeID = x.LayoutTypeID,
                LayoutTypeName = x.LayoutType.Name,
                Disabled = x.Disabled
            }).ToList();

			return items;
        }

        // GET api/PageContents/5
        [ResponseType(typeof(PageContent))]
        public async Task<IHttpActionResult> GetPageContent(int id)
        {
			PageContent pageContent = await repository.RetrieveAsync(id);
            if (pageContent == null)
            {
                return NotFound();
            }

			PageContentApiModel model = new PageContentApiModel()
			{
				PageContentID = pageContent.PageContentID,
				Heading = pageContent.Heading,
				Body = pageContent.Body,
				PageTitle = pageContent.PageTitle,
				MetaKeywords = pageContent.MetaKeywords,
				MetaDescription = pageContent.MetaDescription,
				ContentAreaID = pageContent.ContentAreaID,
                ContentCategoryID = pageContent.ContentCategoryID,
                ContentSubCategoryID = pageContent.ContentSubCategoryID,
                ContentAreaName = pageContent.ContentArea.Name,
                ContentCategoryName = pageContent.ContentCategoryID.HasValue ? pageContent.ContentCategory.Name : "",
                ContentSubCategoryName = pageContent.ContentSubCategoryID.HasValue ? pageContent.ContentSubCategory.Name : "",
                ChangeFrequency = pageContent.ChangeFrequency,
				LastModified = pageContent.LastModified,
				LastModifiedBy = pageContent.LastModifiedBy,
				Priority = pageContent.Priority,
				AddToSitemap = pageContent.AddToSitemap,
                MaximumImages = pageContent.MaximumImages,
                ContentBlocks = pageContent.ContentBlocks.OrderBy(x => x.DisplayOrder)
                    .Select(x => new ContentBlockInfo
                    {
                        ContentBlockID = x.ContentBlockID,
                        BlockTitle = x.BlockTitle,
                        DisplayOrder = x.DisplayOrder
                    }).ToList(),
                PageContentImages = pageContent.PageContentImages.OrderBy(x => x.DisplayOrder)
                    .Select(x => new PageContentImageInfo
                    {
                        ImageID = x.ImageID,
                        Alt = x.Image.Alt,
                        DisplayOrder = x.DisplayOrder,
                        Thumbnail = x.Image.Thumbnail
                    }).ToList(),
                LayoutTypeID = pageContent.LayoutTypeID,
                PageTypeID  = pageContent.PageTypeID,
                UrlSegment = pageContent.UrlSegment,
                LayoutTypeName = pageContent.LayoutTypeID.HasValue ? pageContent.LayoutType.Name : "",
                Disabled = pageContent.Disabled
            };

            return Ok(model);
        }

        // PUT api/PageContents/5
        public async Task<IHttpActionResult> PutPageContent(int id, PageContent pageContent)
        {
            pageContent.ContentBlocks = null;
            pageContent.PageContentImages = null;
            for (int i = 0; i < 3; i++)
            {
                if (ModelState.ContainsKey("pageContent.ContentBlocks["+ i + "].BlockBody"))
                {
                    ModelState["pageContent.ContentBlocks[" + i + "].BlockBody"].Errors.Clear();
                }
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pageContent.PageContentID)
            {
                return BadRequest();
            }

            //Verify it is not a duplicate
            var matchingPageContent = await repository.RetrieveAsync(pageContent.UrlSegment, pageContent.ContentAreaID, pageContent.ContentCategoryID, pageContent.ContentSubCategoryID);

            if (matchingPageContent != null && matchingPageContent.PageContentID != id)
            {
                ModelState.AddModelError("Errors", "A page already exists with this controller, action and area");
                return BadRequest(ModelState);
            }

            pageContent.LastModified = DateTime.Now;
            pageContent.LastModifiedBy = User.Identity.Name;

			await repository.UpdateAsync(pageContent, pageContent.PageContentID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/PageContents
        [ResponseType(typeof(PageContent))]
        public async Task<IHttpActionResult> PostPageContent(PageContent pageContent)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Verify it is not a duplicate
            var matchingPageContent = await repository.RetrieveAsync(pageContent.UrlSegment, pageContent.ContentAreaID, pageContent.ContentCategoryID, pageContent.ContentSubCategoryID);

            if (matchingPageContent != null)
            {
                ModelState.AddModelError("Errors", "A page already exists with this controller, action and area");
                return BadRequest(ModelState);
            }

            pageContent.LastModified = DateTime.Now;
            pageContent.LastModifiedBy = User.Identity.Name;

            await repository.AddAsync(pageContent);

            return CreatedAtRoute("DefaultApi", new { id = pageContent.PageContentID }, pageContent);
        }

        // DELETE api/PageContents/5
        [ResponseType(typeof(PageContent))]
        public async Task<IHttpActionResult> DeletePageContent(int id)
        {
			PageContent pageContent = await repository.RetrieveAsync(id);
            if (pageContent == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(pageContent);

            return Ok(pageContent);
        }

    }
}