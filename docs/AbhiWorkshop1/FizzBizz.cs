using System;
using System.Collections.Generic;
using System.Text;

namespace WorkShop1
{
    public class FissBuzz
    {
        public static void Run()
        {
            {   
                for (int i = 1; i <= 100; i++)
                {
                    if(i % 3 == 0 & i % 5 == 0)
                    {
                        Console.WriteLine("FizzBuzz");
                    }
                    else if(i % 3 == 0)
                    {
                        Console.WriteLine("Fizz");
                    }
                    else if(i % 5 == 0)
                    {
                        Console.WriteLine("Buzz");
                    }
                    else Console.WriteLine(i);
                }
            }
        }
    }
    
}