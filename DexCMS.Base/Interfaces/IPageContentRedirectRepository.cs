﻿using DexCMS.Base.Models;
using DexCMS.Core.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace DexCMS.Base.Interfaces
{
    public interface IPageContentRedirectRepository:IRepository<PageContentRedirect>
    {
        Task<PageContent> RetrieveAsync(string url);
    }
}
