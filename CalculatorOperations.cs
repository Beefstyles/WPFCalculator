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
        private bool secondDigitSet;

        public bool SecondDigitSet
        {
            get
            {
                return secondDigitSet;
            }

            set
            {
                secondDigitSet = value;
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
            Debug.WriteLine(result.ToString());
            return result;
        }
    }
}
