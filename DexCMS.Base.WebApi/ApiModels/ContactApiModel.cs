using System;
using System.Collections.Generic;
using System.Linq;
using DexCMS.Base.Models;
using DexCMS.Core.Globals;
using DexCMS.Core.Attributes;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class ContactApiModel:DexCMSViewModel<ContactApiModel, Contact>
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

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("ContactType", "Name")]
        public string ContactTypeName { get; set; }

        [NestedClassMapping(typeof(VisitedPageApiModel), true)]
        public List<VisitedPageApiModel> VisitedPages { get; set; }

    }

}
