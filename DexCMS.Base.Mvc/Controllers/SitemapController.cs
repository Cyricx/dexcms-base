using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Infrastructure;
using DexCMS.Base.Mvc.Extensions;

namespace DexCMS.Base.Mvc.Controllers
{
    public class SitemapController : Controller
    {
        private IPageContentRepository repository;

        public SitemapController(IPageContentRepository repo)
        {
            repository = repo;
        }

        //
        // GET: /Sitemap/
        public ActionResult Index()
        {
            var sItems = new List<SitemapItem>();

            foreach (var x in repository.Items.Where(x => x.AddToSitemap && x.IsDisabled != true).OrderBy(x => x.PageContentID).ToList())
            {
                sItems.Add(new SitemapItem(
                   new Uri(HttpContext.Request.Url, UrlBuilder.BuildUrl(x).Substring(1)).ToString()
                    ,
                    x.LastModified, x.ChangeFrequency, x.Priority
                    ));
            }

            return new SitemapResult(sItems);

        }
	}
}