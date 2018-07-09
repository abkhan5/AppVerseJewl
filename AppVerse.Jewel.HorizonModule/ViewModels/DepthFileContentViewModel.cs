using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class DepthFileContentViewModel : BaseViewModel
    {
        private HorizonFileContentViewModel _topHorizon;
        private HorizonFileContentViewModel _bottomHorizon;

        public DepthFileContentViewModel(IUnityContainer unityContainer, HorizonFileContentViewModel topHorizon, HorizonFileContentViewModel bottomHorizon) : base(unityContainer)
        {
            _bottomHorizon = bottomHorizon;
            _topHorizon = topHorizon;
        }

        protected override void Initialize()
        {
         
        }

        
        public string ImagePath { get; set; }
        public string FileName { get; set; }

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
        
        public string TotalVolume { get; set; }

        public void Initialize(DepthFile depth)
        {
            depth.Reservoir.CalculateVolume();
            TopHorizon.Initialize(depth.Reservoir.TopHorizon.Depth);
            BottomHorizon.Initialize(depth.Reservoir.BottomHorizon.Depth);
            ImagePath = depth.Format.GetImageDescription();
            FileName = depth.FileName;
            TotalVolume = depth.Volume;
        }
    }
}
