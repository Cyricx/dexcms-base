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
    public class PageTypesController : ApiController
    {
		private IPageTypeRepository repository;

		public PageTypesController(IPageTypeRepository repo) 
		{
			repository = repo;
		}

        // GET api/PageTypes
        public List<PageTypeApiModel> GetPageTypes()
        {
			var items = repository.Items.Select(x => new PageTypeApiModel {
				PageTypeID = x.PageTypeID,
				Name = x.Name,
				IsActive = x.IsActive,
                ContentCount = x.PageContents.Count
			}).ToList();

			return items;
        }

        // GET api/PageTypes/5
        [ResponseType(typeof(PageType))]
        public async Task<IHttpActionResult> GetPageType(int id)
        {
			PageType pageType = await repository.RetrieveAsync(id);
            if (pageType == null)
            {
                return NotFound();
            }

			PageTypeApiModel model = new PageTypeApiModel()
			{
				PageTypeID = pageType.PageTypeID,
				Name = pageType.Name,
				IsActive = pageType.IsActive
			};

            return Ok(model);
        }

        // PUT api/PageTypes/5
        public async Task<IHttpActionResult> PutPageType(int id, PageType pageType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pageType.PageTypeID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(pageType, pageType.PageTypeID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/PageTypes
        [ResponseType(typeof(PageType))]
        public async Task<IHttpActionResult> PostPageType(PageType pageType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(pageType);

            return CreatedAtRoute("DefaultApi", new { id = pageType.PageTypeID }, pageType);
        }

        // DELETE api/PageTypes/5
        [ResponseType(typeof(PageType))]
        public async Task<IHttpActionResult> DeletePageType(int id)
        {
			PageType pageType = await repository.RetrieveAsync(id);
            if (pageType == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(pageType);

            return Ok(pageType);
        }

    }
}