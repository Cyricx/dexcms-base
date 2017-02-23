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
    public class ContentAreasController : ApiController
    {
        private IContentAreaRepository repository;

        public ContentAreasController(IContentAreaRepository repo)
        {
            repository = repo;
        }

        // GET api/ContentAreas
        public List<ContentAreaApiModel> GetContentAreas()
        {
            var items = repository.Items.Select(x => new ContentAreaApiModel(x)).ToList();

            return items;
        }

        // GET api/ContentAreas/5
        [ResponseType(typeof(ContentArea))]
        public async Task<IHttpActionResult> GetContentArea(int id)
        {
            ContentArea contentArea = await repository.RetrieveAsync(id);
            if (contentArea == null)
            {
                return NotFound();
            }

            ContentAreaApiModel model = new ContentAreaApiModel(contentArea);

            return Ok(model);
        }

        // PUT api/ContentAreas/5
        public async Task<IHttpActionResult> PutContentArea(int id, ContentArea contentArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contentArea.ContentAreaID)
            {
                return BadRequest();
            }

            await repository.UpdateAsync(contentArea, contentArea.ContentAreaID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ContentAreas
        [ResponseType(typeof(ContentArea))]
        public async Task<IHttpActionResult> PostContentArea(ContentArea contentArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await repository.AddAsync(contentArea);

            return CreatedAtRoute("DefaultApi", new { id = contentArea.ContentAreaID }, contentArea);
        }

        // DELETE api/ContentAreas/5
        [ResponseType(typeof(ContentArea))]
        public async Task<IHttpActionResult> DeleteContentArea(int id)
        {
            ContentArea contentArea = await repository.RetrieveAsync(id);
            if (contentArea == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(contentArea);

            return Ok(contentArea);
        }

    }
}