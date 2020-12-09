using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Advent2020.DaySeven
{


    public class Bags
    {
        private string inputPath = @"DaySeven\input.txt";
        private readonly string[] input;
        Dictionary<string, HashSet<string>> colorAndParents = new Dictionary<string, HashSet<string>>();
        Dictionary<string, List<Bag>> colorAndChildren = new Dictionary<string, List<Bag>>();

        public Bags()
        {
            input = File.ReadAllLines(inputPath);

            foreach(string line in input)
            {
                //initForOne(line);
                initForTwo(line);
            }
        }

        public int GetNumberOfBagsHoldingGoldenBag()
        {
            HashSet<string> bagsThatCanHold = new HashSet<string>();
            AddParentsForColor("shiny gold", bagsThatCanHold);
            return bagsThatCanHold.Count;

        }

        public int GetNumberOfBagsInsideShinyBag()
        {
            int sum = 0;
            sum = GetNumberOfBagsForColor("shiny gold") -1;

            return sum;
        }

        public int GetNumberOfBagsForColor(string color)
        {
            int mySum = 1;
            List<Bag> bags = colorAndChildren[color];
            foreach(Bag bag in bags)
            {
                if (bag.Color != "No")
                {
                    mySum += (bag.Number * GetNumberOfBagsForColor(bag.Color));
                }
            }

            return mySum;
        }

        private void AddParentsForColor(string color, HashSet<string> parents)
        {
            if (colorAndParents.ContainsKey(color))
            {
                foreach(string parentColor in colorAndParents[color])
                {
                    parents.Add(parentColor);
                    AddParentsForColor(parentColor, parents);
                    
                }
            }
        }

        private void initForOne(string line)
        {
            string[] rules = line.Split("contain");
            string parentColor = rules[0].Replace("bags", "").Trim();
            string[] otherRules = rules[1].Split(",");
            foreach (string rule in otherRules)
            {
                string trimed = rule.Substring(2);
                if (trimed.Contains("bags"))
                {
                    trimed = trimed.Replace("bags", "");
                }
                if (trimed.Contains("bag"))
                {
                    trimed = trimed.Replace("bag", "");
                }
                trimed = trimed.Replace(".", "").Trim();

                if (colorAndParents.ContainsKey(trimed))
                {
                    colorAndParents[trimed].Add(parentColor);
                }
                else
                {
                    colorAndParents.Add(trimed, new HashSet<string>() { parentColor });
                }

            }
        }

        private void initForTwo(string line)
        {
            string[] rules = line.Split("contain");
            string parentColor = rules[0].Replace("bags", "").Trim();
            string[] otherRules = rules[1].Split(",");
            List<Bag> bagsForColor = new List<Bag>();
            foreach (string rule in otherRules)
            {                
                if (rule.Trim().Equals("no other bags."))
                {
                    Bag bag1 = new Bag();
                    bag1.Number = 1;
                    bag1.Color = "No";
                    if (colorAndChildren.ContainsKey(parentColor))
                    {
                        colorAndChildren[parentColor].Add(bag1);
                    }
                    else
                    {
                        colorAndChildren.Add(parentColor, new List<Bag>() { bag1 });
                    }
                    continue;
                }
                string number = rule.Substring(0, 2);
                string trimed = rule.Substring(2);
                if (trimed.Contains("bags"))
                {
                    trimed = trimed.Replace("bags", "");
                }
                if (trimed.Contains("bag"))
                {
                    trimed = trimed.Replace("bag", "");
                }
                trimed = trimed.Replace(".", "").Trim();
                Bag bag = new Bag();
                bag.Number = int.Parse(number);
                bag.Color = trimed;
                if (colorAndChildren.ContainsKey(parentColor))
                {
                    colorAndChildren[parentColor].Add(bag);
                }
                else
                {
                    colorAndChildren.Add(parentColor, new List<Bag>() { bag });
                }
            }
        }
    }

    public class Bag
    {
        public int Number { get; set; }
        public string Color { get; set; }
    }

}
