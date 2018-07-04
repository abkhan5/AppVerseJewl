#region Namespace

using AppVerse.Jewel.Core.ApplicationBase;
using Microsoft.Practices.Unity; 
#endregion

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
  public  class HorizonShellViewModel : BaseViewModel
    {
        public HorizonShellViewModel(IUnityContainer unityContainer, HorizonFilePikcerViewModel horizonFilePikcerViewModel) : base(unityContainer)
        {
            Horizon = horizonFilePikcerViewModel;
        }

        protected override void Initialize()
        {
            
        }

        public HorizonFilePikcerViewModel Horizon { get; set; }
    }
}
