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
    public class PageTypesController : ApiController
    {
		private IPageTypeRepository repository;

		public PageTypesController(IPageTypeRepository repo) 
		{
			repository = repo;
		}

        [ResponseType(typeof(List<PageTypeApiModel>))]
        public List<PageTypeApiModel> GetPageTypes()
        {
            return PageTypeApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(PageTypeApiModel))]
        public async Task<IHttpActionResult> GetPageType(int id)
        {
			PageType pageType = await repository.RetrieveAsync(id);
            if (pageType == null)
            {
                return NotFound();
            }

            return Ok(PageTypeApiModel.MapForClient(pageType));
        }

        public async Task<IHttpActionResult> PutPageType(int id, PageTypeApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.PageTypeID)
            {
                return BadRequest();
            }
            PageType pageType = await repository.RetrieveAsync(id);
            PageTypeApiModel.MapForServer(apiModel, pageType);

            await repository.UpdateAsync(pageType, pageType.PageTypeID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(PageTypeApiModel))]
        public async Task<IHttpActionResult> PostPageType(PageTypeApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PageType pageType = new PageType();
            PageTypeApiModel.MapForServer(apiModel, pageType);

            await repository.AddAsync(pageType);

            return CreatedAtRoute("DefaultApi", new { id = pageType.PageTypeID }, PageTypeApiModel.MapForClient(pageType));
        }

        [ResponseType(typeof(PageTypeApiModel))]
        public async Task<IHttpActionResult> DeletePageType(int id)
        {
			PageType pageType = await repository.RetrieveAsync(id);
            if (pageType == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(pageType);

            return Ok(PageTypeApiModel.MapForClient(pageType));
        }

    }
}