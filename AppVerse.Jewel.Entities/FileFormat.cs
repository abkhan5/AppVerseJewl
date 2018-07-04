using System.ComponentModel;

namespace AppVerse.Jewel.Entities
{
    public enum FileFormat
    {
        [Description("CSV (*.csv)|*.csv")]
        Csv,
        [Description("Excel (*.xls;*.xlsx)|*.xls;*.xlsx")]
        Excel,
        [Description("All files (*.*)|*.*")]
        All
    }
}