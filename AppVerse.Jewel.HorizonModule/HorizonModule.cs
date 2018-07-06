#region Namespace

using System.Collections.Generic;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.HorizonModule.ViewModels;
using Microsoft.Practices.Unity;
using Prism.Regions;

#endregion

namespace AppVerse.Jewel.HorizonModule
{
    public class HorizonModule : BaseModule
    {
        private readonly List<string> _resources = new List<string>
        {
            "pack://application:,,,/AppVerse.Jewel.HorizonModule;component/MappingDictionary.xaml"
        };

        public HorizonModule(IUnityContainer unityContainer, IRegionManager regionManager) : base(unityContainer,
            regionManager)
        {
            _regionManager = regionManager;
        }

        protected override void RegisterResources()
        {
            Extensions.RegisterResources(_resources);
            var vm = _unityContainer.Resolve<HorizonShellViewModel>();
        }
    }
}