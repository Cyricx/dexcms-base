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

        [ResponseType(typeof(List<ContentCategoryApiModel>))]
        public List<ContentCategoryApiModel> GetContentCategories()
        {
            return ContentCategoryApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(ContentCategoryApiModel))]
        public async Task<IHttpActionResult> GetContentCategory(int id)
        {
			ContentCategory contentCategory = await repository.RetrieveAsync(id);
            if (contentCategory == null)
            {
                return NotFound();
            }

            return Ok(ContentCategoryApiModel.MapForClient(contentCategory));
        }

        public async Task<IHttpActionResult> PutContentCategory(int id, ContentCategoryApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.ContentCategoryID)
            {
                return BadRequest();
            }
            ContentCategory contentCategory = await repository.RetrieveAsync(id);
            ContentCategoryApiModel.MapForServer(apiModel, contentCategory);

			await repository.UpdateAsync(contentCategory, contentCategory.ContentCategoryID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ContentCategoryApiModel))]
        public async Task<IHttpActionResult> PostContentCategory(ContentCategoryApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ContentCategory contentCategory = new ContentCategory();
            ContentCategoryApiModel.MapForServer(apiModel, contentCategory);

            await repository.AddAsync(contentCategory);

            return CreatedAtRoute("DefaultApi", new { id = contentCategory.ContentCategoryID }, ContentCategoryApiModel.MapForClient(contentCategory));
        }

        [ResponseType(typeof(ContentCategoryApiModel))]
        public async Task<IHttpActionResult> DeleteContentCategory(int id)
        {
			ContentCategory contentCategory = await repository.RetrieveAsync(id);
            if (contentCategory == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(contentCategory);

            return Ok(ContentCategoryApiModel.MapForClient(contentCategory));
        }
    }
}