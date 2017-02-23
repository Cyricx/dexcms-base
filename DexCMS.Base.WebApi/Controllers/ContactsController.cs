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

        // GET api/Contacts
        public List<ContactApiModel> GetContacts()
        {
			var items = repository.Items.Select(x => new ContactApiModel(x)).ToList();

			return items;
        }

        // GET api/Contacts/5
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> GetContact(int id)
        {
			Contact contact = await repository.RetrieveAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            ContactApiModel model = new ContactApiModel(contact);

            return Ok(model);
        }

        // PUT api/Contacts/5
        public async Task<IHttpActionResult> PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ContactID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(contact, contact.ContactID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Contacts
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(contact);

            return CreatedAtRoute("DefaultApi", new { id = contact.ContactID }, contact);
        }

        // DELETE api/Contacts/5
        [ResponseType(typeof(Contact))]
        public async Task<IHttpActionResult> DeleteContact(int id)
        {
			Contact contact = await repository.RetrieveAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(contact);

            return Ok(contact);
        }

    }
}