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
            Depth = new int[row][];
            for (int i = 0; i < row; i++)
            {
                Depth [i]= new int[column];
            }
        }

        public int[][] Depth { get; }

        public string TotalVolume { get; set; }
    }
}