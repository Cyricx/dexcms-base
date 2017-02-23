using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Models;
using DexCMS.Base.WebApi.ApiModels;

namespace DexCMS.Base.WebApi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContentBlockOrderController : ApiController
    {
        private IContentBlockRepository repository;

        public ContentBlockOrderController(IContentBlockRepository repo)
        {
            repository = repo;
        }

        // PUT api/ContentBlockOrder/5
        public async Task<IHttpActionResult> PutContentBlockOrderModel(ContentBlockOrderModel contentBlockOrderModel)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (contentBlockOrderModel.ContentBlockID1.HasValue && contentBlockOrderModel.DisplayOrder1.HasValue)
            {
                await UpdateContentBlockOrder((int)contentBlockOrderModel.ContentBlockID1, (int)contentBlockOrderModel.DisplayOrder1);
            }
            if (contentBlockOrderModel.ContentBlockID2.HasValue && contentBlockOrderModel.DisplayOrder2.HasValue)
            {
                await UpdateContentBlockOrder((int)contentBlockOrderModel.ContentBlockID2, (int)contentBlockOrderModel.DisplayOrder2);
            }
            if (contentBlockOrderModel.ContentBlockID3.HasValue && contentBlockOrderModel.DisplayOrder3.HasValue)
            {
                await UpdateContentBlockOrder((int)contentBlockOrderModel.ContentBlockID3, (int)contentBlockOrderModel.DisplayOrder3);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        private async Task<int> UpdateContentBlockOrder(int blockID, int order)
        {
            ContentBlock cb = await repository.RetrieveAsync(blockID);
            cb.DisplayOrder = order;
            return await repository.UpdateAsync(cb, cb.ContentBlockID);
        }

    }

}