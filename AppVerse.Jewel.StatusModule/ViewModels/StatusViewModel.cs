using System;
using System.Collections.Generic;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.StatusModule.ViewModels
{
    public class StatusViewModel:   BaseViewModel,IStatus
    {
        private readonly Dictionary<string, ProgressViewModel> _appProgresses;
        private BaseViewModel _statusControl;


        public StatusViewModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            _appProgresses=new Dictionary<string, ProgressViewModel>();
        }

        protected override void Initialize()
        {
            
        }

        public BaseViewModel StatusControl
        {
            get => _statusControl;
            set => SetProperty(ref _statusControl , value);
        }


        public void TrackStatus(AppProgress statusOf)
        {
            if (_appProgresses.ContainsKey(statusOf.ProgressOf))
            {
                return;
            }

            statusOf.PropertyChanged += StatusOf_PropertyChanged;
            var vm = new ProgressViewModel(this._unityContainer, statusOf);
            StatusControl = vm;
            _appProgresses[statusOf.ProgressOf] = vm;
        }

        private void StatusOf_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != AppProgress.ProgressConstant) return;
            var statusOf = sender as AppProgress;
            if (StatusControl is ProgressViewModel progressControl )
            {
               
            }
            else
            {
                StatusControl = _appProgresses[statusOf.ProgressOf];
            }
        }
    }
}