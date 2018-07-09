using System;
using System.Globalization;
using System.Windows.Data;
using AppVerse.Jewel.Entities;

namespace AppVerse.Jewel.Controls.Converter
{
    public class VolumeEnumToStringConverter : IValueConverter

    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is VolumeUnit volumeUnit)
            {
                return volumeUnit.GetDescription();
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}