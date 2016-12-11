using DexCMS.Base.Contexts;
using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Extensions;
using DexCMS.Base.Initializers.Helpers;

namespace DexCMS.Base.Initializers
{
    class ContentBlockInitializer: DexCMSInitializer<IDexCMSBaseContext>
    {
        private ContentsReference Contents { get; set; }

        public ContentBlockInitializer(IDexCMSBaseContext context) : base(context)
        {
            Contents = new ContentsReference(context);
        }

        public override void Run()
        {
            Context.ContentBlocks.AddIfNotExists(x => x.BlockTitle,
                new ContentBlock { BlockTitle = "LS Block One", PageContentID = Contents.LeftSidebar, DisplayOrder = 1, ShowTitle = true, BlockBody = MakeBody() },
                new ContentBlock { BlockTitle = "LS Block Two", PageContentID = Contents.LeftSidebar, DisplayOrder = 2, ShowTitle = true, BlockBody = MakeAlternateBody() },
                new ContentBlock { BlockTitle = "LSO Block One", PageContentID = Contents.LeftSidebarOnly, DisplayOrder = 1, ShowTitle = true, BlockBody = MakeBody() },
                new ContentBlock { BlockTitle = "LSO Block Two", PageContentID = Contents.LeftSidebarOnly, DisplayOrder = 2, ShowTitle = true, BlockBody = MakeAlternateBody() },
                new ContentBlock { BlockTitle = "RS Block One", PageContentID = Contents.RightSidebar, DisplayOrder = 1, ShowTitle = true, BlockBody = MakeBody() },
                new ContentBlock { BlockTitle = "RS Block Two", PageContentID = Contents.RightSidebar, DisplayOrder = 2, ShowTitle = true, BlockBody = MakeAlternateBody() },
                new ContentBlock { BlockTitle = "RSO Block One", PageContentID = Contents.RightSidebarOnly, DisplayOrder = 1, ShowTitle = true, BlockBody = MakeBody() },
                new ContentBlock { BlockTitle = "RSO Block Two", PageContentID = Contents.RightSidebarOnly, DisplayOrder = 2, ShowTitle = true, BlockBody = MakeAlternateBody() },
                new ContentBlock { BlockTitle = "1C Block One", PageContentID = Contents.OneColumn, DisplayOrder = 1, ShowTitle = true, BlockBody = MakeBody() },
                new ContentBlock { BlockTitle = "1C Block Two", PageContentID = Contents.OneColumn, DisplayOrder = 2, ShowTitle = true, BlockBody = MakeAlternateBody() },
                new ContentBlock { BlockTitle = "2C Block One", PageContentID = Contents.TwoColumn, DisplayOrder = 1, ShowTitle = true, BlockBody = MakeBody() },
                new ContentBlock { BlockTitle = "2C Block Two", PageContentID = Contents.TwoColumn, DisplayOrder = 2, ShowTitle = true, BlockBody = MakeAlternateBody() },
                new ContentBlock { BlockTitle = "3C Block One", PageContentID = Contents.ThreeColumn, DisplayOrder = 1, ShowTitle = true, BlockBody = MakeBody() },
                new ContentBlock { BlockTitle = "3C Block Two", PageContentID = Contents.ThreeColumn, DisplayOrder = 2, ShowTitle = true, BlockBody = MakeAlternateBody() }
            );
        }

        private string MakeBody()
        {
            return @"<p>Iguanacolossus Ningyuansaurus Asylosaurus Dicraeosaurus Mirischia Poekilopleuron Kileskus Walkeria Rahona Atlascopcosaurus Jintasaurus Lagerpeton Gobititan Hylosaurus Elachistosuchus Kuszholia Scansoriopteryx Protognathosaurus Cedarosaurus Balaur Haplocheirus Priodontognathus Geranosaurus Cristatusaurus Europasaurus Cryptosaurus Medusaceratops Ammosaurus Saurophagus Gigantoscelus.</p><p>Enigmosaurus Bainoceratops Hudiesaurus Chinshakiangosaurus Nyasasaurus Kritosaurus Andesaurus Palaeoctonus Chubutisaurus Cerasinops Avalonia Pachycephalosaurus Graciliceratops Shidaisaurus Callovosaurus Sonidosaurus Acrotholus Hecatasaurus Labrosaurus Lusitanosaurus Valdosaurus Aggiosaurus Uberabatitan Denversaurus Eupodosaurus Charonosaurus Cathartesaura Macrogryphosaurus Berberosaurus Texacephale.</p><p>Hypselosaurus Aniksosaurus Campylodoniscus Sarcosaurus Pentaceratops Datousaurus Chubutisaurus Notohypsilophodon Platyceratops Leshansaurus Leyesaurus Eucercosaurus Rahona Stormbergia Tazoudasaurus Deuterosaurus Walkeria Falcarius Shuangmiaosaurus Pukyongosaurus Saltopus Alwalkeria Dromaeosauroides Kelmayisaurus Ampelosaurus Nothronychus Segisaurus Caulodon Kentrurosaurus Saltopus.</p>";
        }
        private string MakeAlternateBody()
        {
            return @"<p>Haxx0r ipsum loop boolean bin fatal hexadecimal ip grep Dennis Ritchie while bytes perl alloc. Machine code /dev/null leapfrog ban L0phtCrack worm brute force ack false race condition mainframe bang sudo emacs ctl-c endif suitably small values. Fork cookie pwned syn mailbomb wabbit Starcraft protocol mutex todo regex long.</p><p>While bytes less gc pragma Leslie Lamport injection private suitably small values default exception. Bin long break fork hack the mainframe flood public mega ddos ban grep try catch port finally packet sniffer eaten by a grue stack new frack. Ascii big-endian Trojan horse James T. Kirk script kiddies segfault regex bin sql null continue.</p><p>Char then printf dereference ifdef throw eof stack trace warez. Ip Dennis Ritchie bar char mega gurfle cookie piggyback foad private hexadecimal. Hello world January 1, 1970 socket eaten by a grue concurrently.</p>";
        }
    }
}
