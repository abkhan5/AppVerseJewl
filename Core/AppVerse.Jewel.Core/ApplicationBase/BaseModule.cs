using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace AppVerse.Jewel.Core.ApplicationBase
{
    public abstract class BaseModule : IModule
    {
        protected const string ApplicationPath = "pack://application:,,,/";

    

        public void Initialize()
        {
            RegisterResources();
        }

        protected IRegionManager _regionManager;
        protected IUnityContainer _unityContainer;


        protected BaseModule(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
        }

        protected abstract void RegisterResources();
    }
}
