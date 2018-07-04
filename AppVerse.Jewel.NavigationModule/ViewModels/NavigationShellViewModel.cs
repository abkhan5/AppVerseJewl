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

        public NavigationShellViewModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            NavigationItems=new ObservableCollection<NavigationItem>();
        }

        protected override void Initialize()
        {
        }

        public ObservableCollection<NavigationItem> NavigationItems { get; }

        public NavigationItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem.IsSelected = false;
                _selectedItem = value;
                _selectedItem.IsSelected = true;
            }

        }

        public void ActivateItem(NavigationItem navigationItem)
        {
            if (!NavigationItems.Contains(navigationItem))
            {
                NavigationItems.Add(navigationItem);
            }
            navigationItem.IsSelected = true;
        }

        public void ActivateItem(string navigationItemName)
        {
            var navItem = NavigationItems.First(item => item.Name == navigationItemName) ?? new NavigationItem{Name = navigationItemName};
            ActivateItem(navItem);
        }
    }
}