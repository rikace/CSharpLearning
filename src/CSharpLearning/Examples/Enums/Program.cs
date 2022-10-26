using System;

class Program
{
    public enum MathOperation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }
    
    static void Main()
    {
        string[] possibleOperations = Enum.GetNames(typeof(MathOperation));

        Console.Write($"Please select ({string.Join(", ", possibleOperations)}): ");

        string operationString = Console.ReadLine();

        MathOperation selectedOperation;

        if (!Enum.TryParse<MathOperation>(operationString, out selectedOperation))
            selectedOperation = MathOperation.Add;

        switch (selectedOperation)
        {
            case MathOperation.Add:
                Console.WriteLine($"You selected {nameof(MathOperation.Add)}");
                break;
            case MathOperation.Subtract:
                Console.WriteLine($"You selected {nameof(MathOperation.Subtract)}");
                break;
            case MathOperation.Multiply:
                Console.WriteLine($"You selected {nameof(MathOperation.Multiply)}");
                break;
            case MathOperation.Divide:
                Console.WriteLine($"You selected {nameof(MathOperation.Divide)}");
                break;
        }

        Console.ReadKey();
    }
}