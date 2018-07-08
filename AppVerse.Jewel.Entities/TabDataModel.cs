using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public interface ITabDataModel
    {
        void AddTabItem(TabItemDataModel tabItem);
    }


    public class TabItemDataModel : DataModelBase
    {
        public string Title { get; set; }

        public string ToolTip { get; set; }

        public BaseViewModel ViewModel { get; set; }
    }
}