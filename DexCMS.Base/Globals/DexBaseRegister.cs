using DexCMS.Base.Contexts;
using DexCMS.Base.Interfaces;
using DexCMS.Base.Repositories;
using Ninject;

namespace DexCMS.Base.Globals
{
    public static class BaseRegister<T> where T : IDexCMSBaseContext
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IContactRepository>().To<ContactRepository>();
            kernel.Bind<IContactTypeRepository>().To<ContactTypeRepository>();
            kernel.Bind<IContentAreaRepository>().To<ContentAreaRepository>();
            kernel.Bind<IContentBlockRepository>().To<ContentBlockRepository>();
            kernel.Bind<IContentCategoryRepository>().To<ContentCategoryRepository>();
            kernel.Bind<IContentSubCategoryRepository>().To<ContentSubCategoryRepository>();
            kernel.Bind<ILayoutTypeRepository>().To<LayoutTypeRepository>();
            kernel.Bind<IPageContentImageRepository>().To<PageContentImageRepository>();
            kernel.Bind<IPageContentRedirectRepository>().To<PageContentRedirectRepository>();
            kernel.Bind<IPageContentRepository>().To<PageContentRepository>();
            kernel.Bind<IPageTypeRepository>().To<PageTypeRepository>();
            kernel.Bind<IDexCMSBaseContext>().To<T>();
        }
    }

}
