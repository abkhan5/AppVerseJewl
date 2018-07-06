using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public class NavigationItem : DataModelBase
    {
        private bool _isSelected;

        public NavigationItem()
        {
            Name = "";
            ImagePath = "StarRegular";
        }
        public string Name { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected , value);
        }

        public string ImagePath { get; set; }

        public BaseViewModel ViewModel { get; set; }    
        
    }
}