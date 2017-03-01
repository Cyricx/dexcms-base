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

        [ResponseType(typeof(List<PageContentApiModel>))]
        public List<PageContentApiModel> GetPageContents()
        {
            return PageContentApiModel.MapForClient(repository.Items.Where(x => x.PageTypeID == 1));
        }

        [ResponseType(typeof(PageContentApiModel))]
        public async Task<IHttpActionResult> GetPageContent(int id)
        {
			PageContent pageContent = await repository.RetrieveAsync(id);
            if (pageContent == null)
            {
                return NotFound();
            }

            return Ok(PageContentApiModel.MapForClient(pageContent));
        }

        public async Task<IHttpActionResult> PutPageContent(int id, PageContentApiModel apiModel)
        {
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

            if (id != apiModel.PageContentID)
            {
                return BadRequest();
            }
            PageContent pageContent = await repository.RetrieveAsync(id);
            PageContentApiModel.MapForServer(apiModel, pageContent);

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

        [ResponseType(typeof(PageContentApiModel))]
        public async Task<IHttpActionResult> PostPageContent(PageContentApiModel apiModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PageContent pageContent = new PageContent();
            PageContentApiModel.MapForServer(apiModel, pageContent);

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

            return CreatedAtRoute("DefaultApi", new { id = pageContent.PageContentID }, PageContentApiModel.MapForClient(pageContent));
        }

        [ResponseType(typeof(PageContentApiModel))]
        public async Task<IHttpActionResult> DeletePageContent(int id)
        {
			PageContent pageContent = await repository.RetrieveAsync(id);
            if (pageContent == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(pageContent);

            return Ok(PageContentApiModel.MapForClient(pageContent));
        }
    }
}