﻿using DexCMS.Base.Interfaces;
using DexCMS.Base.Models;
using DexCMS.Core.Contexts;
using DexCMS.Core.Repositories;
namespace DexCMS.Base.Repositories
{
    public class LayoutTypeRepository : AbstractRepository<LayoutType>, ILayoutTypeRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public LayoutTypeRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }
    }
}