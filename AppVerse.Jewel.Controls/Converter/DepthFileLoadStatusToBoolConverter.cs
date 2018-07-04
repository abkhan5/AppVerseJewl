using System;
using System.Globalization;
using System.Windows.Data;
using AppVerse.Jewel.Entities;

namespace AppVerse.Jewel.Controls.Converter
{
    public class DepthFileLoadStatusToBoolConverter : IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DepthFile depthFile)
                return depthFile.FileLoadProgress.Progress == depthFile.FileLoadProgress.Max;

            if (value is AppProgress prog)
                return prog.Progress == prog.Max;

            return value!=null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}