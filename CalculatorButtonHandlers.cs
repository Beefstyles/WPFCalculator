using System;
using System.Collections.Generic;
using System.Linq;

namespace WPFCalculator
{
    class CalculatorButtonHandlers
    {
        public CalculatorOperations.CurrentOperation currentOperation;

        public void HandleAddition(Calculator calculator, CalculatorOperations calcOps)
        {
            calculator.CurrentSubTotal = calcOps.Addition(calculator.CurrentSubTotal, calculator.CurrentDigit);
            calculator.OperationString += calculator.CurrentDigit + " + ";
            calcOps.DigitEntrySet = false;
            ClearCurrentDigit(calculator);
            SetResultsString(calculator, false);
            currentOperation = CalculatorOperations.CurrentOperation.Addition;
        }

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
            }
        }
        public void HandleSubtraction(Calculator calculator, CalculatorOperations calcOps)
        {
            if (calculator.CurrentSubTotal != 0)
            {
                calculator.CurrentSubTotal = calcOps.Subtraction(calculator.CurrentSubTotal, calculator.CurrentDigit);
            }
            else
            {
                calculator.CurrentSubTotal = calculator.CurrentDigit;
            }

            calculator.OperationString += calculator.CurrentDigit + " - ";
            calcOps.DigitEntrySet = false;

            SetResultsString(calculator, false);
            ClearCurrentDigit(calculator);
            currentOperation = CalculatorOperations.CurrentOperation.Subtraction;
        }

        public void HandleEquals(Calculator calculator, CalculatorOperations calcOps)
        {
            PerformOperation(calculator, calcOps);
            calculator.OperationString = "";
            currentOperation = CalculatorOperations.CurrentOperation.NoOperation;
            calculator.OperationSet = true;
            Console.WriteLine("Current sub equals: " + calculator.CurrentSubTotal);
        }

        public void HandleMultiplication(Calculator calculator, CalculatorOperations calcOps)
        {
            if (calculator.CurrentSubTotal != 0)
            {
                calculator.CurrentSubTotal = calcOps.Multiplication(calculator.CurrentSubTotal, calculator.CurrentDigit);
            }
            else
            {
                calculator.CurrentSubTotal = calculator.CurrentDigit;
            }
            calculator.OperationSet = true;
            calculator.OperationString += calculator.CurrentDigit + " * ";
            calcOps.DigitEntrySet = false;
            ClearCurrentDigit(calculator);
            SetResultsString(calculator, false);
            currentOperation = CalculatorOperations.CurrentOperation.Multiplication;

        }

        public void HandleDivision(Calculator calculator, CalculatorOperations calcOps)
        {
            if (calculator.CurrentSubTotal != 0)
            {
                calculator.CurrentSubTotal = calcOps.Division(calculator.CurrentSubTotal, calculator.CurrentDigit);
                Console.Write(calculator.CurrentSubTotal);
            }
            else
            {
                calculator.CurrentSubTotal = calculator.CurrentDigit;
            }

            calculator.OperationString += calculator.CurrentDigit + " / ";
            calcOps.DigitEntrySet = false;
            ClearCurrentDigit(calculator);
            SetResultsString(calculator, false);
            currentOperation = CalculatorOperations.CurrentOperation.Division;
        }

        public void HandleNegation(Calculator calculator, CalculatorOperations calcOps)
        {
            if (calcOps.DigitEntrySet)
            {
                calculator.CurrentDigit *= -1;
                SetResultsString(calculator, true);
            }
            else
            {
                calculator.CurrentSubTotal *= -1;
                SetResultsString(calculator, false);
            }
        }

        private void ClearCurrentDigit(Calculator calculator)
        {
            calculator.CurrentDigit = 0;
        }

        public void SetResultsString(Calculator calculator, bool digitToBeSet)
        {
            if (digitToBeSet)
            {
                calculator.ResultsString = calculator.CurrentDigit.ToString();
            }
            else
            {
                //calculator.CurrentSubTotal = Math.Round(calculator.CurrentSubTotal, 7);
                calculator.ResultsString = calculator.CurrentSubTotal.ToString();
            }
            
        }

        public void HandleClear(Calculator calculator)
        {
            calculator.ResultsString = "0";
            calculator.OperationString = "";
            calculator.CurrentDigit = 0;
            calculator.CurrentSubTotal = 0;
        }

        public void HandleRemoveDigit(Calculator calculator)
        {
            
        }



    }
}
