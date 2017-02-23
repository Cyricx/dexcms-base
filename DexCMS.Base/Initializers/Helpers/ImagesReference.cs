using DexCMS.Base.Contexts;
using System.Linq;

namespace DexCMS.Base.Initializers.Helpers
{
    public class ImagesReference
    {
        public int ImageOne { get; set; }
        public int ImageTwo { get; set; }

        public ImagesReference(IDexCMSBaseContext Context)
        {
            ImageOne = Context.Images.Where(x => x.Alt == "Gaea Retreat").Select(x => x.ImageID).SingleOrDefault();
            ImageTwo = Context.Images.Where(x => x.Alt == "Lawrence Busker").Select(x => x.ImageID).SingleOrDefault();

        }
    }
}
