using System.Collections.ObjectModel;
using System.Linq;
using AppVerse.Jewel.Contract;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.NavigationModule.ViewModels
{
    internal class NavigationShellViewModel : BaseViewModel, INavigation

    {
        private NavigationItem _selectedItem;
        private object _viewModel;
        private int _selectedItemIndex;

        public NavigationShellViewModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            NavigationItems = new ObservableCollection<NavigationItem>();
        }

        public NavigationItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != null) _selectedItem.IsSelected = false;
                _selectedItem = value;
                _selectedItem.IsSelected = true;
                ViewModel = _selectedItem.ViewModel;
                SelectedItemIndex = NavigationItems.IndexOf(_selectedItem);
            }
        }

        public int SelectedItemIndex
        {
            get => _selectedItemIndex;
            set =>  SetProperty(ref _selectedItemIndex , value);
        }

        public object ViewModel
        {
            get => _viewModel;
            set => SetProperty(ref _viewModel, value);
        }

        public ObservableCollection<NavigationItem> NavigationItems { get; }

        public void ActivateItem(NavigationItem navigationItem)
        {
            if (!NavigationItems.Contains(navigationItem)) NavigationItems.Add(navigationItem);
            navigationItem.IsSelected = true;
            SelectedItem = navigationItem;
            ViewModel = navigationItem.ViewModel;
        }

        public void ActivateItem(string navigationItemName)
        {
            var navItem = NavigationItems.First(item => item.Name == navigationItemName) ??
                          new NavigationItem {Name = navigationItemName};
            ActivateItem(navItem);
        }

        protected override void Initialize()
        {
        }
    }
}