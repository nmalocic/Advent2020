using Advent2020.DayFour;
using Advent2020.DayOne;
using Advent2020.DayThree;
using Advent2020.DayTwo;
using System;

namespace Advent2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //DayOne.DayOne first = new DayOne.DayOne();
            //int result = first.GetSumThenMultiply();
            //int resultForThree = first.GetSumMultiplyForThree();

            //PasswordValidator passwordValidator = new PasswordValidator();
            //int numberOfValid = passwordValidator.GetNumberOfValidPasswords();
            //int secondValidation = passwordValidator.GetNumberOfValidPassowrds2();

            //Tobogan tobogan = new Tobogan();
            //long result = tobogan.GetNumberOfTreesHit();
            //long result2 = tobogan.AllHitnRoute();

            PassportScanner ps = new PassportScanner();
            int result = ps.GetNumberOfValidPassports();
        }
    }
}
