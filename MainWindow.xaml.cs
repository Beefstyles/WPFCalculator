using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorButtonHandlers calcButtonHandlers = new CalculatorButtonHandlers();
        Calculator calculator = new Calculator { OperationString = "", ResultsString = "", CurrentDigit = 0, SecondDigit = 0, IsNegated = false };
        CalculatorOperations calcOps = new CalculatorOperations();
        private int numberButtonDigit;
        private int digitToSend;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = calculator;
            UpdateCurrentOperationString("0");
            calculator.CurrentSubTotal = 0;
            calcButtonHandlers.currentOperation = CalculatorOperations.CurrentOperation.NoOperation;
        }

        private void UpdateCurrentOperationString(string currentDigitValue)
        {
            calculator.ResultsString = currentDigitValue.ToString();
        }


        private void ArithmeticHandler(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (!calcOps.ArithemticDone)
            {
                switch (button.Name)
                {
                    case ("Addition"):
                        HandleAddition();
                        break;
                    case ("Subtraction"):
                        HandleSubtraction();
                        break;
                    case ("Equals"):
                        HandleEquals();
                        break;
                    case ("Division"):
                        HandleDivision();
                        break;
                    case ("Multiplication"):
                        HandleMultiplication();
                        break;
                    case ("Negation"):
                        HandleNegation();
                        break;
                    default:
                        MessageBox.Show("Not implemented");
                        break;
                }
            }
            calcOps.ArithemticDone = true;
        }

        private void GeneralButtonHandler(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Name)
            {
                case ("Negation"):
                    HandleNegation();
                    break;
                default:
                    MessageBox.Show("Not implemented");
                    break;
            }
        }

        private void NumberEntryHandler(object sender, RoutedEventArgs e)
        {
            var numberButton = sender as Button;
            calcOps.DigitEntrySet = true;
            string newValue;
            if (calculator.ResultsString == "0")
            {
                newValue = numberButton.Tag.ToString();
            }
            else
            {
                newValue = calculator.CurrentDigit.ToString() + numberButton.Tag.ToString();
                newValue = newValue.Replace("0", string.Empty);
            }
            ;
            calcOps.DigitEntrySet = true;
            int.TryParse(newValue, out numberButtonDigit);
            calculator.CurrentDigit = numberButtonDigit;
            UpdateCurrentOperationString(newValue);
            calcOps.ArithemticDone = false;
        }

        private void HandleAddition()
        {
            calcButtonHandlers.HandleAddition(calculator, calcOps);
        }

        private void HandleSubtraction()
        {
            calcButtonHandlers.HandleSubtraction(calculator, calcOps);
        }

        private void HandleEquals()
        {
            calcButtonHandlers.HandleEquals(calculator, calcOps);
        }

        private void HandleMultiplication()
        {
            calcButtonHandlers.HandleMultiplication(calculator, calcOps);
        }

        private void HandleDivision()
        {
            calcButtonHandlers.HandleDivision(calculator, calcOps);
        }

        private void HandleNegation()
        {
            if (calcOps.DigitEntrySet)
            {
                calculator.CurrentDigit *= -1;
                UpdateCurrentOperationString(calculator.CurrentDigit.ToString());
            }
            else
            {
                calculator.CurrentSubTotal *= -1;
                calcButtonHandlers.SetResultsString(calculator);
                Console.WriteLine("Current sub" + calculator.CurrentSubTotal);
            }
               
        }
    }
}
