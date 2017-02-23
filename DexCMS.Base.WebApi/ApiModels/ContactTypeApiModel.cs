using DexCMS.Base.Models;

namespace DexCMS.Base.WebApi.ApiModels
{

    public class ContactTypeApiModel
    {
        public int ContactTypeID { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public int ContactCount { get; set; }

        public ContactTypeApiModel() { }

        public ContactTypeApiModel(ContactType contactType)
        {
            ContactTypeID = contactType.ContactTypeID;
            Name = contactType.Name;
            DisplayOrder = contactType.DisplayOrder;
            IsActive = contactType.IsActive;
            ContactCount = contactType.Contacts.Count;
        }
    }
}
