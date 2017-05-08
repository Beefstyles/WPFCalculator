using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            calculator.ResultsString = calculator.CurrentSubTotal.ToString();
            currentOperation = CalculatorOperations.CurrentOperation.Addition;
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

            calculator.ResultsString = calculator.CurrentSubTotal.ToString();
            ClearCurrentDigit(calculator);
            currentOperation = CalculatorOperations.CurrentOperation.Subtraction;
        }

        public void HandleEquals(Calculator calculator, CalculatorOperations calcOps)
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
            calculator.OperationString = "";
            ClearCurrentDigit(calculator);
            calcOps.DigitEntrySet = false;
            calculator.ResultsString = calculator.CurrentSubTotal.ToString();
            currentOperation = CalculatorOperations.CurrentOperation.NoOperation;
            calculator.CurrentSubTotal = 0;
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
            
            calculator.OperationString += calculator.CurrentDigit + " * ";
            calcOps.DigitEntrySet = false;
            ClearCurrentDigit(calculator);
            calculator.ResultsString = calculator.CurrentSubTotal.ToString();
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
            calculator.ResultsString = calculator.CurrentSubTotal.ToString();
            currentOperation = CalculatorOperations.CurrentOperation.Division;
        }

        private void ClearCurrentDigit(Calculator calculator)
        {
            calculator.CurrentDigit = 0;
        }

    }
}
