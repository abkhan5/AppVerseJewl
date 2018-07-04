#region Namespace
using System;
using System.Collections.Generic;
using System.IO;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Entities;
using Microsoft.Win32;
#endregion
namespace AppVerse.Jewel.Controls
{
    public class HorizonFilePicker : IFilePicker
    {

        public bool IsOpen { get; set; }

        private OpenFileDialog _openFileDialog;

        public IEnumerable<DepthFile> GetFilePaths(bool multiSelect, params FileFormat[] fileFormats)
        {
            InitializeFileDialog(multiSelect, fileFormats);
            
            var fileNames = new List<DepthFile>();
            if (_openFileDialog.ShowDialog() == true)
            {
                foreach (var fileName in _openFileDialog.FileNames)
                {
                    
                    var name = Path.GetFileName(fileName);
                    var fileFormat = Path.GetExtension(name) == ".csv" ? FileFormat.Csv: FileFormat.Excel;
                    var file= new DepthFile(fileName,name, fileFormat);
                    fileNames.Add(file);
                }
                
            }
            IsOpen = false;
            return fileNames;
        }

        private void  InitializeFileDialog(bool multiselect, params FileFormat[] fileFormats)
        {
            _openFileDialog = new OpenFileDialog();
            IsOpen = true;
            var filters = "";
            _openFileDialog.Multiselect = multiselect;

            foreach (var fileFormat in fileFormats)
            {
                var desc = fileFormat.GetDescription();
                filters+= desc + "|";
            }
            filters = filters+FileFormat.All.GetDescription();
            _openFileDialog.Filter = filters;
            _openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}