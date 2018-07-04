using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;
using Prism.Commands;

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class DepthFileViewModel : BaseViewModel
    {
        private readonly IHorizonDataProvider _horizonDataProvider;

        private bool _isFileLoading;
        private string _loadStatus;

        public DepthFileViewModel(IUnityContainer unityContainer, IHorizonDataProvider horizonDataProvider) : base(
            unityContainer)
        {
            _horizonDataProvider = horizonDataProvider;
            LoadFilesCommand = new DelegateCommand(ExecuteLoadFilesCommand, CanExecuteLoadFilesCommand);
            _loadStatus = Constants.NotLoaded;
        }


        public DelegateCommand LoadFilesCommand { get; }

        private bool IsFileLoaded => Model?.FileLoadProgress != null && 
                                     Model.FileLoadProgress.Progress == Model.FileLoadProgress.Max;

        public DepthFile Model { get; set; }

        public string LoadStatus
        {
            get => _loadStatus;
            set => SetProperty(ref _loadStatus, value);
        }

        protected override void Initialize()
        {
        }

        private bool CanExecuteLoadFilesCommand()
        {
            return !IsFileLoaded && !_isFileLoading;
        }

        private async void ExecuteLoadFilesCommand()
        {
            _isFileLoading = true;
            LoadStatus = Constants.Loading;
            LoadFilesCommand.RaiseCanExecuteChanged();
            await _horizonDataProvider.GetDepth(Model);
            LoadStatus = Constants.Loaded;
            _isFileLoading = false;
            LoadFilesCommand.RaiseCanExecuteChanged();
        }
    }
}