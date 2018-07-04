using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public class AppProgress: DataModelBase
    {
        private string _progressOf;
        private int _progress;
        public const string ProgressConstant = "Progress";
        public string ProgressOf
        {
            get => _progressOf;
            set => SetProperty(ref _progressOf , value);
        }

        public int Progress
        {
            get => _progress;
            set => SetProperty(ref _progress , value);
        }

        public int Max { get; set; }
    }
}