using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Advent2020.DaySix
{

    public class FormStuff
    {
        List<string> answers = new List<string>();
        string inputPath = @"DaySix\input.txt";

        public FormStuff()
        {
            string[] input = File.ReadAllLines(inputPath);

            string answer = String.Empty;
            foreach (string line in input)
            {
                if (String.IsNullOrWhiteSpace(line))
                {
                    answers.Add(answer.Trim());
                    answer = string.Empty;
                    continue;
                }

                answer += " " + line;
            }
            answers.Add(answer);
        }

        public int SumOfAllCounts()
        {
            return answers.Sum(x => new HashSet<char>(x.Replace(" ", "")).Count);
        }

        public int SumOfEvery()
        {
            int sum = 0;
            foreach(string group in answers)
            {
                Dictionary<char, int> letters = new Dictionary<char, int>();
                string[] personAnswers = group.Trim().Split(" ");
                int target = personAnswers.Length;
                foreach(string answ in personAnswers)
                {
                    foreach(char yes in answ)
                    {
                        if (letters.ContainsKey(yes))
                        {
                            letters[yes]++;
                        } else
                        {
                            letters.Add(yes, 1);
                        }
                    }
                }

                foreach(int value in letters.Values)
                {
                    if(value == target)
                    {
                        sum++;
                    }
                }
            }

            return sum;
        }
    }
}
