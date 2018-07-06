#region Namespace

using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core.ApplicationBase;
using Microsoft.Practices.Unity;

#endregion

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class HorizonShellViewModel : BaseViewModel
    {
        private readonly INavigation _navigation;

        public HorizonShellViewModel(IUnityContainer unityContainer,
            HorizonFilePikcerViewModel horizonFilePikcerViewModel, INavigation navigation) : base(unityContainer)
        {
            _navigation = navigation;
            Horizon = horizonFilePikcerViewModel;
        }

        public HorizonFilePikcerViewModel Horizon { get; set; }

        protected override void Initialize()
        {
        }
    }
}