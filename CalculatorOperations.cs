using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator
{
    class CalculatorOperations
    {
        public enum CurrentOperation
        {
            Addition, Subtraction, NoOperation
        };
        private bool arithemticDone;

        public bool ArithemticDone
        {
            get
            {
                return arithemticDone;
            }

            set
            {
                arithemticDone = value;
            }
        }

        public bool SubTotalSet
        {
            get
            {
                return subTotalSet;
            }

            set
            {
                subTotalSet = value;
            }
        }

        public bool DigitEntrySet
        {
            get
            {
                return digitEntrySet;
            }

            set
            {
                digitEntrySet = value;
            }
        }

        private bool subTotalSet;

        private bool digitEntrySet;

        public int Addition(int a, int b)
        {
            int result = a + b;
            return result;
        }

        public int Subtraction(int a, int b)
        {
            int result = a - b;
            return result;
        }
    }
}
