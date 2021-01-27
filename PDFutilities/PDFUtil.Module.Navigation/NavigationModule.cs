using PDFUtil.Module.Navigation.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace PDFUtil.Module.Navigation
{
    public class NavigationModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
        public NavigationModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry) { }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            this.regionManager.RegisterViewWithRegion("NavigationRegion",
                                                        () => this.container.Resolve<NavigationBar>());
        }
    }
}