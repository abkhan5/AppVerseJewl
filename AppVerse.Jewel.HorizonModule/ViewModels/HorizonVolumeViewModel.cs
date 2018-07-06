#region Namespace
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;
#endregion

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class HorizonVolumeViewModel : BaseViewModel
    {
        #region Private Members
        private readonly INavigation _navigation;
        private DepthFile _volumeSource;
        #endregion

        #region Constructor

        public HorizonVolumeViewModel(IUnityContainer unityContainer, INavigation navigation) :
            base(unityContainer)
        {
            _navigation = navigation;

        }

        #endregion

        protected override void Initialize()
        {
            
        }

        public  void Initialize(DepthFile volumeSource)
        {
            VolumeSource = volumeSource;
        }


        public DepthFile VolumeSource
        {
            get => _volumeSource;
            set =>  SetProperty(ref _volumeSource , value);
        }
    }
}
