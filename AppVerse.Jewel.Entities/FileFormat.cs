using System.ComponentModel;
using AppVerse.Jewel.Core;

namespace AppVerse.Jewel.Entities
{
    public enum FileFormat
    {
        [ImagePath(ImageNamesConstant.Csv)]
        [Description(Constants.CsvExtension)]
        Csv,
        [ImagePath(ImageNamesConstant.Excel)]
        [Description(Constants.ExcelExtension)]
        Excel,

        [ImagePath(ImageNamesConstant.Csv)]
        [Description(Constants.AllFileExtension)]
        All
    }
}