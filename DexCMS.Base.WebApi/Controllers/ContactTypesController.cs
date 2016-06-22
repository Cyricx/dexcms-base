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
    public class ContactTypesController : ApiController
    {
		private IContactTypeRepository repository;

		public ContactTypesController(IContactTypeRepository repo) 
		{
			repository = repo;
		}

        // GET api/ContactTypes
        public List<ContactTypeApiModel> GetContactTypes()
        {
			var items = repository.Items.Select(x => new ContactTypeApiModel {
				ContactTypeID = x.ContactTypeID,
				Name = x.Name,
				DisplayOrder = x.DisplayOrder,
				IsActive = x.IsActive,
                ContactCount = x.Contacts.Count
			}).ToList();

			return items;
        }

        // GET api/ContactTypes/5
        [ResponseType(typeof(ContactType))]
        public async Task<IHttpActionResult> GetContactType(int id)
        {
			ContactType contactType = await repository.RetrieveAsync(id);
            if (contactType == null)
            {
                return NotFound();
            }

			ContactTypeApiModel model = new ContactTypeApiModel()
			{
				ContactTypeID = contactType.ContactTypeID,
				Name = contactType.Name,
				DisplayOrder = contactType.DisplayOrder,
				IsActive = contactType.IsActive,
                ContactCount = contactType.Contacts.Count
			
			};

            return Ok(model);
        }

        // PUT api/ContactTypes/5
        public async Task<IHttpActionResult> PutContactType(int id, ContactType contactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactType.ContactTypeID)
            {
                return BadRequest();
            }

			await repository.UpdateAsync(contactType, contactType.ContactTypeID);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ContactTypes
        [ResponseType(typeof(ContactType))]
        public async Task<IHttpActionResult> PostContactType(ContactType contactType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			await repository.AddAsync(contactType);

            return CreatedAtRoute("DefaultApi", new { id = contactType.ContactTypeID }, contactType);
        }

        // DELETE api/ContactTypes/5
        [ResponseType(typeof(ContactType))]
        public async Task<IHttpActionResult> DeleteContactType(int id)
        {
			ContactType contactType = await repository.RetrieveAsync(id);
            if (contactType == null)
            {
                return NotFound();
            }

			await repository.DeleteAsync(contactType);

            return Ok(contactType);
        }

    }


}