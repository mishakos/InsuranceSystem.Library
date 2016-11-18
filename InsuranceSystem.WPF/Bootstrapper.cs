using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using InsuranceSystem.Infrastructure;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using InsuranceSystem.BankModule;

namespace InsuranceSystem.WPF
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings mapping = base.ConfigureRegionAdapterMappings();
            mapping.RegisterMapping(typeof(StackPanel), Container.Resolve<StackPanelRegionAdapter>());
            return mapping;
        }

        protected override void ConfigureModuleCatalog()
        {
            Type bankModule = typeof(BankModuleModule);
            ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = bankModule.Name,
                ModuleType = bankModule.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }


        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }
    }
}
