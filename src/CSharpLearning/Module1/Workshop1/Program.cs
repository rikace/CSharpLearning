using System;

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
            int RandomNumber = new Random().Next(0,10);
            int Chances = 5;

            for (int i = 0; i < Chances; i++)
            {
                Console.Write("Please enter the number in the range of 0-9: ");
                try
                {
                    int EnteredNumber = Convert.ToInt32(Console.ReadLine());
                    if (EnteredNumber == RandomNumber)
                    {
                        Console.WriteLine("Consgratulations. Number matched");
                        break;
                    }
                    else
                    {
                        if (i == Chances - 1)
                        {
                            Console.WriteLine("Sorry, No more chances left.");
                        }
                        else
                        {
                            Console.WriteLine("Number did not matched. " + (Chances - i - 1) + " Chances left");
                        }
                    }
                    Console.WriteLine();
                }
                catch(Exception)
                {
                    Console.Write("Please enter correct number in the range of 0-9. ");
                    Console.WriteLine((Chances - i - 1) + " Chances left");
                    Console.WriteLine();
                }
            }
        }
    }
}
