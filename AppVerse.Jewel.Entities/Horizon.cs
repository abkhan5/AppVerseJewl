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

    }



    public class HorizonVolume
    {
        public HorizonVolume(Horizon topHorizon, Horizon bottomHorizon)
        {
            TopHorizon = topHorizon;
            BottomHorizon = bottomHorizon;
        }
        public Horizon TopHorizon { get; }

        public Horizon BottomHorizon { get; }


        public void CalculateVolume()
        {
            var xyPlane = new int[16, 26];
            var xzPlane = new int[16, 26];
            var yzPlane = new int[16, 26];
        }

    }
}