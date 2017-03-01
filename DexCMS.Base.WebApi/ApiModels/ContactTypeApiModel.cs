using DexCMS.Base.Models;
using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;

namespace DexCMS.Base.WebApi.ApiModels
{

    public class ContactTypeApiModel:DexCMSViewModel<ContactTypeApiModel, ContactType>
    {
        public int ContactTypeID { get; set; }

        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("Contacts", "Count")]
        public int ContactCount { get; set; }

    }
}
