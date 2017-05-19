using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;

namespace WPFCalculator
{
    class CalculatorHandlers
    {
        CalculatorButtonHandlers calcButtonHandlers = new CalculatorButtonHandlers();
        private decimal numberButtonDigit;

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
                case ("MemoryClear"):
                    HandleMemoryClear(calculator);
                    break;
                case ("MemoryRecall"):
                    HandleMemoryRecall(calculator, calcOps);
                    break;
                case ("MemorySave"):
                    HandleMemorySet(calculator, calcOps);
                    break;
                case ("MemoryAdd"):
                    HandleMemoryChange(calculator, calcOps, true);
                    break;
                case ("MemorySubtract"):
                    HandleMemoryChange(calculator, calcOps, false);
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

        public void NumberEntryHandler(Button numberButton, Calculator calculator, CalculatorOperations calcOps)
        {
            calcOps.DigitEntrySet = true;
            string newValue;
            if (calculator.CurrentDigit.ToString().Length >= calculator.MaximumResultsStringLength - 1)
            {
                SystemSounds.Exclamation.Play();
                newValue = calculator.ResultsString;
            }
            else
            {
                if (calculator.CurrentDigit.ToString() == "0")
                {
                    if (numberButton.Tag.ToString() == ".")
                    {
                        if (calcOps.DecimalUsed)
                        {
                            SystemSounds.Exclamation.Play();
                            newValue = calculator.ResultsString;
                        }
                        else
                        {
                            newValue = "0" + numberButton.Tag.ToString() + "0";
                            calcOps.DecimalUsed = true;
                        }
                    }
                    else
                    {
                        newValue = numberButton.Tag.ToString();
                        if (newValue.Length <= 1)
                        {
                            newValue = newValue.Replace("0", string.Empty);
                        }
                    }
                }
                else
                {
                    if (numberButton.Tag.ToString() == ".")
                    {
                        if (calcOps.DecimalUsed)
                        {
                            SystemSounds.Exclamation.Play();
                            newValue = calculator.ResultsString;
                        }
                        else
                        {
                            newValue = calculator.CurrentDigit.ToString() + numberButton.Tag.ToString() + "0";
                            calcOps.DecimalUsed = true;
                        }
                    }
                    else
                    {
                        newValue = calculator.CurrentDigit.ToString() + numberButton.Tag.ToString();
                        if (newValue.Length <= 1)
                        {
                            newValue = newValue.Replace("0", string.Empty);
                        }

                    }
                }

                calcOps.DigitEntrySet = true;
                decimal.TryParse(newValue, out numberButtonDigit);
                calculator.CurrentDigit = numberButtonDigit;
                UpdateCurrentOperationString(newValue, calculator);
                calcOps.ArithemticDone = false;
            }
        }


        public void UpdateCurrentOperationString(string currentDigitValue, Calculator calculator)
        {
            calculator.ResultsString = currentDigitValue.ToString();
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
            calcButtonHandlers.HandleClear(calculator, calcOps);
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
        private void HandleMemorySet(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleMemorySet(calculator, calcOps);
        }
        private void HandleMemoryClear(Calculator calculator)
        {
            calcButtonHandlers.HandleMemoryClear(calculator);
        }
        private void HandleMemoryRecall(Calculator calculator, CalculatorOperations calcOps)
        {
            calcButtonHandlers.HandleMemoryRecall(calculator, calcOps);
        }
        private void HandleMemoryChange(Calculator calculator, CalculatorOperations calcOps, bool Addition)
        {
            calcButtonHandlers.HandleMemoryChange(calculator, calcOps, Addition);
        }

    }
}
