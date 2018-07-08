using System.Collections.Generic;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using AppVerse.Jewel.NavigationModule.ViewModels;
using Microsoft.Practices.Unity;
using Prism.Regions;
using Extensions = AppVerse.Jewel.Core.Extensions;

namespace AppVerse.Jewel.NavigationModule
{
    public class NavigatoinModule : BaseModule
    {
        private readonly List<string> _resources = new List<string>
        {
            "pack://application:,,,/AppVerse.Jewel.NavigationModule;component/MappingDictionary.xaml"
        };

        public NavigatoinModule(IUnityContainer unityContainer, IRegionManager regionManager) : base(unityContainer,
            regionManager)
        {
            _regionManager = regionManager;
        }

        private void Register()
        {
            _unityContainer.RegisterType<INavigation, NavigationShellViewModel>(
                new ContainerControlledLifetimeManager());
            _unityContainer.RegisterType<ITabDataModel, TabControlShellViewModel>();
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