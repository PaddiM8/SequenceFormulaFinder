using System;
using System.Collections.Generic;

namespace PatternFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("------------------------");
                Console.WriteLine("Separate numbers by comma");
                Console.WriteLine("n = 1...->");
                Console.Write("Sequence: ");
                Console.ResetColor();

                string inputString = Console.ReadLine();
                var sequence = new Sequence(NumberStringToArray(inputString));
                var formula = sequence.FindFormula();

                if (formula == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Didn't find a formula.");
                    continue;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Formula: ");
                Console.ResetColor();
                Console.WriteLine(formula.ToString());
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Continuation: ");
                Console.ResetColor();
                Console.WriteLine(string.Join(", ", formula.CalculateMultiple(20)));
                Console.ResetColor();
                Console.ReadKey();
            }
        }

        private static double[] NumberStringToArray(string inputString)
        {
            List<double> numbers = new List<double>();
            string[] stringSplit = inputString.Split(',');
            for (int i = 0; i <  stringSplit.Length; i++)
            {
                numbers.Add(double.Parse(stringSplit[i].Trim()));
            }

            return numbers.ToArray();
        }
    }
}
