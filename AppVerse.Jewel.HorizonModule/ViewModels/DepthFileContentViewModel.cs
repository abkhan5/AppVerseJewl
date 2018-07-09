using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class DepthFileContentViewModel : BaseViewModel
    {
        private HorizonFileContentViewModel _topHorizon;
        private HorizonFileContentViewModel _bottomHorizon;
        private DepthFileContentHeaderSectionViewModel _header;

        public DepthFileContentViewModel(IUnityContainer unityContainer, 
            HorizonFileContentViewModel topHorizon,
            DepthFileContentHeaderSectionViewModel header,
            HorizonFileContentViewModel bottomHorizon) : base(unityContainer)
        {
            _bottomHorizon = bottomHorizon;
            _topHorizon = topHorizon;
            _header = header;
        }

        protected override void Initialize()
        {
         
        }

        public DepthFileContentHeaderSectionViewModel Header
        {
            get => _header;
            set => SetProperty(ref _header , value);
        }

        public HorizonFileContentViewModel TopHorizon
        {
            get => _topHorizon;
            set => SetProperty(ref _topHorizon , value);
        }

        public HorizonFileContentViewModel BottomHorizon
        {
            get => _bottomHorizon;
            set => SetProperty(ref _bottomHorizon, value);
        }
        
     
        public void Initialize(DepthFile depth)
        {
            depth.Reservoir.CalculateVolume();
            _header.Initialize(depth);
            TopHorizon.Initialize(depth.Reservoir.TopHorizon.Depth);
            BottomHorizon.Initialize(depth.Reservoir.BottomHorizon.Depth);
          
          
        }
    }
}
