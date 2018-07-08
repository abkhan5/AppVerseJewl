#region Namespace

using System.Collections.ObjectModel;
using System.Linq;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;
using Prism.Commands;

#endregion

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class FilePikcerViewModel : BaseViewModel
    {
        private readonly IFilePicker _filePicker;
        private readonly INavigation _navigation;

        private bool _isFileLoading;

        public FilePikcerViewModel(
            IUnityContainer unityContainer, 
            IFilePicker filePicker,
            INavigation navigation
            ) : base(unityContainer)
        {
            _filePicker = filePicker;
            _navigation = navigation;
            HorizonFilePickerCommand = new DelegateCommand(ExecuteFilePickerCommand, CanExecuteFilePickerCommand);
            LoadFilesCommand = new DelegateCommand(ExecuteLoadFilesCommand, CanExecuteLoadFilesCommand);
            SelectedFiles = new ObservableCollection<DepthFileViewModel>();
            _isFileLoading = false;
            Initialize();
        }

        public ObservableCollection<DepthFileViewModel> SelectedFiles { get; }

        public DelegateCommand HorizonFilePickerCommand { get; set; }
        public DelegateCommand LoadFilesCommand { get; set; }

        private bool CanExecuteLoadFilesCommand()
        {
            return !_filePicker.IsOpen && !_isFileLoading&& SelectedFiles.Count>0;
        }

        private void ExecuteLoadFilesCommand()
        {
            _isFileLoading = true;
            foreach (var selectedFile in SelectedFiles)
                selectedFile.LoadFilesCommand.Execute();
            _isFileLoading = false;
        }

        private bool CanExecuteFilePickerCommand()
        {
            return !_filePicker.IsOpen;
        }

        private void ExecuteFilePickerCommand()
        {
            var files = _filePicker.GetFilePaths(true, FileFormat.Csv, FileFormat.Excel).ToList();

            if (!files.Any())
                return;

            
            foreach (var fileName in files)
            {
                if (SelectedFiles.Any(selectedFile => selectedFile.Model.FileName==fileName.FileName))
                continue;    
                
                var depthVm = _unityContainer.Resolve<DepthFileViewModel>();
                depthVm.Model = fileName;
                SelectedFiles.Add(depthVm);
            }
            LoadFilesCommand.RaiseCanExecuteChanged();
        }

        protected override void Initialize()
        {
            _navigation?.ActivateItem(
                new NavigationItem
            {
                ImagePath = ImageNamesConstant.FileLoader,
                Name = ImageNamesConstant.FileLoader,
                IsSelected = true,
                ViewModel = this
            });
        }
    }
}