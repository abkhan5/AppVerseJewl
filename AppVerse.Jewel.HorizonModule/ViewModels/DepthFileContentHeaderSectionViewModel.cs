using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class DepthFileContentHeaderSectionViewModel : BaseViewModel
    {
        public DepthFileContentHeaderSectionViewModel(IUnityContainer unityContainer) : base(unityContainer)
        {
        }

        protected override void Initialize()
        {

        }

        public void Initialize(DepthFile depth)
        {
            ImagePath = depth.Format.GetImageDescription();
            FileName = depth.FileName;
            TotalVolume = depth.Reservoir.Volume;
        }

        public VolumeUnitSystem TotalVolume { get; set; }

        public string ImagePath { get; set; }
        public string FileName { get; set; }



    }
}
