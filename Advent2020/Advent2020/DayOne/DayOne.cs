using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2020.DayOne
{
    public class DayOne
    {
        public int GetSumThenMultiply()
        {
            int sum = 2020;
            string[] lines = File.ReadAllLines("DayOne\\input.txt");
            int[] allItems = Array.ConvertAll(lines, int.Parse);
            Dictionary<int, int> values = new Dictionary<int, int>(allItems.Length);

            foreach(int item in allItems)
            {
                if (!values.ContainsKey(item))
                {
                    values.Add(item, item);
                }
            }
            
            for(int i=0; i < allItems.Length; i++)
            {
                if (values.ContainsKey(sum - allItems[i]))
                {
                    int dictValue = 0;
                    values.TryGetValue(sum - allItems[i], out dictValue);

                    return dictValue * allItems[i];
                }
            }

            return 0;
           
        }

        public int GetSumMultiplyForThree()
        {
            string[] lines = File.ReadAllLines("DayOne\\input.txt");
            int[] allItems = Array.ConvertAll(lines, int.Parse);
            int[] filtered = allItems.Where(x => x < 2020).ToArray();
            for (int i = 0; i < filtered.Length - 2; i++)
            {
                for (int j = i + 1; j < filtered.Length -1; j++)
                {
                    for (int k = j + 1; k < filtered.Length; k++)
                    {
                        int sum = filtered[i] + filtered[j] + filtered[k];
                        if (sum == 2020)
                        {
                            return filtered[i] * filtered[j] * filtered[k];
                        }
                    }
                }
            }

            return 0;
        }
    }
}
