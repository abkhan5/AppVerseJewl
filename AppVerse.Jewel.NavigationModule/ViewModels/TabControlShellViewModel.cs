using System.Collections.ObjectModel;
using System.Linq;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.NavigationModule.ViewModels
{
    public class TabControlShellViewModel : BaseViewModel, ITabDataModel
    {
        private TabItemDataModel _selectedTabItem;
        private int _selectedTabItemIndex;

        public TabControlShellViewModel(IUnityContainer unityContainer) : base(unityContainer)
        {
            TabItems= new ObservableCollection<TabItemDataModel>();
        }

        public ObservableCollection<TabItemDataModel> TabItems { get; }

        public TabItemDataModel SelectedTabItem
        {
            get => _selectedTabItem;
            set =>SetProperty(ref _selectedTabItem , value);
        }

        public int SelectedTabItemIndex
        {
            get => _selectedTabItemIndex;
            set => SetProperty(ref _selectedTabItemIndex , value);
        }

        public void AddTabItem<T>(TabItemDataModel<T> tabItem) where T : BaseViewModel
        {
            TabItems.Add(tabItem);
            SelectedTabItem = tabItem;
            SelectedTabItemIndex = TabItems.IndexOf(tabItem);
        }

        protected override void Initialize()
        {
        }
    }
}