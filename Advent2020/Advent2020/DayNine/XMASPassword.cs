using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Advent2020.DayNine
{
    public class XMASPassword
    {
        private string inputPath = @"DayNine\input.txt";
        private string[] input;
        private HashSet<long> sumsOfFirstNumber = new HashSet<long>();


        public XMASPassword()
        {
            input = File.ReadAllLines(inputPath);
        }

        public long FindMissingNumber(int preamble)
        {
            long[] restOfInput = input.Select( x => long.Parse(x)).ToArray();
            long missing = 0;
            int indexOfInvalid = 0;
            for(int i = preamble; i < restOfInput.Length; i++)
            {
                long current = restOfInput[i];
                populateSums(preamble, i);
                if (!sumsOfFirstNumber.Contains(current))
                {
                    indexOfInvalid = i;
                    missing = current;
                    break;
                }
            }
            int startIndex = 0;
            List<long> corruptedSequence = new List<long>();
            for(int i = startIndex; i < indexOfInvalid; i++)
            {
                corruptedSequence.Add(restOfInput[i]);
                if (corruptedSequence.Sum() == missing)
                {
                    long result = corruptedSequence.Max() + corruptedSequence.Min();
                    return result;
                } else if (corruptedSequence.Sum() > missing)
                {
                    i = startIndex;
                    startIndex++;
                    corruptedSequence.Clear();
                }
            }

            return 0;
        }


        private void populateSums(int preamble, int index)
        {
            sumsOfFirstNumber = new HashSet<long>();
            long[] numberForSum = Array.ConvertAll(input.Skip(index - preamble).Take(preamble).ToArray(), s => long.Parse(s));

            for (int i = 0; i < numberForSum.Length - 1; i++)
            {
                for (int j = i; j < numberForSum.Length; j++)
                {
                    sumsOfFirstNumber.Add(numberForSum[i] + numberForSum[j]);
                }
            }
        }
    }
}
