using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DexCMS.Base.Enums;
using DexCMS.Base.Models;
using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class PageContentPermissionApiModel:DexCMSViewModel<PageContentPermissionApiModel, PageContentPermission>
    {
        public int PageContentID { get; set; }

        public int Id { get; set; }
    }
}