using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        // GET api/RetrieveContents/5
        [ResponseType(typeof(RetrieveContentApiModel))]
        public async Task<IHttpActionResult> GetRetrieveContent(string contentName)
        {
            switch (contentName)
            {
                case "securecomplete":
                    var content = await repository.RetrieveAsync("complete", "secure", "secure");
                    if (content != null)
                    {
                        RetrieveContentApiModel model = new RetrieveContentApiModel
                        {
                            Body = content.Body,
                            PageTitle = content.PageTitle,
                            Title = content.Heading,
                            ContentBlocks = content.ContentBlocks.OrderBy(x => x.DisplayOrder).Select(x => new RetrieveContentBlockApiModel
                            {
                                BlockBody = x.BlockBody
                            }).ToList()
                        };
                        return Ok(model);
                    }
                    break;
                default:
                    break;
            }
            return BadRequest();
        }

    }
}
