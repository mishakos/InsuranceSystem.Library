using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceSystem.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace InsuranceSystem.BankModule
{
    public class BankModuleModule : IModule
    {
        IUnityContainer _unityContainer;
        IRegionManager _regionManager;

        public BankModuleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _unityContainer = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            IRegion region = _regionManager.Regions[RegionNames.ToolbarRegion];
            region.Add(_unityContainer.Resolve<ToolbarView>());

            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(ContentView));
        }
    }
}
