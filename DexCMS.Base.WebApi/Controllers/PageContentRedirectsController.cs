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
    public class PageContentRedirectsController : ApiController
    {
		private IPageContentRedirectRepository repository;

		public PageContentRedirectsController(IPageContentRedirectRepository repo) 
		{
			repository = repo;
		}

        [ResponseType(typeof(List<PageContentRedirectApiModel>))]
        public List<PageContentRedirectApiModel> GetPageContentRedirects()
        {
            return PageContentRedirectApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(PageContentRedirectApiModel))]
        public async Task<IHttpActionResult> GetPageContentRedirect(int id)
        {
            PageContentRedirect pageContentRedirect = await repository.RetrieveAsync(id);
            if (pageContentRedirect == null)
            {
                return NotFound();
            }

            return Ok(PageContentRedirectApiModel.MapForClient(pageContentRedirect));
        }

        public async Task<IHttpActionResult> PutPageContentRedirect(int id, PageContentRedirectApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.PageContentRedirectID)
            {
                return BadRequest();
            }
            PageContentRedirect pageContentRedirect = await repository.RetrieveAsync(id);
            PageContentRedirectApiModel.MapForServer(apiModel, pageContentRedirect);

			await repository.UpdateAsync(pageContentRedirect, pageContentRedirect.PageContentRedirectID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(PageContentRedirectApiModel))]
        public async Task<IHttpActionResult> PostContentBlock(PageContentRedirectApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PageContentRedirect model = new PageContentRedirect();
            PageContentRedirectApiModel.MapForServer(apiModel, model);

            await repository.AddAsync(model);

            return CreatedAtRoute("DefaultApi", new { id = model.PageContentRedirectID }, PageContentRedirectApiModel.MapForClient(model));
        }

        [ResponseType(typeof(PageContentRedirectApiModel))]
        public async Task<IHttpActionResult> DeletePageContentRedirect(int id)
        {
            PageContentRedirect model = await repository.RetrieveAsync(id);
            if (model == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(model);

            return Ok(PageContentRedirectApiModel.MapForClient(model));
        }
    }
}