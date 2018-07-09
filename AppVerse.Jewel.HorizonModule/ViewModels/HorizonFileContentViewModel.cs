using System.Collections.Generic;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class HorizonFileContentViewModel : BaseViewModel
    {
        public HorizonFileContentViewModel(IUnityContainer unityContainer) : base(unityContainer)
        {

        }

        protected override void Initialize()
        {
            Depth = new List<List<LengthUnitSystem>>();
        }
        public List<List<LengthUnitSystem>> Depth { get; set; }

        public void Initialize(LengthUnitSystem[][] depthChart)
        {
            for (int row = 0; row < 26; row++)
            {
                var rowList = new List<LengthUnitSystem>();
                for (int column = 0; column < 16; column++)
                    rowList.Add(depthChart[column][row]);
                Depth.Add(rowList);
            }
        }
    }
}
