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
        private DepthFileContentViewModel _depthFileContentViewModel;
        private DepthFile _volumeSource;
         
        #endregion

        #region Constructor

        public HorizonVolumeViewModel(IUnityContainer unityContainer, INavigation navigation, DepthFileContentViewModel depthFileContentViewModel) :
            base(unityContainer)
        {
            _navigation = navigation;
            _depthFileContentViewModel = depthFileContentViewModel;
        }

        #endregion

        protected override void Initialize()
        {
            
        }

        public  void Initialize(DepthFile volumeSource)
        {
            _volumeSource = volumeSource;
            _depthFileContentViewModel.Initialize( volumeSource);
        }


        public DepthFileContentViewModel VolumeSource
        {
            get => _depthFileContentViewModel;
            set =>  SetProperty(ref _depthFileContentViewModel, value);
        }
    }
}
