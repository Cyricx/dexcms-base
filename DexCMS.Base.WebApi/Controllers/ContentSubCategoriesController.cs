using System.Collections.Generic;
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

        [ResponseType(typeof(List<ContentSubCategoryApiModel>))]
        public List<ContentSubCategoryApiModel> GetContentSubCategories()
        {
            return ContentSubCategoryApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(ContentSubCategory))]
        public async Task<IHttpActionResult> GetContentSubCategory(int id)
        {
			ContentSubCategory contentSubCategory = await repository.RetrieveAsync(id);
            if (contentSubCategory == null)
            {
                return NotFound();
            }

            return Ok(ContentSubCategoryApiModel.MapForClient(contentSubCategory));
        }

        public async Task<IHttpActionResult> PutContentSubCategory(int id, ContentSubCategoryApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.ContentSubCategoryID)
            {
                return BadRequest();
            }
            ContentSubCategory contentSubCategory = await repository.RetrieveAsync(id);
            ContentSubCategoryApiModel.MapForServer(apiModel, contentSubCategory);

            await repository.UpdateAsync(contentSubCategory, contentSubCategory.ContentSubCategoryID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ContentSubCategoryApiModel))]
        public async Task<IHttpActionResult> PostContentSubCategory(ContentSubCategoryApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ContentSubCategory contentSubCategory = new ContentSubCategory();
            ContentSubCategoryApiModel.MapForServer(apiModel, contentSubCategory);

            await repository.AddAsync(contentSubCategory);

            return CreatedAtRoute("DefaultApi", new { id = contentSubCategory.ContentSubCategoryID }, ContentSubCategoryApiModel.MapForClient(contentSubCategory));
        }

        [ResponseType(typeof(ContentSubCategoryApiModel))]
        public async Task<IHttpActionResult> DeleteContentSubCategory(int id)
        {
			ContentSubCategory contentSubCategory = await repository.RetrieveAsync(id);
            if (contentSubCategory == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(contentSubCategory);

            return Ok(ContentSubCategoryApiModel.MapForClient(contentSubCategory));
        }
    }
}