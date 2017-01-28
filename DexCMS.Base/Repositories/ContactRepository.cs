using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DexCMS.Base.Models;
using DexCMS.Core.Contexts;
using DexCMS.Base.Contexts;
using DexCMS.Core.Repositories;
using DexCMS.Base.Interfaces;

namespace DexCMS.Base.Repositories
{
    public class ContactRepository : AbstractRepository<Contact>, IContactRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSBaseContext _ctx { get; set; }

        public ContactRepository(IDexCMSBaseContext ctx)
        {
            _ctx = ctx;
        }

        public override Task<int> DeleteAsync(Contact item)
        {
            if (item.VisitedPages.Count > 0)
            {
                _ctx.VisitedPages.RemoveRange(item.VisitedPages);
            }

            return base.DeleteAsync(item);
        }

        public override Task<int> AddAsync(Contact item)
        {
            if (item.VisitedUrlsToAdd != null && item.VisitedUrlsToAdd.Count > 0)
            {
                ProcessVisitedUrls(item);
            }

            return base.AddAsync(item);
        }

        public override Task<int> UpdateAsync(Contact item, int id)
        {
            if (item.VisitedUrlsToAdd != null && item.VisitedUrlsToAdd.Count > 0)
            {
                ProcessVisitedUrls(item);
            }

            if (item.VisitsToRemove != null && item.VisitsToRemove.Length > 0)
            {
                _ctx.VisitedPages.RemoveRange(item.VisitedPages.Where(x => item.VisitsToRemove.Contains(x.VisitedPageID)));
            }
            return base.UpdateAsync(item, id);
        }

        private static void ProcessVisitedUrls(Contact item)
        {
            item.VisitedPages = new List<VisitedPage>();

            int visitOrder = 1;
            foreach (string page in item.VisitedUrlsToAdd)
            {
                VisitedPage visit = new VisitedPage()
                {
                    URL = page,
                    VisitOrder = visitOrder
                };
                item.VisitedPages.Add(visit);
                visitOrder++;
            }
        }
    }
}
