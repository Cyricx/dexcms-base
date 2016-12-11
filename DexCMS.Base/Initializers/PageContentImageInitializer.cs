using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Extensions;
using System.Linq;
using DexCMS.Base.Initializers.Helpers;

namespace DexCMS.Base.Initializers
{
    class PageContentImageInitializer : DexCMSInitializer<IDexCMSBaseContext>
    {
        private ImagesReference Images { get; set; }
        private ContentsReference Contents { get; set; }

        public PageContentImageInitializer(IDexCMSBaseContext context) : base(context)
        {
            Images = new ImagesReference(context);
            Contents = new ContentsReference(context);
        }

        public override void Run()
        {
            Context.PageContentImages.AddIfNotExists(x => new { x.PageContentID, x.ImageID },
                new PageContentImage { PageContentID = Contents.LeftSidebar, ImageID = Images.ImageOne },
                new PageContentImage { PageContentID = Contents.LeftSidebar, ImageID = Images.ImageTwo },
                new PageContentImage { PageContentID = Contents.LeftSidebarOnly, ImageID = Images.ImageOne },
                new PageContentImage { PageContentID = Contents.LeftSidebarOnly, ImageID = Images.ImageTwo },
                new PageContentImage { PageContentID = Contents.OneColumn, ImageID = Images.ImageOne },
                new PageContentImage { PageContentID = Contents.OneColumn, ImageID = Images.ImageTwo },
                new PageContentImage { PageContentID = Contents.RightSidebar, ImageID = Images.ImageOne },
                new PageContentImage { PageContentID = Contents.RightSidebar, ImageID = Images.ImageTwo },
                new PageContentImage { PageContentID = Contents.RightSidebarOnly, ImageID = Images.ImageOne },
                new PageContentImage { PageContentID = Contents.RightSidebarOnly, ImageID = Images.ImageTwo },
                new PageContentImage { PageContentID = Contents.ThreeColumn, ImageID = Images.ImageOne },
                new PageContentImage { PageContentID = Contents.ThreeColumn, ImageID = Images.ImageTwo },
                new PageContentImage { PageContentID = Contents.TwoColumn, ImageID = Images.ImageOne },
                new PageContentImage { PageContentID = Contents.TwoColumn, ImageID = Images.ImageTwo }
            );
        }

    }

}
