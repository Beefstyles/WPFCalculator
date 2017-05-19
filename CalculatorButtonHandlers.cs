using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;

namespace WPFCalculator
{
    class CalculatorButtonHandlers
    {
        public CalculatorOperations.CurrentOperation currentOperation;

        public void PerformOperation(Calculator calculator, CalculatorOperations calcOps)
        {
            switch (currentOperation)
            {
                case (CalculatorOperations.CurrentOperation.Addition):
                    HandleAddition(calculator, calcOps);
                    break;
                case (CalculatorOperations.CurrentOperation.Subtraction):
                    HandleSubtraction(calculator, calcOps);
                    break;
                case (CalculatorOperations.CurrentOperation.Multiplication):
                    HandleMultiplication(calculator, calcOps);
                    break;
                case (CalculatorOperations.CurrentOperation.Division):
                    HandleDivision(calculator, calcOps);
                    break;
                case (CalculatorOperations.CurrentOperation.Reciprocal):
                    HandleReciprocal(calculator, calcOps);
                    break;
                case (CalculatorOperations.CurrentOperation.SquareRoot):
                    HandleSquareRoot(calculator, calcOps);
                    break;
            }
        }

        public void HandleAddition(Calculator calculator, CalculatorOperations calcOps)
        {
            if (currentOperation == CalculatorOperations.CurrentOperation.Equals || currentOperation == CalculatorOperations.CurrentOperation.SquareRoot || currentOperation == CalculatorOperations.CurrentOperation.Reciprocal && calculator.CurrentSubTotal != 0)
            {
                currentOperation = CalculatorOperations.CurrentOperation.Addition;
                calculator.OperationString = calculator.CurrentSubTotal + " + ";
            }
            else
            {
                calculator.CurrentSubTotal = calcOps.Addition(calculator.CurrentSubTotal, (double)calculator.CurrentDigit);
                calculator.OperationString += calculator.CurrentDigit + " + ";
                calcOps.DigitEntrySet = false;
                ClearCurrentDigit(calculator);
                SetResultsString(calculator, false, calculator.CurrentSubTotal);
                currentOperation = CalculatorOperations.CurrentOperation.Addition;
            }

        }


        public void HandleSubtraction(Calculator calculator, CalculatorOperations calcOps)
        {
            if (currentOperation == CalculatorOperations.CurrentOperation.Equals || currentOperation == CalculatorOperations.CurrentOperation.SquareRoot || currentOperation == CalculatorOperations.CurrentOperation.Reciprocal && calculator.CurrentSubTotal != 0)
            {
                currentOperation = CalculatorOperations.CurrentOperation.Subtraction;
                calculator.OperationString = calculator.CurrentSubTotal + " - ";
            }
            else
            {
                if (calculator.CurrentSubTotal != 0)
                {
                    calculator.CurrentSubTotal = calcOps.Subtraction(calculator.CurrentSubTotal, (double)calculator.CurrentDigit);
                }
                else
                {
                    calculator.CurrentSubTotal = (double)calculator.CurrentDigit;
                }
                calculator.OperationString += calculator.CurrentDigit + " - ";
                calcOps.DigitEntrySet = false;

                SetResultsString(calculator, false, calculator.CurrentSubTotal);
                ClearCurrentDigit(calculator);
                currentOperation = CalculatorOperations.CurrentOperation.Subtraction;
            }
        }

        public void HandleEquals(Calculator calculator, CalculatorOperations calcOps)
        {
            PerformOperation(calculator, calcOps);
            calculator.OperationString = "";
            currentOperation = CalculatorOperations.CurrentOperation.Equals;
            calculator.OperationSet = true;
            Console.WriteLine("Current sub equals: " + calculator.CurrentSubTotal);
        }

        public void HandleMultiplication(Calculator calculator, CalculatorOperations calcOps)
        {
            if (currentOperation == CalculatorOperations.CurrentOperation.Equals || currentOperation == CalculatorOperations.CurrentOperation.SquareRoot || currentOperation == CalculatorOperations.CurrentOperation.Reciprocal)
            {
                currentOperation = CalculatorOperations.CurrentOperation.Multiplication;
                calculator.OperationString = calculator.CurrentSubTotal + " * ";
            }
            else
            {
                if (calculator.CurrentSubTotal != 0)
                {
                    calculator.CurrentSubTotal = calcOps.Multiplication(calculator.CurrentSubTotal, (double)calculator.CurrentDigit);
                }
                else
                {
                    calculator.CurrentSubTotal = (double)calculator.CurrentDigit;
                }
                calculator.OperationSet = true;
                calculator.OperationString += calculator.CurrentDigit + " * ";
                calcOps.DigitEntrySet = false;
                ClearCurrentDigit(calculator);
                SetResultsString(calculator, false, calculator.CurrentSubTotal);
                currentOperation = CalculatorOperations.CurrentOperation.Multiplication;
            }
        }

        public void HandleSquareRoot(Calculator calculator, CalculatorOperations calcOps)
        {
            double numberToBeActioned;

            if (calcOps.DigitEntrySet)
            {
                numberToBeActioned = (double)calculator.CurrentDigit;
                calculator.CurrentSubTotal = Math.Sqrt((double)calculator.CurrentDigit);
                SetResultsString(calculator, false, calculator.CurrentSubTotal);
            }
            else
            {
                numberToBeActioned = calculator.CurrentSubTotal;
                calculator.CurrentSubTotal = Math.Sqrt(calculator.CurrentSubTotal);
                SetResultsString(calculator, false, calculator.CurrentSubTotal);
            }

            calculator.OperationString = "√(" + numberToBeActioned + ")";
            calcOps.DigitEntrySet = false;
            ClearCurrentDigit(calculator);
            SetResultsString(calculator, false, calculator.CurrentSubTotal);
            checkIfDecimal(calcOps, calculator.CurrentSubTotal.ToString());
            currentOperation = CalculatorOperations.CurrentOperation.SquareRoot;

        }

        public void HandleReciprocal(Calculator calculator, CalculatorOperations calcOps)
        {
            double numberToBeActioned;
            if (calcOps.DigitEntrySet)
            {
                numberToBeActioned = (double)calculator.CurrentDigit;
                calculator.CurrentSubTotal = (double)(1 / (calculator.CurrentDigit));
                SetResultsString(calculator, false, calculator.CurrentSubTotal);
            }
            else
            {
                numberToBeActioned = calculator.CurrentSubTotal;
                calculator.CurrentSubTotal = 1 / (calculator.CurrentSubTotal);
                SetResultsString(calculator, false, calculator.CurrentSubTotal);
            }

            calculator.OperationString = "reciproc(" + numberToBeActioned + ")";
            calcOps.DigitEntrySet = false;
            ClearCurrentDigit(calculator);
            SetResultsString(calculator, false, calculator.CurrentSubTotal);
            currentOperation = CalculatorOperations.CurrentOperation.Reciprocal;
            checkIfDecimal(calcOps, calculator.CurrentSubTotal.ToString());
        }

        public void HandleDivision(Calculator calculator, CalculatorOperations calcOps)
        {
            if (currentOperation == CalculatorOperations.CurrentOperation.Equals || currentOperation == CalculatorOperations.CurrentOperation.SquareRoot || currentOperation == CalculatorOperations.CurrentOperation.Reciprocal && calculator.CurrentSubTotal != 0)
            {
                currentOperation = CalculatorOperations.CurrentOperation.Division;
                calculator.OperationString = calculator.CurrentSubTotal + " / ";
            }
            else
            {
                if (calculator.CurrentSubTotal != 0)
                {
                    calculator.CurrentSubTotal = calcOps.Division(calculator.CurrentSubTotal, (double)calculator.CurrentDigit);
                    Console.Write(calculator.CurrentSubTotal);
                }
                else
                {
                    calculator.CurrentSubTotal = (double)calculator.CurrentDigit;
                }

                calculator.OperationString += calculator.CurrentDigit + " / ";
                calcOps.DigitEntrySet = false;
                ClearCurrentDigit(calculator);
                SetResultsString(calculator, false, calculator.CurrentSubTotal);
                currentOperation = CalculatorOperations.CurrentOperation.Division;
                checkIfDecimal(calcOps, calculator.CurrentSubTotal.ToString());
            }
        }

        public void HandleNegation(Calculator calculator, CalculatorOperations calcOps)
        {
            if (calcOps.DigitEntrySet)
            {
                calculator.CurrentDigit *= -1;
                SetResultsString(calculator, true, (double)calculator.CurrentDigit);
            }
            else
            {
                calculator.CurrentSubTotal *= -1;
                SetResultsString(calculator, false, calculator.CurrentSubTotal);
            }
        }

        private void ClearCurrentDigit(Calculator calculator)
        {
            calculator.CurrentDigit = 0;
        }

        public void SetResultsString(Calculator calculator, bool digitToBeSet, double digitSent)
        {
            if (digitToBeSet)
            {
                calculator.ResultsString = digitSent.ToString();
            }
            else
            {
                digitSent = Math.Round(calculator.CurrentSubTotal, calculator.MaximumResultsStringLength);
                calculator.ResultsString = digitSent.ToString();
            }
        }

        public void HandleClear(Calculator calculator, CalculatorOperations calcOps)
        {
            calculator.ResultsString = "0";
            calculator.OperationString = "";
            calculator.CurrentDigit = 0;
            calculator.CurrentSubTotal = 0;
            calcOps.DecimalUsed = false;
            currentOperation = CalculatorOperations.CurrentOperation.NoOperation;
        }

        public void HandleRemoveDigit(Calculator calculator, CalculatorOperations calcops)
        {
            if (calcops.DigitEntrySet)
            {
                if (calculator.ResultsString.Length > 1)
                {
                    calculator.ResultsString = calculator.ResultsString.Remove(calculator.ResultsString.Length - 1);
                    calculator.CurrentDigit = decimal.Parse(calculator.ResultsString);
                    SetResultsString(calculator, true, (double)calculator.CurrentDigit);
                }
                else
                {
                    calculator.CurrentDigit = 0;
                    SetResultsString(calculator, true, (double)calculator.CurrentDigit);
                }
            }
            else
            {
                SystemSounds.Exclamation.Play();
            }
        }


        private void checkIfDecimal(CalculatorOperations calcops, string result)
        {
            if (result.ToLower().Contains('.'))
            {
                //calcops.DecimalUsed = true;
            }
            else
            {
                //calcops.DecimalUsed = false;
            }
        }

    }
}
