using System;
using System.Windows;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Entities;
using MahApps.Metro.IconPacks;

namespace AppVerse.Jewel.Controls
{
    /// <summary>
    /// Interaction logic for AppImageControl.xaml
    /// </summary>
    public partial class AppImageControl 
    {
        public AppImageControl()
        {
            InitializeComponent();
        }


        // Using a DependencyProperty as the backing store for Data. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePathProperty = DependencyProperty.Register(
            "ImagePath",
            typeof(string),
            typeof(AppImageControl),
            new PropertyMetadata(ImageNamesConstant.DefaultImage, OnImageSourceChange));

        private static void OnImageSourceChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is AppImageControl appImage))
                return;

            var imagePath = e.NewValue as string;
            var names= Enum.GetNames(typeof(PackIconModernKind));

            foreach (var name in names)
            {
                var packImagePath = (PackIconModernKind)Enum.Parse(typeof(PackIconModernKind),name);
                var desc = packImagePath.GetDescription();
                if (desc != imagePath)
                    continue;
                appImage.AppImageCtrl.Kind = packImagePath; 
                break;
            }
        }

        public string ImagePath
        {
            get => (string)GetValue(ImagePathProperty);
            set => SetValue(ImagePathProperty, value);
        }

    }
}
