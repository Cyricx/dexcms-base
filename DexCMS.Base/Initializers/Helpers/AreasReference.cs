using DexCMS.Base.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Base.Initializers.Helpers
{
    class AreasReference
    {
        public int Public { get; set; }
        public int ControlPanel { get; set; }

        public AreasReference(IDexCMSBaseContext Context)
        {
            Public = Context.ContentAreas.Where(x => x.Name == "Public").Select(x => x.ContentAreaID).Single();
            ControlPanel = Context.ContentAreas.Where(x => x.Name == "Control Panel").Select(x => x.ContentAreaID).Single();
        }
    }
}
