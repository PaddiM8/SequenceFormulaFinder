using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PatternFinder
{
    class Enums
    {
        public enum IncrementTypes
        {
            None,
            ByDifference,
            NAsExponent,
            NAsBase
        }

        public enum Signs
        {
            Addition = '+',
            Subtraction = '-',
            Multiplication = '*',
            Division = '/',
            Exponent = '^',
            None,
            N = 'n'
        }
    }
}
