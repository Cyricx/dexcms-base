using System;
using System.Collections.Generic;
using System.Linq;
using DexCMS.Base.Models;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class ContactApiModel
    {
        public int ContactID { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public string OtherSubject { get; set; }

        public DateTime SubmitDate { get; set; }

        public string Referrer { get; set; }

        public int ContactTypeID { get; set; }

        public string ContactTypeName { get; set; }

        public List<VisitedPage> VisitedPages { get; set; }

        public ContactApiModel() { }

        public ContactApiModel(Contact contact)
        {
            ContactID = contact.ContactID;
            Name = contact.Name;
            Phone = contact.Phone;
            Email = contact.Email;
            Message = contact.Message;
            OtherSubject = contact.OtherSubject;
            SubmitDate = contact.SubmitDate;
            Referrer = contact.Referrer;
            ContactTypeID = contact.ContactTypeID;
            ContactTypeName = contact.ContactType.Name;
            VisitedPages = contact.VisitedPages == null ? new List<VisitedPage>() : contact.VisitedPages.OrderBy(x => x.VisitOrder).ToList();
        }
    }

}
