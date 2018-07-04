using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core.ApplicationBase;
using Microsoft.Practices.Unity;
using Prism.Commands;

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
   public class DepthFileViewModel : BaseViewModel
   {
       private readonly IFilePicker _filePicker;
       private readonly IHorizonDataProvider _horizonDataProvider;

       private bool _isFileLoading;

       public DepthFileViewModel(IUnityContainer unityContainer, IHorizonDataProvider horizonDataProvider, IFilePicker filePicker) : base(unityContainer)
       {
           _horizonDataProvider = horizonDataProvider;
           _filePicker = filePicker;
       }


       public DelegateCommand LoadFilesCommand { get; set; }

        protected override void Initialize()
       {
        
       }
   }
}
