using System;

namespace EventDelegate
{

    public class ActionLambda
    {
        public static void Run()
        {
            Predicate<string> validator1 =
                word =>
                {
                    int count = word.Length;
                    return count > 3;
                };
            Predicate<string> validator2 =
              word =>
              {
                  int count = word.Length;
                  return count % 2 == 0;
              };
            ValidateInput(validator1);
            ValidateInput(validator2);


            ValidateInput(word =>
            {
                int count = word.Length;
                return count > 3;
            });

            Console.ReadKey();
        }

        
        public static void SimpleActionLambda()
        {
            Func<int, int, string> func = (a,b) =>
            {
                return (a + b).ToString();
            };

            func(40, 2);
        }



        public static void ValidateInput(Predicate<string> validator)
        {
            string input = "Hello";
            bool isValid = validator(input);
            Console.WriteLine($"Is Valid: {isValid}");
        }
    }
}