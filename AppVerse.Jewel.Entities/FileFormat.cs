using System.ComponentModel;
using AppVerse.Jewel.Core;

namespace AppVerse.Jewel.Entities
{
    public enum FileFormat
    {
        [ImagePathAttribute(ImageNamesConstant.Csv)]
        [Description(Constants.CsvExtension)]
        Csv,
        [ImagePathAttribute(ImageNamesConstant.Excel)]
        [Description(Constants.ExcelExtension)]
        Excel,

        [ImagePathAttribute(ImageNamesConstant.Csv)]
        [Description(Constants.AllFileExtension)]
        All
    }
}