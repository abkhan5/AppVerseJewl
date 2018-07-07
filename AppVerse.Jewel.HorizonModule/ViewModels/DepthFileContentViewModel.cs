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
            Depth= new List<List<LengthUnitSystem>>();
        }

        public DepthFile DepthFile{ get; set; }

        public string ImagePath { get; set; }
        public string FileName { get; set; }
        public List<List<LengthUnitSystem>> Depth { get; set; }

        public string TotalVolume { get; set; }

        public void Initialize(DepthFile depth)
        {
            DepthFile = depth;
            ImagePath = depth.Format.GetImageDescription();
            var depthChart = depth.TopHorizon.Depth;
            FileName = depth.FileName;
            TotalVolume = depth.Volume;
            for (int row = 0; row < 16; row++)
            {
                var rowList= new List<LengthUnitSystem>();
                for (int column = 0; column < 26; column++)
                    rowList.Add(depthChart[row][column]);
                Depth.Add(rowList);
            }
        }
    }
}
