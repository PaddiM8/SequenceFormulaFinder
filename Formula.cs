using System;
using System.Collections.Generic;
using static PatternFinder.Enums;

namespace PatternFinder
{
    class Formula
    {
        public List<Number> Numbers { get; }
        public Formula(List<Number> numbers)
        {
            Numbers = numbers;
        }

        public override string ToString()
        {
            string output = "";
            foreach (var number in Numbers)
            {
                string sign = ((char)number.Sign).ToString();
                string value = number.Value.ToString();
                
                if (value == "1" && sign == "n") value = "";
                if (number.Variable != "") value = number.Variable;
                if (sign == "_") sign = "";

                if (number.SignAtEnd) output += value + sign;
                else output += sign + value;
            }

            return output;
        }

        public double Calculate(int n)
        {
            return ParseNumbers(n);
        }

        public List<double> CalculateMultiple(int amount)
        {
            List<double> calculated = new List<double>();
            for (int i = 1; i <= amount; i++)
            {
                calculated.Add(ParseNumbers(i));
            }

            return calculated;
        }

        private double ParseNumbers(int n)
        {
            double result = 0;
            for (int i = 0; i < Numbers.Count; i++)
            {
                double value = Numbers[i].Value;
                if (Numbers[i].Variable == "n")
                    value = n;

                
                if (Numbers[i].Sign == Signs.None) continue;
                if (Numbers[i].Sign == Signs.Exponent)
                {
                    if (i == 0) continue;
                    double previousValue = Numbers[i - 1].Value;
                    if (Numbers[i - 1].Variable == "n") previousValue = n;

                    result = Math.Pow(previousValue, value);
                }

                if (Numbers[i].Sign == Signs.Addition)
                {
                    result += Numbers[i].Value;
                }

                if (Numbers[i].Sign == Signs.Subtraction)
                {
                    result -= Numbers[i].Value;
                }

                if (Numbers[i].Sign == Signs.N)
                {
                    result += Numbers[i].Value * n;
                }
            }

            return result;
        }
    }
}
