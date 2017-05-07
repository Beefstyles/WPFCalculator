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
        Calculator calculator = new Calculator { OperationString = "", ResultsString = "", CurrentDigit = 0, SecondDigit = 0 };
        CalculatorOperations calcOps = new CalculatorOperations();
        CalculatorOperations.CurrentOperation currentOperation;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = calculator;
            UpdateCurrentOperationString("0");
            calculator.CurrentSubTotal = 0;
            currentOperation = CalculatorOperations.CurrentOperation.NoOperation;
        }

        private void UpdateCurrentOperationString(string digit)
        {
            calculator.ResultsString = digit.ToString();
            /*if (calcOps.SubTotalSet)
            {
                calculator.ResultsString = calculator.CurrentSubTotal.ToString();
            }
            else
            {
                calculator.ResultsString = calculator.CurrentDigit.ToString();
            }
            */
        }

        private void ClearCurrentDigit()
        {
            calculator.CurrentDigit = 0;

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
                    default:
                        MessageBox.Show("Not implemented");
                        break;
                }
            }
            
            calcOps.ArithemticDone = true;
        }

        private void NumberEntryHandler(object sender, RoutedEventArgs e)
        {
            var numberButton = sender as Button;
            calcOps.DigitEntrySet = true;
            string newValue;
            if(calculator.ResultsString == "0")
            {
                newValue = numberButton.Tag.ToString();
            }
            else
            {
                newValue = calculator.CurrentDigit.ToString() + numberButton.Tag.ToString();
                newValue = newValue.Replace("0", string.Empty);
            }
            int numberButtonDigit;
            calcOps.DigitEntrySet = true;
            int.TryParse(newValue, out numberButtonDigit);
            calculator.CurrentDigit = numberButtonDigit;
            UpdateCurrentOperationString(newValue);
            calcOps.ArithemticDone = false;
        }


        private void HandleAddition()
        {
            calculator.CurrentSubTotal = calcOps.Addition(calculator.CurrentSubTotal, calculator.CurrentDigit);
            calculator.OperationString += calculator.CurrentDigit + " + ";
            calcOps.DigitEntrySet = false;
            ClearCurrentDigit();
            calculator.ResultsString = calculator.CurrentSubTotal.ToString();
            currentOperation = CalculatorOperations.CurrentOperation.Addition;
        }

        private void HandleSubtraction()
        {
            calculator.CurrentSubTotal = calcOps.Subtraction(calculator.CurrentSubTotal, calculator.CurrentDigit);
            calculator.OperationString += calculator.CurrentDigit + " - ";
            calcOps.DigitEntrySet = false;
            ClearCurrentDigit();
            calculator.ResultsString = calculator.CurrentSubTotal.ToString();
            currentOperation = CalculatorOperations.CurrentOperation.Subtraction;
        }

        private void HandleEquals()
        {
            switch (currentOperation)
            {
                case (CalculatorOperations.CurrentOperation.Addition):
                    HandleAddition();
                    break;
                case (CalculatorOperations.CurrentOperation.Subtraction):
                    HandleSubtraction();
                    break;
            }
            calculator.OperationString = "";
            ClearCurrentDigit();
            calcOps.DigitEntrySet = false;
            calculator.ResultsString = calculator.CurrentSubTotal.ToString();
            currentOperation = CalculatorOperations.CurrentOperation.NoOperation;
            calculator.CurrentSubTotal = 0;
        }
    }

    
}
