﻿#region Namespace

using System.Collections.ObjectModel;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;
using Prism.Commands;

#endregion

namespace AppVerse.Jewel.HorizonModule.ViewModels
{
    public class HorizonFilePikcerViewModel : BaseViewModel
    {
        private readonly IFilePicker _filePicker;
        private readonly IHorizonDataProvider _horizonDataProvider;

        private bool _isFileLoading;

        public HorizonFilePikcerViewModel(IUnityContainer unityContainer, IFilePicker filePicker,
            IHorizonDataProvider horizonDataProvider) : base(unityContainer)
        {
            _filePicker = filePicker;
            _horizonDataProvider = horizonDataProvider;
            HorizonFilePickerCommand = new DelegateCommand(ExecuteFilePickerCommand, CanExecuteFilePickerCommand);
            LoadFilesCommand = new DelegateCommand(ExecuteLoadFilesCommand, CanExecuteLoadFilesCommand);
            SelectedFiles = new ObservableCollection<DepthFile>();
            _isFileLoading = false;
        }

        public ObservableCollection<DepthFile> SelectedFiles { get; }

        public DelegateCommand HorizonFilePickerCommand { get; set; }
        public DelegateCommand LoadFilesCommand { get; set; }

        private bool CanExecuteLoadFilesCommand()
        {
            return !_filePicker.IsOpen && !_isFileLoading;
        }

        private async void ExecuteLoadFilesCommand()
        {
            _isFileLoading = true;
            foreach (var selectedFile in SelectedFiles)
                await _horizonDataProvider.GetDepth(selectedFile);

            _isFileLoading = false;
        }

        private bool CanExecuteFilePickerCommand()
        {
            return !_filePicker.IsOpen;
        }

        private void ExecuteFilePickerCommand()
        {
            SelectedFiles.Clear();
            var fileNames = _filePicker.GetFilePaths(true, FileFormat.Csv, FileFormat.Excel);
            foreach (var fileName in fileNames)
                SelectedFiles.Add(fileName);
        }

        protected override void Initialize()
        {
        }
    }
}