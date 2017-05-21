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
                    calculator.OperationString += calculator.CurrentDigit + " - ";
                }
                else
                {
                    calculator.CurrentSubTotal = (double)calculator.CurrentDigit;
                    calculator.OperationString = calculator.CurrentDigit + " - ";
                }
                
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
                    calculator.OperationString += calculator.CurrentDigit + " * ";
                }
                else
                {
                    Console.WriteLine("0");
                    calculator.CurrentSubTotal = (double)calculator.CurrentDigit;
                    calculator.OperationString = calculator.CurrentDigit + " * ";
                }
                calculator.OperationSet = true;
                
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

        public void HandleMemorySet(Calculator calculator, CalculatorOperations calcOps)
        {
            if (calcOps.DigitEntrySet)
            {
                if(calculator.CurrentDigit != 0)
                {
                    calculator.MemoryValue = (double)calculator.CurrentDigit;
                }
            }
            else
            {
                if (calculator.CurrentSubTotal != 0)
                {
                    calculator.MemoryValue = calculator.CurrentSubTotal;
                }
            }
            SetMemoryIndicator(calculator, true);
        }

        public void HandleMemoryRecall(Calculator calculator, CalculatorOperations calcOps)
        {
            if (calcOps.DigitEntrySet)
            {
                calculator.CurrentDigit = (decimal)calculator.MemoryValue;
                SetResultsString(calculator, true, (double)calculator.CurrentDigit);
            }
            else
            {
                SetResultsString(calculator, true, calculator.CurrentSubTotal);
            }
            calculator.CurrentSubTotal = calculator.MemoryValue;
            calcOps.DigitEntrySet = false;
        }

        public void HandleMemoryChange(Calculator calculator, CalculatorOperations calcOps, bool Addition)
        {
            if (calcOps.DigitEntrySet)
            {
                if (Addition)
                {
                    calculator.MemoryValue += (double)calculator.CurrentDigit;
                }
                else
                {
                    calculator.MemoryValue -= (double)calculator.CurrentDigit;
                }
            }
            else
            {
                if (Addition)
                {
                    calculator.MemoryValue += calculator.CurrentSubTotal;
                }
                else
                {
                    calculator.MemoryValue -= calculator.CurrentSubTotal;
                }
            }
            SetMemoryIndicator(calculator, true);
        }

        private void SetMemoryIndicator(Calculator calculator, bool enableIndicator)
        {
            if (enableIndicator)
            {
                calculator.MemorySet = "M";
            }
            else
            {
                calculator.MemorySet = "";
            }
        }

        public void HandleMemoryClear(Calculator calculator)
        {
            calculator.MemoryValue = 0;
            SetMemoryIndicator(calculator, false);
        }

        private void ClearCurrentDigit(Calculator calculator)
        {
            calculator.CurrentDigit = 0;
        }

        public void SetResultsString(Calculator calculator, bool digitToBeSet, double digitSent)
        {
            if (digitToBeSet)
            {
                digitSent = Math.Round(digitSent, calculator.MaximumResultsStringLength - 2);
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

        public void HandleClearLast(Calculator calculator, CalculatorOperations calcOps)
        {
            calculator.CurrentDigit = 0;
            currentOperation = CalculatorOperations.CurrentOperation.NoOperation;
            SetResultsString(calculator, true, (double)calculator.CurrentDigit);
        }

        public void HandlePercentage(Calculator calculator, CalculatorOperations calcOps)
        {
            double numberToBeActioned;
            if (calcOps.DigitEntrySet)
            {
                if(calculator.CurrentSubTotal != 0)
                {
                    numberToBeActioned = (double)calculator.CurrentDigit / calculator.CurrentSubTotal;
                    calcOps.DigitEntrySet = false;
                    ClearCurrentDigit(calculator);
                    calculator.CurrentDigit = (decimal)numberToBeActioned;
                    SetResultsString(calculator, true, numberToBeActioned);
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                }
            }
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


    }
}
