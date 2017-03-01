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
    public class ContactTypesController : ApiController
    {
        private IContactTypeRepository repository;

        public ContactTypesController(IContactTypeRepository repo)
        {
            repository = repo;
        }

        [ResponseType(typeof(List<ContactTypeApiModel>))]
        public List<ContactTypeApiModel> GetContactTypes()
        {
            return ContactTypeApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(ContactTypeApiModel))]
        public async Task<IHttpActionResult> GetContactType(int id)
        {
            ContactType contactType = await repository.RetrieveAsync(id);
            if (contactType == null)
            {
                return NotFound();
            }

            return Ok(ContactTypeApiModel.MapForClient(contactType));
        }

        public async Task<IHttpActionResult> PutContactType(int id, ContactTypeApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.ContactTypeID)
            {
                return BadRequest();
            }

            ContactType contactType = await repository.RetrieveAsync(id);
            ContactTypeApiModel.MapForServer(apiModel, contactType);

            await repository.UpdateAsync(contactType, contactType.ContactTypeID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ContactTypeApiModel))]
        public async Task<IHttpActionResult> PostContactType(ContactTypeApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ContactType contactType = new ContactType();
            ContactTypeApiModel.MapForServer(apiModel, contactType);

            await repository.AddAsync(contactType);

            return CreatedAtRoute("DefaultApi", new { id = contactType.ContactTypeID }, ContactTypeApiModel.MapForClient(contactType));
        }

        [ResponseType(typeof(ContactTypeApiModel))]
        public async Task<IHttpActionResult> DeleteContactType(int id)
        {
            ContactType contactType = await repository.RetrieveAsync(id);
            if (contactType == null)
            {
                return NotFound();
            }

            await repository.DeleteAsync(contactType);

            return Ok(ContactTypeApiModel.MapForClient(contactType));
        }
    }
}