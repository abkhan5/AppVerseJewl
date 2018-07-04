using System.Management.Instrumentation;
using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public class Horizon : DataModelBase
    {
        private MeasurementUnits _units;

        public MeasurementUnits Units
        {
            get => _units;
            set => SetProperty(ref _units ,value);
        }

        public Horizon(int row, int column)
        {
            Depth = new int[row, column]; 
        }

        public int[,] Depth { get; }
    }
}