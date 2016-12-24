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
    public class PageContentRedirectsController : ApiController
    {
		private IPageContentRedirectRepository repository;

		public PageContentRedirectsController(IPageContentRedirectRepository repo) 
		{
			repository = repo;
		}

        public List<PageContentRedirectApiModel> GetPageContentRedirects()
        {
			var items = repository.Items.Select(x => new PageContentRedirectApiModel
            {
                PageContentRedirectID = x.PageContentRedirectID,
                Url = x.Url,
                PageContent = new PageContentRedirectPageContentInfoModel
                {
                    PageContentID = x.PageContent.PageContentID,
                    Heading = x.PageContent.Heading
                }
			}).ToList();

			return items;
        }

        [ResponseType(typeof(PageContentRedirect))]
        public async Task<IHttpActionResult> GetPageContentRedirect(int id)
        {
            PageContentRedirect x = await repository.RetrieveAsync(id);
            if (x == null)
            {
                return NotFound();
            }

            PageContentRedirectApiModel model = new PageContentRedirectApiModel()
			{
                PageContentRedirectID = x.PageContentRedirectID,
                Url = x.Url,
                PageContent = new PageContentRedirectPageContentInfoModel
                {
                    PageContentID = x.PageContent.PageContentID,
                    Heading = x.PageContent.Heading
                }
            };

            return Ok(model);
        }

        public async Task<IHttpActionResult> PutPageContentRedirect(int id, PageContentRedirect model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.PageContentRedirectID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(model, model.PageContentRedirectID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(PageContentRedirect))]
        public async Task<IHttpActionResult> PostContentBlock(PageContentRedirect model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(model);

            return CreatedAtRoute("DefaultApi", new { id = model.PageContentRedirectID }, model);
        }

        [ResponseType(typeof(PageContentRedirect))]
        public async Task<IHttpActionResult> DeletePageContentRedirect(int id)
        {
            PageContentRedirect model = await repository.RetrieveAsync(id);
            if (model == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(model);

            return Ok(model);
        }

    }


}