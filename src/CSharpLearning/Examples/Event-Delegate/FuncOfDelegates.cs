using System;

namespace Event_Delegate
{
    public class FuncOfDelegates
    {
        static string Name { get; set; }

        public static void Run(string input)
        {
            Func<string, bool> validator =
                word =>
                {
                    int count = word.Length;
                    return count > 3;
                };

            bool isValid = validator(Name);




            ValidateInput(validator);

            ValidateInput(word =>
            {
                int count = word.Length;
                return count > 3;
            });

            Console.ReadKey();
        }

        public static void ValidateInput(Func<string, bool> validator)
        {
            string input = "Hello";
            bool isValid = validator(input);
            Console.WriteLine($"Is Valid: {isValid}");
        }
    }
}
