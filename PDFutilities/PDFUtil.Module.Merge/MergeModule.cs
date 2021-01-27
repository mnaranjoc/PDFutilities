using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Regions;
using Unity;
using PDFUtil.Module.Merge.Views;

namespace PDFUtil.Module.Merge
{
    public class MergeModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public MergeModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry) { }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            /*this.regionManager.RegisterViewWithRegion("ContentRegion",
                                                       () => container.Resolve<MergeView>());*/
            var view = this.container.Resolve<MergeView>();
            this.regionManager.Regions["ContentRegion"].Add(view, "MergeView");
        }
    }
}
