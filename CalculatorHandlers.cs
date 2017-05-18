using System.Windows;
using System.Windows.Controls;

namespace WPFCalculator
{
    class CalculatorHandlers
    {
        CalculatorButtonHandlers calcButtonHandlers = new CalculatorButtonHandlers();
        

        public void GeneralButtonHandler(Button button, Calculator calculator, CalculatorOperations calcOps)
        {
            switch (button.Name)
            {
                case ("Negation"):
                    HandleNegation(calculator, calcOps);
                    break;
                case ("Clear"):
                    HandleClear(calculator, calcOps);
                    break;
                case ("RemoveDigit"):
                    HandleRemoveDigit(calculator, calcOps);
                    break;
                default:
                    MessageBox.Show("Not implemented");
                    break;
            }
        }

        public void ArithmeticHandler(Button button, Calculator calculator, CalculatorOperations calcOps)
        {
            if (!calcOps.ArithemticDone)
            {
                switch (button.Name)
                {
                    case ("Addition"):
                        HandleAddition(calculator, calcOps);
                        calcOps.ArithemticDone = true;
                        break;
                    case ("Subtraction"):
                        HandleSubtraction(calculator, calcOps);
                        calcOps.ArithemticDone = true;
                        break;
                    case ("Equals"):
                        HandleEquals(calculator, calcOps);
                        calcOps.ArithemticDone = false;
                        break;
                    case ("Division"):
                        HandleDivision(calculator, calcOps);
                        calcOps.ArithemticDone = true;
                        break;
                    case ("Multiplication"):
                        HandleMultiplication(calculator, calcOps);
                        break;
                    case ("SquareRoot"):
                        HandleSquareRoot(calculator, calcOps);
                        break;
                    case ("Reciproval"):
                        HandleReciprocal(calculator, calcOps);
                        break;
                    default:
                        MessageBox.Show("Not implemented");
                        break;
                }
            }
        }


        private void HandleAddition(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleAddition(calculator, calcOps);
        }

        private void HandleSubtraction(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleSubtraction(calculator, calcOps);
        }

        private void HandleEquals(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleEquals(calculator, calcOps);
        }

        private void HandleMultiplication(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleMultiplication(calculator, calcOps);
        }

        private void HandleDivision(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleDivision(calculator, calcOps);
        }

        private void HandleNegation(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleNegation(calculator, calcOps);
        }

        private void HandleClear(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleClear(calculator);
        }

        private void HandleRemoveDigit(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleRemoveDigit(calculator, calcOps);
        }

        private void HandleSquareRoot(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleSquareRoot(calculator, calcOps);
        }

        private void HandleReciprocal(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleReciprocal(calculator, calcOps);
        }
    }
}
