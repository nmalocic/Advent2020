using Advent2020.DayEight;
using Advent2020.DayFive;
using Advent2020.DayFour;
using Advent2020.DayNine;
using Advent2020.DayOne;
using Advent2020.DaySeven;
using Advent2020.DaySix;
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

            //PassportScanner ps = new PassportScanner();
            //int result = ps.GetNumberOfValidPassports();


            //SeatFinder sf = new SeatFinder();
            //int result = sf.FindMaxSeatId();
            //int result2 = sf.FindMySeat();

            //FormStuff fs = new FormStuff();
            //int result = fs.SumOfAllCounts();
            //int result2 = fs.SumOfEvery();

            //Bags bag = new Bags();
            //int result = bag.GetNumberOfBagsHoldingGoldenBag();
            //int result2 = bag.GetNumberOfBagsInsideShinyBag();

            //GameConsole gc = new GameConsole();
            //int result = gc.ExecuteCommands();
            //int result2 = gc.ChangeCommand();

            XMASPassword xs = new XMASPassword();
            long result = xs.FindMissingNumber(25);
        }
    }
}
