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

        [ResponseType(typeof(List<ContentAreaApiModel>))]
        public List<ContentAreaApiModel> GetContentAreas()
        {
            return ContentAreaApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(ContentAreaApiModel))]
        public async Task<IHttpActionResult> GetContentArea(int id)
        {
            ContentArea contentArea = await repository.RetrieveAsync(id);
            if (contentArea == null)
            {
                return NotFound();
            }

            return Ok(ContentAreaApiModel.MapForClient(contentArea));
        }

        public async Task<IHttpActionResult> PutContentArea(int id, ContentAreaApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.ContentAreaID)
            {
                return BadRequest();
            }
            ContentArea contentArea = await repository.RetrieveAsync(id);
            ContentAreaApiModel.MapForServer(apiModel, contentArea);

            await repository.UpdateAsync(contentArea, contentArea.ContentAreaID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ContentAreaApiModel))]
        public async Task<IHttpActionResult> PostContentArea(ContentAreaApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ContentArea contentArea = new ContentArea();
            ContentAreaApiModel.MapForServer(apiModel, contentArea);

            await repository.AddAsync(contentArea);

            return CreatedAtRoute("DefaultApi", new { id = contentArea.ContentAreaID }, ContentAreaApiModel.MapForClient(contentArea));
        }

        [ResponseType(typeof(ContentAreaApiModel))]
        public async Task<IHttpActionResult> DeleteContentArea(int id)
        {
            ContentArea contentArea = await repository.RetrieveAsync(id);
            if (contentArea == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(contentArea);

            return Ok(ContentAreaApiModel.MapForClient(contentArea));
        }

    }
}