using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DexCMS.Base.Interfaces;
using DexCMS.Base.WebApi.ApiModels;

namespace DexCMS.Base.WebApi.Controllers
{
    public class RetrieveContentsController : ApiController
    {
        private IPageContentRepository repository;

        public RetrieveContentsController(IPageContentRepository repo)
        {
            repository = repo;
        }

        [ResponseType(typeof(RetrieveContentApiModel))]
        public async Task<IHttpActionResult> GetRetrieveContent(string contentName)
        {
            switch (contentName)
            {
                case "securecomplete":
                    var content = await repository.RetrieveAsync("complete", "secure", "secure");
                    if (content != null)
                    {
                        return Ok(RetrieveContentApiModel.MapForClient(content));
                    }
                    break;
                default:
                    break;
            }
            return BadRequest();
        }

    }
}
