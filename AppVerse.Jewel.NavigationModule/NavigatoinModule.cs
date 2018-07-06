using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.NavigationModule.ViewModels;
using AppVerse.Jewel.NavigationModule.Views;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace AppVerse.Jewel.NavigationModule
{
   public  class NavigatoinModule : BaseModule
    {
        readonly List<string> _resources = new List<string>
        {
            "pack://application:,,,/AppVerse.Jewel.NavigationModule;component/MappingDictionary.xaml",
        };
        public NavigatoinModule(IUnityContainer unityContainer, IRegionManager regionManager) : base(unityContainer,
            regionManager)
        {
            _regionManager = regionManager;
        }

        private void Register()
        {
            _unityContainer.RegisterType<INavigation, NavigationShellViewModel>(new ContainerControlledLifetimeManager());
        }
        protected override void RegisterResources()
        {
            Extensions.RegisterResources(_resources);
            Register();
            _regionManager.Regions[RegionNames.ShellRegion]
                .Add(_unityContainer.Resolve<INavigation>(), ModuleNames.Navigation);
        }
    }
}
