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
    public class ContactsController : ApiController
    {
		private IContactRepository repository;

		public ContactsController(IContactRepository repo) 
		{
			repository = repo;
		}

        [ResponseType(typeof(List<ContactApiModel>))]
        public List<ContactApiModel> GetContacts()
        {
            return ContactApiModel.MapForClient(repository.Items);
        }

        [ResponseType(typeof(ContactApiModel))]
        public async Task<IHttpActionResult> GetContact(int id)
        {
			Contact contact = await repository.RetrieveAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(ContactApiModel.MapForClient(contact));
        }

        public async Task<IHttpActionResult> PutContact(int id, ContactApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != apiModel.ContactID)
            {
                return BadRequest();
            }
            Contact contact = await repository.RetrieveAsync(id);
            ContactApiModel.MapForServer(apiModel, contact);

            await repository.UpdateAsync(contact, contact.ContactID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(ContactApiModel))]
        public async Task<IHttpActionResult> PostContact(ContactApiModel apiModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Contact contact = new Contact();
            ContactApiModel.MapForServer(apiModel, contact);

            await repository.AddAsync(contact);

            return CreatedAtRoute("DefaultApi", new { id = contact.ContactID }, ContactApiModel.MapForClient(contact));
        }

        [ResponseType(typeof(ContactApiModel))]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
			Contact contact = await repository.RetrieveAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(contact);

            return Ok(ContactApiModel.MapForClient(contact));
        }
    }
}