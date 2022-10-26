using System;
using System.Collections.Generic;
using System.Text;

namespace Module1
{
    // Problem Description
    /*
        Write a program that prints the numbers from 1 to 100. But for multiples of     three
        print "Fizz" instead of the number and for the multiples of five print "Buzz".
        For numbers which are multiples of both three and five print "FizzBuzz?".

        Sample output:
        1 2 Fizz 4 Buzz Fizz 7 8 Fizz Buzz 11 Fizz 13 14 FizzBuzz 16 17 Fizz 19 Buzz ... etc up to 100

        // Requirements
        - A number is fizz if it is divisible by 3 or if it has a 3 in it
        - A number is buzz if it is divisible by 5 or if it has a 5 in it
     */
    public class FizzBuzz
    {
        public static void Run()
        {
            string result;
            // CODE HERE
            for (int i = 1; i <= 100; i++)
            {
                result = null;
                if(i%3 == 0)
                {
                    result = "fizz";
                }
                if(i%5 == 0)
                {
                    result += "Buzz";
                }
                if(result == null)
                {
                    result = i.ToString();
                }
                Console.WriteLine(result);
            }
        }

    };
    class FizzBuzzMain
    {
        public static void Main()
        {

            FizzBuzz.Run();
        }
    }
}
