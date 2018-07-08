using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class DepthFileContentViewModel : BaseViewModel
    {
        private TopHorizonViewModel _topHorizon;
        private BottomHorizonViewModel _bottomHorizon;

        public DepthFileContentViewModel(IUnityContainer unityContainer, TopHorizonViewModel topHorizon, BottomHorizonViewModel bottomHorizon) : base(unityContainer)
        {
            _bottomHorizon = bottomHorizon;
            _topHorizon = topHorizon;
        }

        protected override void Initialize()
        {
         
        }

        
        public string ImagePath { get; set; }
        public string FileName { get; set; }

        public TopHorizonViewModel TopHorizon
        {
            get => _topHorizon;
            set => SetProperty(ref _topHorizon , value);
        }

        public BottomHorizonViewModel BottomHorizon
        {
            get => _bottomHorizon;
            set => SetProperty(ref _bottomHorizon, value);
        }
        
        public string TotalVolume { get; set; }

        public void Initialize(DepthFile depth)
        {
            TopHorizon.Initialize(depth);
            BottomHorizon.Initialize(depth);
            ImagePath = depth.Format.GetImageDescription();
            FileName = depth.FileName;
            TotalVolume = depth.Volume;
        }
    }
}
