using DexCMS.Base.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.Initializers.Helpers
{
    class ImagesReference
    {
        public int ImageOne { get; set; }
        public int ImageTwo { get; set; }

        public ImagesReference(IDexCMSBaseContext Context)
        {
            ImageOne = Context.Images.Where(x => x.Alt == "Gaea Retreat").Select(x => x.ImageID).Single();
            ImageTwo = Context.Images.Where(x => x.Alt == "Lawrence Busker").Select(x => x.ImageID).Single();

        }
    }
}
