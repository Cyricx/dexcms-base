using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Base.Models;
using DexCMS.Base.Interfaces;
using DexCMS.Base.WebApi.ApiModels;

namespace DexCMS.Base.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContentCategoriesController : ApiController
    {
		private IContentCategoryRepository repository;

		public ContentCategoriesController(IContentCategoryRepository repo) 
		{
			repository = repo;
		}

        // GET api/ContentCategories
        public List<ContentCategoryApiModel> GetContentCategories()
        {
			var items = repository.Items.Select(x => new ContentCategoryApiModel {
				ContentCategoryID = x.ContentCategoryID,
                UrlSegment = x.UrlSegment,
				Name = x.Name,
				IsActive = x.IsActive,
                ContentCount = x.PageContents.Count
			}).ToList();

			return items;
        }

        // GET api/ContentCategories/5
        [ResponseType(typeof(ContentCategory))]
        public async Task<IHttpActionResult> GetContentCategory(int id)
        {
			ContentCategory contentCategory = await repository.RetrieveAsync(id);
            if (contentCategory == null)
            {
                return NotFound();
            }

			ContentCategoryApiModel model = new ContentCategoryApiModel()
			{
				ContentCategoryID = contentCategory.ContentCategoryID,
				Name = contentCategory.Name,
				IsActive = contentCategory.IsActive,
			    UrlSegment = contentCategory.UrlSegment
			};

            return Ok(model);
        }

        // PUT api/ContentCategories/5
        public async Task<IHttpActionResult> PutContentCategory(int id, ContentCategory contentCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contentCategory.ContentCategoryID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(contentCategory, contentCategory.ContentCategoryID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ContentCategories
        [ResponseType(typeof(ContentCategory))]
        public async Task<IHttpActionResult> PostContentCategory(ContentCategory contentCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(contentCategory);

            return CreatedAtRoute("DefaultApi", new { id = contentCategory.ContentCategoryID }, contentCategory);
        }

        // DELETE api/ContentCategories/5
        [ResponseType(typeof(ContentCategory))]
        public async Task<IHttpActionResult> DeleteContentCategory(int id)
        {
			ContentCategory contentCategory = await repository.RetrieveAsync(id);
            if (contentCategory == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(contentCategory);

            return Ok(contentCategory);
        }

    }
}