using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public  class DepthFileContentViewModel : BaseViewModel
    {
        public DepthFileContentViewModel(IUnityContainer unityContainer) : base(unityContainer)
        {
        }

        protected override void Initialize()
        {
            
        }

        public DepthFile DepthFile{ get; set; }

        public string ImagePath { get; set; }

        public int[][] Depth { get; set; }

        public string TotalVolume { get; set; }

        public void Initialize(DepthFile depth)
        {
            DepthFile = depth;
            ImagePath = depth.Format.GetImageDescription();
            Depth = depth.TopHorizon.Depth;
            TotalVolume = depth.TopHorizon.TotalVolume;
        }
    }
}
