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
			var items = repository.Items.Select(x => new ContactApiModel {
				ContactID = x.ContactID,
				Name = x.Name,
				Phone = x.Phone,
				Email = x.Email,
				Message = x.Message,
				OtherSubject = x.OtherSubject,
				SubmitDate = x.SubmitDate,
				Referrer = x.Referrer,
				ContactTypeID = x.ContactTypeID,
                ContactTypeName = x.ContactType.Name
			}).ToList();

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

			ContactApiModel model = new ContactApiModel()
			{
				ContactID = contact.ContactID,
				Name = contact.Name,
				Phone = contact.Phone,
				Email = contact.Email,
				Message = contact.Message,
				OtherSubject = contact.OtherSubject,
				SubmitDate = contact.SubmitDate,
				Referrer = contact.Referrer,
				ContactTypeID = contact.ContactTypeID,
			    ContactTypeName = contact.ContactType.Name,
                VisitedPages = contact.VisitedPages == null ? new List<VisitedPage>(): contact.VisitedPages.OrderBy(x => x.VisitOrder).ToList()
			};

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