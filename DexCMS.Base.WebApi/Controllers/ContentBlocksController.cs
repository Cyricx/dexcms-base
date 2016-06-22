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
using DexCMS.Base.WebApi.ApiModels;

namespace DexCMS.Base.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContentBlocksController : ApiController
    {
		private IContentBlockRepository repository;

		public ContentBlocksController(IContentBlockRepository repo) 
		{
			repository = repo;
		}

        // GET api/ContentBlocks
        public List<ContentBlockApiModel> GetContentBlocks()
        {
			var items = repository.Items.Select(x => new ContentBlockApiModel {
				ContentBlockID = x.ContentBlockID,
				BlockTitle = x.BlockTitle,
				ShowTitle = x.ShowTitle,
				BlockBody = x.BlockBody,
				PageContentID = x.PageContentID,
				CssClass = x.CssClass,
				DisplayOrder = x.DisplayOrder
			}).ToList();

			return items;
        }

        // GET api/ContentBlocks/5
        [ResponseType(typeof(ContentBlock))]
        public async Task<IHttpActionResult> GetContentBlock(int id)
        {
			ContentBlock contentBlock = await repository.RetrieveAsync(id);
            if (contentBlock == null)
            {
                return NotFound();
            }

			ContentBlockApiModel model = new ContentBlockApiModel()
			{
				ContentBlockID = contentBlock.ContentBlockID,
				BlockTitle = contentBlock.BlockTitle,
				ShowTitle = contentBlock.ShowTitle,
				BlockBody = contentBlock.BlockBody,
				PageContentID = contentBlock.PageContentID,
				CssClass = contentBlock.CssClass,
				DisplayOrder = contentBlock.DisplayOrder
			
			};

            return Ok(model);
        }

        // PUT api/ContentBlocks/5
        public async Task<IHttpActionResult> PutContentBlock(int id, ContentBlock contentBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contentBlock.ContentBlockID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(contentBlock, contentBlock.ContentBlockID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ContentBlocks
        [ResponseType(typeof(ContentBlock))]
        public async Task<IHttpActionResult> PostContentBlock(ContentBlock contentBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(contentBlock);

            return CreatedAtRoute("DefaultApi", new { id = contentBlock.ContentBlockID }, contentBlock);
        }

        // DELETE api/ContentBlocks/5
        [ResponseType(typeof(ContentBlock))]
        public async Task<IHttpActionResult> DeleteContentBlock(int id)
        {
			ContentBlock contentBlock = await repository.RetrieveAsync(id);
            if (contentBlock == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(contentBlock);

            return Ok(contentBlock);
        }

    }


}