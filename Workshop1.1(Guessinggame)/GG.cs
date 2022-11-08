using System;
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
            Console.WriteLine("Gussed Number found");
        }
        else 
        {
            remainingChances--;
            Console.WriteLine("Please try again");
        }
    }