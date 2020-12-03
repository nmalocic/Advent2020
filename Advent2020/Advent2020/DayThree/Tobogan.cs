using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Advent2020.DayThree
{
    public class Tobogan
    {
        private string inputPath = @"DayThree\input.txt";
        string[] input = new string[300];
        public Tobogan()
        {
            this.input = File.ReadAllLines(inputPath);
        }

        public long GetNumberOfTreesHit()
        {
            return RideTobogan(3, 1);
        }

        public long AllHitnRoute()
        {
            long firstRide = RideTobogan(1, 1);
            long secondRide = RideTobogan(3, 1);
            long thridRide = RideTobogan(5, 1);
            long forthRide = RideTobogan(7, 1);
            long fifthRide = RideTobogan(1, 2);

            return firstRide * secondRide * thridRide * forthRide * fifthRide;
        }

        private long RideTobogan(int right, int down)
        {
            long numberOfThrees = 0;
            int column = 0;
            for (int i = 0; i < input.Length; i += down) 
            {
                if (i == 0) continue;
                string currentBiom = input[i];
                column += right;
                if (column >= 31)
                {
                    column -= 31;
                }
                char landTile = currentBiom[column];
                if (landTile.Equals('#'))
                {
                    numberOfThrees++;
                }
            }

            return numberOfThrees;
        }
    }
}
