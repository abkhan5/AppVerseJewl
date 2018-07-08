using System.Collections.ObjectModel;
using AppVerse.Jewel.Core.ApplicationBase;
using AppVerse.Jewel.Entities;
using Microsoft.Practices.Unity;

namespace AppVerse.Jewel.NavigationModule.ViewModels
{
    public class TabControlShellViewModel : BaseViewModel, ITabDataModel
    {
        private TabItemDataModel _selectedTabItem;

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

        public void AddTabItem(TabItemDataModel tabItem)
        {
            TabItems.Add(tabItem);
        }

        protected override void Initialize()
        {
        }
    }
}