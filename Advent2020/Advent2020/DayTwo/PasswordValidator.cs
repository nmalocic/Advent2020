using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Advent2020.DayTwo
{
    public class PasswordValidator
    {
        string inputFilePath = @"DayTwo\input.txt";
        private List<Password> passwords = new List<Password>();
        public PasswordValidator()
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            foreach(string line in lines)
            {
                string newLine = line.Replace("-", " ").Replace(":", "");
                string[] values = newLine.Split(" ");
                int lower = int.Parse(values[0]);
                int upper = int.Parse(values[1]);
                char letter = values[2].ToCharArray()[0];
                string password = values[3];

                passwords.Add(new Password(lower, upper, letter, password));
            }
        }

        public int GetNumberOfValidPasswords()
        {
            return passwords.Count(x => x.HasGivenNumberOfOccurances());
        }

        public int GetNumberOfValidPassowrds2()
        {
            return passwords.Count(x => x.IsOnlyOnGivenIndex());
        }
    }

    public class Password
    {
        private int zeroIndexOffset = 1;
        int lower;
        int upper;
        char letter;
        string password;

        public Password(int lower, int upper, char letter, string password)
        {
            this.lower = lower;
            this.upper = upper;
            this.letter = letter;
            this.password = password;
        }
        

        public bool HasGivenNumberOfOccurances()
        {
            int num = password.Count(x => x.Equals(letter));

            bool result = lower <= num && num <= upper;
            return result;
        }

        public bool IsOnlyOnGivenIndex()
        {
            List<char> atLocation = new List<char>();
            atLocation.Add(password.ElementAt(lower - zeroIndexOffset));
            atLocation.Add(password.ElementAt(upper - zeroIndexOffset));

            return atLocation.Count(x => x.Equals(letter)) == 1;
        }
    }
}
