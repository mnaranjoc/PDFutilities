using PDFUtil.Module.CountPages.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace PDFUtil.Module.CountPages
{
    public class CountPagesModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public CountPagesModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry) { }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            var view = this.container.Resolve<CountPagesView>();
            this.regionManager.Regions["ContentRegion"].Add(view, "CountPagesView");
        }
    }
}