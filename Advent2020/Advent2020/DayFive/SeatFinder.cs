using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
namespace Advent2020.DayFive
{
    public class SeatFinder
    {
        private string[] seatLocations;
        private string path = @"DayFive\input.txt";

        Dictionary<int, string> debug = new Dictionary<int, string>();

        public SeatFinder()
        {
            seatLocations = File.ReadAllLines(path);
        }

        public int FindMySeat()
        {
            int[] seats = seatLocations.Select(s => FindSeatId(s)).OrderBy( x => x).ToArray();
            for(int i=0;i < seats.Count()-1; i++)
            {
                int current = seats[i];
                int next = seats[i + 1];
                if (next - current == 2)
                {
                    return current + 1;
                }
            }

            return 0;
        }

        public int FindMaxSeatId()
        {
            return seatLocations.Max(FindSeatId);
        }

        public int FindSeatId(string boardingPass)
        {
            int row = 0;
            int column = 0;
            int minRow = 0;
            int maxRow = 127;
            int minColumn = 0;
            int maxColumn = 7;

            IEnumerable<char> rowInfo = boardingPass.Take(7);
            IEnumerable<char> columnInfo = boardingPass.Skip(7).Take(3);

            foreach (char c in columnInfo)
            {
                if (c.Equals('L'))
                {
                    double result = (maxColumn + minColumn) / (double)2;
                    column = maxColumn = (int)Math.Floor(result);
                } else
                {
                    double result = (maxColumn + minColumn) / (double)2;
                    column = minColumn = (int)Math.Ceiling(result);
                }
            }

            foreach (char c in rowInfo)
            {
                if (c.Equals('F'))
                {
                    double result = (maxRow + minRow) / (double)2;
                    row = maxRow = (int)Math.Floor(result);
                } else
                {
                    double result = (maxRow + minRow) / (double)2;
                    row = minRow = (int)Math.Ceiling(result);
                }
            }

            int max = row * 8 + column;
            return max;

        }
    }
}
