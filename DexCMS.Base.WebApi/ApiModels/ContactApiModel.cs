using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }

}
