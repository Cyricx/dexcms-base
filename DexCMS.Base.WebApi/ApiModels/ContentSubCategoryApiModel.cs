﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.WebApi.ApiModels
{
    public class ContentSubCategoryApiModel
    {
        public int ContentSubCategoryID { get; set; }

        public string Name { get; set; }

        public string UrlSegment { get; set; }

        public bool IsActive { get; set; }

        public int ContentCount { get; set; }

    }
}
