using Advent2020.DayOne;
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

            PasswordValidator passwordValidator = new PasswordValidator();
            int numberOfValid = passwordValidator.GetNumberOfValidPasswords();
            int secondValidation = passwordValidator.GetNumberOfValidPassowrds2();
        }
    }
}
