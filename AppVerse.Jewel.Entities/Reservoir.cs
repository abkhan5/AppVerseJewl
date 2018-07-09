using System;
using System.Collections.Generic;

namespace AppVerse.Jewel.Entities
{
    public class Reservoir
    {
        public Reservoir(Horizon topHorizon)
        {
            TopHorizon = topHorizon;
            BottomHorizon = new Horizon(16, 26);
        }

        public Horizon TopHorizon { get; }

        public Horizon BottomHorizon { get; }

        public VolumeUnitSystem Volume { get; private  set; }

        private void CalculateBottomHorizon()
        {
            var depthChart = TopHorizon.Depth;
            
            for (int row = 0; row < 26; row++)
                for (int column = 0; column < 16; column++)
                    BottomHorizon.Depth[column][row] = new LengthUnitSystem(depthChart[column][row].SelectedValue + 328.0);
        }

        public void CalculateVolume()
        {
            CalculateBottomHorizon();
            double totalVolume = 0;
            var topDepth = TopHorizon.Depth;
            var bottomDepth = BottomHorizon.Depth;
            
            for (int column = 0; column < 15; column++)
            {
                for (int row = 0; row < 25; row++)
                {
                  var volume=  CalculateVolumeForCube(topDepth, column, row, bottomDepth);
                    totalVolume += volume;
                }
            }

            Volume= new VolumeUnitSystem(totalVolume);
        }

        private  double CalculateVolumeForCube(LengthUnitSystem[][] topDepth, int column, int row,
            LengthUnitSystem[][] bottomDepth)
        {
            
            var topDimensions = GetDimensions(topDepth, column, row);

            var bottomDimensions = GetDimensions(bottomDepth, column, row);


            var length = topDimensions.Length > bottomDimensions.Length
                ? bottomDimensions.Length
                : topDimensions.Length;

            var width = topDimensions.Width > bottomDimensions.Width
                ? bottomDimensions.Width
                : topDimensions.Width;
            double height = 328;

            var volume = height * length * width;

            return volume;

        }
        public class DimenstionsOfRectangle
        {
            public double Width { get; set; }
            public double Length { get; set; }

        }

        private DimenstionsOfRectangle GetDimensions(LengthUnitSystem[][] topDepth, int column, int row)
        {
            var topEdgeA = topDepth[column][row].SelectedValue;
            var topEdgeB = topDepth[column + 1][row].SelectedValue;
            var topEdgeC = topDepth[column+1][row + 1].SelectedValue;
            var topEdgeD = topDepth[column ][row+1].SelectedValue;

            double distanceInAB =GetDistance(topEdgeA, topEdgeB);
            double distanceInBC = GetDistance(topEdgeB, topEdgeC);
            double distanceInCD = GetDistance(topEdgeC, topEdgeD);
            double distanceInDA = GetDistance(topEdgeD, topEdgeA);

            var length = distanceInAB > distanceInCD ? distanceInCD : distanceInAB;
            var width = distanceInBC > distanceInDA ? distanceInDA : distanceInBC;

            return new DimenstionsOfRectangle(){ Length = length,Width = width};

        }

        private static double GetDistance(double edgeA, double edgeB)
        {
            double distanceInAB = edgeA - edgeB;

            if (distanceInAB<=0)
            {
                distanceInAB *= -1;
            }

            return distanceInAB;
        }


        private double[,]GetTopXY()
        {
            var topxyPlane = new Double[16, 26];
            for (int r = 0; r < 26; r++)
            {
                for (int c = 0; c < 16; c++)
                {
                    topxyPlane[c, r] = TopHorizon.Depth[c][r].SelectedValue;
                }
            }

            return topxyPlane;
        }
       
        private double[,] GetTopXZ()
        {
            var topxyPlane = new Double[16, 16];
            for (int r = 0; r < 26; r++)
            {
                for (int c = 0; c < 16; c++)
                {
                    topxyPlane[c, r] = TopHorizon.Depth[c][r].SelectedValue;
                }
            }

            return topxyPlane;
        }

    }
}