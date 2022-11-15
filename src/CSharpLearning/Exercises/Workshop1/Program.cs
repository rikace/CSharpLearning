using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop1
{
    class Program
    {
        // 1.	A program generates a random number between 1 and 10. This number is not outputted to the console.
        // 2.	The console asks the user for a number input
        // 3.	The user has 5 chances. If a chance is missed, the user must be warned of how many chances are a left and must be prompted to try again.
        // 4.	If the number is guessed correctly, give a success message and terminate the program.
        // 5.	If there are no more chances, give a warning message and terminate the program.

        // See Docs folder Activity 1

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var numberToBeGuessed = new Random().Next(0, 10);
            var remainingChances = 5;
            var numberFound = false;

            Console.WriteLine("Welcome to C# Workshop Guessing Game.");
            while (remainingChances > 0 && !numberFound)
            {
                Console.WriteLine($"\n You have {remainingChances} chances. Please type a number between 0 and 10 to try to guess the number generated for you.");

                var number = int.Parse(Console.ReadLine());
                if (number == numberToBeGuessed)
                {
                    numberFound = true;
                }
                else
                {
                    remainingChances--;
                }

            }
        }
    }
}


