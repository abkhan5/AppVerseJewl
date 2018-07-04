using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.StatusModule.ViewModels;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace AppVerse.Jewel.StatusModule
{
    
    public class StatusModule : BaseModule
    {
        readonly List<string> _resources = new List<string>
        {
            "pack://application:,,,/AppVerse.Jewel.StatusModule;component/MappingDictionary.xaml",
        };
        public StatusModule(IUnityContainer unityContainer, IRegionManager regionManager) : base(unityContainer,
            regionManager)
        {
            _regionManager = regionManager;
        }

        private void Register()
        {
            _unityContainer.RegisterType<IStatus, StatusViewModel>(new ContainerControlledLifetimeManager());
        }
        protected override void RegisterResources()
        {
            Register();
            _regionManager.Regions[RegionNames.StatusRegion].Add(_unityContainer.Resolve<IStatus>(),
                ModuleNames.StatusModule);
            Extensions.RegisterResources(_resources);

        }
    }
}
