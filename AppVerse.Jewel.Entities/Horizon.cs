using System.Collections;
using System.Management.Instrumentation;
using AppVerse.Jewel.Core.ApplicationBase;

namespace AppVerse.Jewel.Entities
{
    public class Horizon : DataModelBase
    {

        public Horizon(int row, int column)
        {
            Depth = new LengthUnitSystem[row][];
            for (int i = 0; i < row; i++)
            {
                Depth[i] = new LengthUnitSystem[column];
            }
        }

        public LengthUnitSystem[][] Depth { get; }

        public string TotalVolume { get; set; }
    }
}