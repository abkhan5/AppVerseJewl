using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.StatusModule.ViewModels
{
    public  class ProgressViewModel: BaseViewModel
    {
        public ProgressViewModel(IUnityContainer unityContainer, AppProgress statusOf) : base(unityContainer)
        {
            StatusOf = statusOf;
        }

        protected override void Initialize()
        {

        }

        public AppProgress StatusOf { get; set; }
    }
}
