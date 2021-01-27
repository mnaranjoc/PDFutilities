using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace PDFUtil.Module.Navigation.ViewModels
{
    public class NavigationViewModel
    {
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }

        public NavigationViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;
        }
    }
}