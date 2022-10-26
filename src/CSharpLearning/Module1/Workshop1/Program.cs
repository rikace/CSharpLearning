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
            Console.WriteLine("Hello World!");
            Random rnd = new Random();

                int rwnnn = rnd.Next(10);
                //Console.WriteLine(rnd.Next(10));
                Console.WriteLine("Random Number is : **");
            
            int count = 1;
            while (count <= 5)
            {
                Console.WriteLine("Please guess the Random number for " + count + "Time");
                int nnn = Convert.ToInt32(Console.ReadLine());

                if (nnn == rwnnn)
                {
                    Console.WriteLine(" congrats; You got the correct Number");
                    break;
                }
                else{
                    count = count+1;
                     Console.WriteLine("You got the Wrong Number , try again");
                }
            }
        }
    }
}
