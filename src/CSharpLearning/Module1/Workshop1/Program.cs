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
            Random random = new Random();

            int randomNum = random.Next(1,10);
            int chances = 4;
            int userNum;
            
            Console.WriteLine("Guess the Number between 1 to 9");
            string temp = Console.ReadLine();
            userNum = int.Parse(temp);

            while (randomNum != userNum && chances >= 1)
            {
                Console.WriteLine("{0} chance left and try again", chances);

                temp = Console.ReadLine();
                userNum = int.Parse(temp);

                chances--;

            }
			
            if(randomNum == userNum)
            {
                Console.WriteLine("Great! you got right number");
            }
            else
            {
                Console.WriteLine("exceeded maximum limit");
            }
            
        }
    }
}
