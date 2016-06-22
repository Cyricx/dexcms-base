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
    public class ContentSubCategoriesController : ApiController
    {
		private IContentSubCategoryRepository repository;

		public ContentSubCategoriesController(IContentSubCategoryRepository repo) 
		{
			repository = repo;
		}

        // GET api/ContentSubCategories
        public List<ContentSubCategoryApiModel> GetContentSubCategories()
        {
			var items = repository.Items.Select(x => new ContentSubCategoryApiModel {
				ContentSubCategoryID = x.ContentSubCategoryID,
                UrlSegment = x.UrlSegment,
				Name = x.Name,
				IsActive = x.IsActive,
                ContentCount = x.PageContents.Count
			}).ToList();

			return items;
        }

        // GET api/ContentSubCategories/5
        [ResponseType(typeof(ContentSubCategory))]
        public async Task<IHttpActionResult> GetContentSubCategory(int id)
        {
			ContentSubCategory contentSubCategory = await repository.RetrieveAsync(id);
            if (contentSubCategory == null)
            {
                return NotFound();
            }

			ContentSubCategoryApiModel model = new ContentSubCategoryApiModel()
			{
				ContentSubCategoryID = contentSubCategory.ContentSubCategoryID,
				Name = contentSubCategory.Name,
				IsActive = contentSubCategory.IsActive,
			    UrlSegment = contentSubCategory.UrlSegment
			};

            return Ok(model);
        }

        // PUT api/ContentSubCategories/5
        public async Task<IHttpActionResult> PutContentSubCategory(int id, ContentSubCategory contentSubCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contentSubCategory.ContentSubCategoryID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(contentSubCategory, contentSubCategory.ContentSubCategoryID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ContentSubCategories
        [ResponseType(typeof(ContentSubCategory))]
        public async Task<IHttpActionResult> PostContentSubCategory(ContentSubCategory contentSubCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(contentSubCategory);

            return CreatedAtRoute("DefaultApi", new { id = contentSubCategory.ContentSubCategoryID }, contentSubCategory);
        }

        // DELETE api/ContentSubCategories/5
        [ResponseType(typeof(ContentSubCategory))]
        public async Task<IHttpActionResult> DeleteContentSubCategory(int id)
        {
			ContentSubCategory contentSubCategory = await repository.RetrieveAsync(id);
            if (contentSubCategory == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(contentSubCategory);

            return Ok(contentSubCategory);
        }

    }
}