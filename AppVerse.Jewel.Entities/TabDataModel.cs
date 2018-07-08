using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public interface ITabDataModel
    {
        void AddTabItem<T>(TabItemDataModel<T> tabItem) where T : BaseViewModel;
    }


    public class TabItemDataModel : DataModelBase
    {
        public string Title { get; set; }

        public string ToolTip { get; set; }
        public BaseViewModel ViewModel { get; set; }
    }

    public class TabItemDataModel<T> : TabItemDataModel where T : BaseViewModel
    {
        public  T TabItemViewModel
        {
            get => ViewModel as T;
            set => ViewModel = value;
        }
    }
}