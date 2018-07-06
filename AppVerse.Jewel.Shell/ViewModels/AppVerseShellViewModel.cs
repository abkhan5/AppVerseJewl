using AppVerse.Jewel.Core.ApplicationBase;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.Shell.ViewModels
{
    public class AppverseShellViewModel : BaseViewModel
    {
        public AppverseShellViewModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            Title = "Jewel Suite";
        }

        protected override void Initialize()
        {
        }
    }
}