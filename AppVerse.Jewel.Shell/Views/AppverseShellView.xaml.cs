using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AppVerse.Jewel.Core.Cultures;
using AppVerse.Jewel.Shell.ViewModels;

namespace AppVerse.Jewel.Shell.Views
{
    /// <summary>
    /// Interaction logic for AppverseShellView.xaml
    /// </summary>
    public partial class AppverseShellView 
    {
        public AppverseShellView()
        {
            InitializeComponent();
            CultureResources.ChangeCulture(Properties.Settings.Default.DefaultCulture);
            ShowTitleBar = true;
        }
    }
}
