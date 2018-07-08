using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
  public   class DepthFileContentHeaderSectionViewModel : BaseViewModel
  {
      public DepthFileContentHeaderSectionViewModel(IUnityContainer unityContainer) : base(unityContainer)
      {
      }

      protected override void Initialize()
      {
          
      }

      private DepthFile _depth;
      protected void Initialize(DepthFile depth)
      {
          _depth = depth;
      }
    }
}
