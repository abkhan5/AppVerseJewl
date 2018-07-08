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
            FilePikcerViewModel filePikcerViewModel, INavigation navigation) : base(unityContainer)
        {
            _navigation = navigation;
            Horizon = filePikcerViewModel;
        }

        public FilePikcerViewModel Horizon { get; set; }

        protected override void Initialize()
        {
        }
    }
}