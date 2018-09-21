using System;
using System.Collections.Generic;
using System.Text;
using static PatternFinder.Enums;

namespace PatternFinder
{
    class Number
    {
        public double Value { get; set; }
        public Signs Sign       { get; set; }
        public string Variable { get; set; }
        public bool SignAtEnd  { get; set; }

        public Number(Signs sign, double value, bool signAtEnd = false)
        {
            Sign = sign;
            Variable = "";
            Value = value;
            SignAtEnd = signAtEnd;
        }

        public Number(Signs sign, string variable, bool signAtEnd = false)
        {
            Sign = sign;
            Variable = variable;
            SignAtEnd = signAtEnd;
        }
    }
}
