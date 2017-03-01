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
    public class ContentBlocksController : ApiController
    {
        private IContentBlockRepository repository;

        public ContentBlocksController(IContentBlockRepository repo)
        {
            repository = repo;
        }

        [ResponseType(typeof(List<ContentBlockApiModel>))]
        public List<ContentBlockApiModel> GetContentBlocks()
        {
            return ContentBlockApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(ContentBlockApiModel))]
        public async Task<IHttpActionResult> GetContentBlock(int id)
        {
            ContentBlock contentBlock = await repository.RetrieveAsync(id);
            if (contentBlock == null)
            {
                return NotFound();
            }

            return Ok(ContentBlockApiModel.MapForClient(contentBlock));
        }

        public async Task<IHttpActionResult> PutContentBlock(int id, ContentBlockApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.ContentBlockID)
            {
                return BadRequest();
            }
            ContentBlock contentBlock = await repository.RetrieveAsync(id);
            ContentBlockApiModel.MapForServer(apiModel, contentBlock);

            await repository.UpdateAsync(contentBlock, contentBlock.ContentBlockID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ContentBlockApiModel))]
        public async Task<IHttpActionResult> PostContentBlock(ContentBlockApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ContentBlock contentBlock = new ContentBlock();
            ContentBlockApiModel.MapForServer(apiModel, contentBlock);

            await repository.AddAsync(contentBlock);

            return CreatedAtRoute("DefaultApi", new { id = contentBlock.ContentBlockID }, ContentBlockApiModel.MapForClient(contentBlock));
        }

        [ResponseType(typeof(ContentBlockApiModel))]
        public async Task<IHttpActionResult> DeleteContentBlock(int id)
        {
            ContentBlock contentBlock = await repository.RetrieveAsync(id);
            if (contentBlock == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(contentBlock);

            return Ok(ContentBlockApiModel.MapForClient(contentBlock));
        }
    }
}