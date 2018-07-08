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
        private readonly INavigation _navigation;
        private bool _isFileLoading;
        private string _fileStatus;
        private NavigationItem _navigationItem;
        private string _volume;

        public DepthFileViewModel(IUnityContainer unityContainer, IHorizonDataProvider horizonDataProvider,
            INavigation navigation) : base(
            unityContainer)
        {
            _horizonDataProvider = horizonDataProvider;
            _navigation = navigation;
            LoadFilesCommand = new DelegateCommand(ExecuteLoadFilesCommand, CanExecuteLoadFilesCommand);
            ShowOnCanvasCommand = new DelegateCommand(ExecuteShowOnCanvasCommand, CanShowOnCanvasCommand);
            _fileStatus = Constants.Attached;
        }


        public DelegateCommand LoadFilesCommand { get; }
        public DelegateCommand ShowOnCanvasCommand { get; }

        private bool IsFileLoaded => Model?.FileLoadProgress != null &&
                                     Model.FileLoadProgress.Progress == Model.FileLoadProgress.Max;

        public DepthFile Model { get; set; }

        public string FileStatus
        {
            get => _fileStatus;
            set => SetProperty(ref _fileStatus, value);
        }

        public string Volume
        {
            get => _volume;
            set => SetProperty(ref _volume, value);
        }

        public bool IsSelected { get; set; }

        private bool CanShowOnCanvasCommand()
        {
            return FileStatus == Constants.Loaded;
        }

        private void ExecuteShowOnCanvasCommand()
        {
            AddNavigationItem();
            _navigation.ActivateItem(_navigationItem);
        }

        private void AddNavigationItem()
        {
            if (_navigationItem != null)
                return;
            var volumeVm = _unityContainer.Resolve<HorizonViewModel>();
            volumeVm.Initialize(Model);
            _navigationItem = new NavigationItem
            {
                ImagePath = Model.Format.GetImageDescription(),
                Name = Model.FileName,
                IsSelected = true,
                ViewModel = volumeVm
            };
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
            FileStatus = Constants.Loading;
            LoadFilesCommand.RaiseCanExecuteChanged();
            await _horizonDataProvider.GetDepth(Model);
            FileStatus = Constants.Loaded;
            _isFileLoading = false;
            ShowOnCanvasCommand.RaiseCanExecuteChanged();
            Volume = "Show Volume";
            LoadFilesCommand.RaiseCanExecuteChanged();
        }
    }
}