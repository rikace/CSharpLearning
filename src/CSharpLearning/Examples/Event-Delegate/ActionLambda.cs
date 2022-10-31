namespace EventDelegate;

public class ActionLambda
{
    public static void Run()
    {
        Predicate<string> validator =
            word =>
            {
                int count = word.Length;
                return count > 3;
            };
        ValidateInput(validator);
        ValidateInput(word =>
        {
            int count = word.Length;
            return count > 3;
        });

        Console.ReadKey();
    }

    public static void SimpleActionLambda()
    {
        Action hello = () => Console.WriteLine("Hello!");
        hello();
    }

    public static void ValidateInput(Predicate<string> validator)
    {
        string input = "Hello";
        bool isValid = validator(input);
        Console.WriteLine($"Is Valid: {isValid}");
    }
}