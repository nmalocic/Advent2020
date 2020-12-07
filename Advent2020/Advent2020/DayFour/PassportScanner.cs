using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent2020.DayFour
{
    public class PassportScanner
    {
        private string inputPath = @"DayFour\input.txt";
        List<string> passportInformation = new List<string>();
        List<string> requiredFiels = new List<string>() { "byr:", "iyr:", "eyr:", "hgt:", "hcl:", "ecl:", "pid:" };
        Dictionary<string, Func<string, bool>> fieldValidation = new Dictionary<string, Func<string, bool>>();

        public PassportScanner()
        {
            string[] input = File.ReadAllLines(inputPath);

            string passwordInfo = String.Empty;
            foreach(string line in input)
            {
                if(String.IsNullOrWhiteSpace(line))
                {
                    passportInformation.Add(passwordInfo.Trim());
                    passwordInfo = string.Empty;
                    continue;
                }

                passwordInfo += " " + line;
            }
            passportInformation.Add(passwordInfo);

            fieldValidation.Add("byr", IsBirthYearValid);
            fieldValidation.Add("iyr", IsIssueYearValid);
            fieldValidation.Add("eyr", IsExpirationYearValid);
            fieldValidation.Add("hgt", IsHeightValid);
            fieldValidation.Add("hcl", IsHairColorValid);
            fieldValidation.Add("ecl", IsEyeColorValid);
            fieldValidation.Add("pid", IsPasswordIdValid);
        }
        public int GetNumberOfValidPassports()
        {
            return FilterFalidPassports()
                    .Count(passport => passport.Split(" ").All( field =>
                    {
                        string[] fieldParts = field.Split(":");
                        if (fieldValidation.ContainsKey(fieldParts[0]))
                        {
                            return fieldValidation[fieldParts[0]](fieldParts[1]);
                        }

                        return true;
                    }));
        }

        public IEnumerable<string> FilterFalidPassports()
        {
            return passportInformation.Where(passport => fieldValidation.Keys.All(rf => passport.Contains(rf)));
        }

        public bool IsBirthYearValid(string year)
        {
            return IsYearValid(year, 1920, 2002);
        }

        public bool IsIssueYearValid(string year)
        {
            return IsYearValid(year, 2010, 2020);
        }

        public bool IsExpirationYearValid(string year)
        {
            return IsYearValid(year, 2020, 2030);
        }

        public bool IsHeightValid(string height)
        {
            if (height.ToLower().EndsWith("cm"))
            {
                return IsHeight(height, 150, 193);

            } else if (height.ToLower().EndsWith("in"))
            {
                return IsHeight(height, 59, 76);
            } else
            {
                return false;
            }
        }

        public bool IsHairColorValid(string color)
        {
            return Regex.Match(color, "^#(?:[0-9a-fA-F]{3}){1,2}$").Success;
        }

        public bool IsEyeColorValid(string color)
        {
            List<string> validColors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            return validColors.Any(valid => valid.Equals(color));
        }

        public bool IsPasswordIdValid(string passwordId)
        {
            if (passwordId.Length == 9)
            {
                return int.TryParse(passwordId, out int notinUse);
            }

            return false;
        }

        private bool IsYearValid(string year, int lower, int upper)
        {
            int value;
            if (int.TryParse(year, out value))
            {
                return lower <= value && value <= upper;
            }

            return false;
        }

        private bool IsHeight(string height, int lower, int upper)
        {
            string heightOnly = height.Substring(0, height.Length - 2);
            if (int.TryParse(heightOnly, out int value))
            {
                return lower <= value && value <= upper;
            }
            return false;
        }
    }
}
