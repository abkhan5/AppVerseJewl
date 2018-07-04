using System.Collections.ObjectModel;
using AppVerse.Jewel.Entities;

namespace AppVerse.Jewel.Contract
{
    public interface INavigation
    {
        ObservableCollection<NavigationItem> NavigationItems { get; }

        void ActivateItem(NavigationItem navigationItem);
        void ActivateItem(string navigationItem);
    }
}