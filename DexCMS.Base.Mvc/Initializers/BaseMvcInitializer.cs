using DexCMS.Base.Contexts;
using DexCMS.Core.Globals;
using System;
using System.Collections.Generic;

namespace DexCMS.Base.Mvc.Initializers
{
    public class BaseMvcInitializer: DexCMSLibraryInitializer<IDexCMSBaseContext>
    {
        public BaseMvcInitializer(IDexCMSBaseContext context) : base(context) { }

        public override List<Type> Initializers
        {
            get
            {
                return new List<Type>();
            }
        }
    }
}
