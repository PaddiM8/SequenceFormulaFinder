using System;
using System.Collections.Generic;
using System.Text;
using static PatternFinder.Enums;

namespace PatternFinder
{
    class Sequence
    {
        public double[] Numbers { get;  }
        public Sequence(double[] numbers)
        {
            Numbers = numbers;
        }

        public Formula FindFormula(IncrementTypes presentIncrementType = IncrementTypes.None)
        {
            double[] differences = new double[]
            {
                Numbers[1] - Numbers[0],
                Numbers[2] - Numbers[1]
            };

            IncrementTypes incrementType = IncrementTypes.None;
            double startValueDifference = 0;
            double baseValue = 1.0;
            double exponent = 1.0;
            double increment = 1.0;
            if (differences[0] == differences[1])
            {
                incrementType = IncrementTypes.ByDifference;
                increment = differences[0];
                startValueDifference = differences[0];
                exponent = 0;
            } else if (NAsExponent(differences) || presentIncrementType ==
                                                   IncrementTypes.NAsExponent)
            {
                incrementType = IncrementTypes.NAsExponent;
                startValueDifference = GetBase(differences);
                baseValue = GetBase(differences);
            } else
            {
                incrementType = IncrementTypes.NAsBase;
                startValueDifference = 1.0;
                exponent = GetExponent(Numbers[0] - startValueDifference);
            }

            double startValue = Numbers[0] - startValueDifference;

            Number incrementNumber  = new Number(Signs.N,        increment, true);
            Number baseValueNumber  = new Number(Signs.None,     baseValue);
            Number exponentNumber   = new Number(Signs.Exponent, exponent);
            Number startValueNumber = new Number(Signs.Addition, startValue);

            if (startValue < 0)
            {
                startValueNumber.Sign = Signs.Subtraction;
                startValueNumber.Value = startValueNumber.Value * -1;
            }

            List<Number> numberList = new List<Number>();
            if (incrementType == IncrementTypes.ByDifference)
            {
                numberList.Add(incrementNumber);
            } else if (incrementType == IncrementTypes.NAsBase)
            {
                numberList.Add(new Number(Signs.None, "n"));
                numberList.Add(exponentNumber);
            } else if (incrementType == IncrementTypes.NAsExponent)
            {
                numberList.Add(baseValueNumber);
                numberList.Add(new Number(Signs.Exponent, "n"));
            }

            if (startValue != 0) numberList.Add(startValueNumber);
            var formula = new Formula(numberList);
            List<double> calculatedFormula = formula.CalculateMultiple(3);

            if (calculatedFormula[0] != Numbers[0] ||
                calculatedFormula[1] != Numbers[1] ||
                calculatedFormula[2] != Numbers[2])
            {
                if (incrementType != IncrementTypes.NAsExponent)
                {
                    formula = FindFormula(IncrementTypes.NAsExponent);
                } else
                {
                    return null;
                }
            }

            return formula;
        }

        private double GetBase(double[] differences)
        {
            return differences[1] / differences[0];
        }

        private bool NAsExponent(double[] differences)
        {
            double baseNumber = GetBase(differences);
            return Math.Log(Numbers[1] - (baseNumber - 1), baseNumber) == 2.0;
        }

        private double GetExponent(double startValue)
        {
            return Math.Log(Numbers[1] - startValue, 2.0);
        }
}
}
