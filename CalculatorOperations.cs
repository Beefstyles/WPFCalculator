﻿using System;
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
            Addition, Subtraction, Multiplication, Division, SquareRoot, Reciprocal, Equals, NoOperation
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

        private bool decimalUsed;

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

        public bool DecimalUsed
        {
            get
            {
                return decimalUsed;
            }

            set
            {
                decimalUsed = value;
            }
        }

        private bool subTotalSet;

        private bool digitEntrySet;

        public double Addition(double a, double b)
        {
            double result = a + b;
            return result;
        }

        public double Subtraction(double a, double b)
        {
            double result = a - b;
            return result;
        }

        public double Multiplication(double a, double b)
        {
            double result = a * b;
            return result;
        }

        public double Division(double a, double b)
        {
            double result = a / b;
            return result;
        }

    }
}
