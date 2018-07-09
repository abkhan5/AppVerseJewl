using System;

namespace AppVerse.Jewel.Entities
{
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