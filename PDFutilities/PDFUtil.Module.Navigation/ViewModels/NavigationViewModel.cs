using Prism.Commands;
using Prism.Modularity;
using Prism.Regions;
using System.Windows.Input;
using Unity;

namespace PDFUtil.Module.Navigation.ViewModels
{
    public class NavigationViewModel
    {        
        public IRegionManager RegionManager { get; set; }
        public IUnityContainer UnityContainer { get; set; }
        public IModuleManager ModuleManager { get; set; }
        public DelegateCommand LoadMergeModuleCommand { get; private set; }
        public DelegateCommand LoadCountPagesModuleCommand { get; private set; }

        public NavigationViewModel(IRegionManager regionManager, IModuleManager moduleManager, IUnityContainer container)
        {
            this.RegionManager = regionManager;
            this.ModuleManager = moduleManager;
            this.UnityContainer = container;

            LoadMergeModuleCommand = new DelegateCommand(loadMergeModule);
            LoadCountPagesModuleCommand = new DelegateCommand(loadCountPagesModule);
        }

        private void loadMergeModule()
        {
            ModuleManager.LoadModule("MergeModule");
            var contentRegion = RegionManager.Regions["ContentRegion"];
            var newView = contentRegion.GetView("MergeView");
            contentRegion.Activate(newView);
        }

        private void loadCountPagesModule()
        {
            ModuleManager.LoadModule("CountPagesModule");
            var contentRegion = RegionManager.Regions["ContentRegion"];
            var newView = contentRegion.GetView("CountPagesView");
            contentRegion.Activate(newView);
        }
    }
}