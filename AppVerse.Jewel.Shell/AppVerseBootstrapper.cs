using System.ComponentModel;
using System.Windows;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Controls;
using AppVerse.Jewel.Core;
using AppVerse.Jewel.Loaders;
using AppVerse.Jewel.Shell.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace AppVerse.Jewel.Shell
{
    internal class AppVerseBootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //  RegisterContainer();
            // Use the container to create an instance of the shell.
            var view = Container.TryResolve<AppverseShellView>();
            
            return view;
        }


        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterDependencies();
        }

        private void RegisterDependencies()
        {
            Container.RegisterType<IFileloader, CsvFileLoader>(ContainerNamesConstant.CsvLoader);
            Container.RegisterType<IFileloader, ExcelFileLoader>(ContainerNamesConstant.ExcelLoader);
            Container.RegisterType<IFilePicker, HorizonFilePicker>();
            Container.RegisterType<IHorizonDataProvider, HorizonDataProvider>();
        }


        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog) ModuleCatalog;
            catalog.AddModule(typeof(StatusModule.StatusModule));
            catalog.AddModule(typeof(NavigationModule.NavigatoinModule));
            catalog.AddModule(typeof(HorizonModule.HorizonModule));

        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window) Shell;
            Application.Current.MainWindow.Show();
        }
    }
}