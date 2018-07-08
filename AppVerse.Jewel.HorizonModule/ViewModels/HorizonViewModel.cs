#region Namespace
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;
#endregion

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class HorizonViewModel : BaseViewModel
    {
        #region Private Members
        private readonly INavigation _navigation;
        private readonly ITabDataModel _tabDataModel;
        private readonly TabItemDataModel<DepthFileContentViewModel> _depthFileContentTabItem;
        private DepthFile _volumeSource;
         
        #endregion

        #region Constructor

        public HorizonViewModel(IUnityContainer unityContainer, 
            INavigation navigation, 
            ITabDataModel tabDataModel,
            DepthFileContentViewModel depthFileContentViewModel) :
            base(unityContainer)
        {
            _navigation = navigation;
            _tabDataModel = tabDataModel;
            _depthFileContentTabItem= new TabItemDataModel<DepthFileContentViewModel> { Title = depthFileContentViewModel.Title,ToolTip = "Show content of file" , ViewModel = depthFileContentViewModel};
        }
        

        #endregion

        protected override void Initialize()
        {
            
        }

        public  void Initialize(DepthFile volumeSource)
        {
            _volumeSource = volumeSource;
            _depthFileContentTabItem.TabItemViewModel.Initialize(volumeSource);
            _tabDataModel.AddTabItem(_depthFileContentTabItem);
        }

        
        public BaseViewModel VolumeSource => _depthFileContentTabItem.TabItemViewModel;
    }
}
