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
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = calculator;
            UpdateCurrentOperationString("0");
            calculator.CurrentSubTotal = 0;
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
            switch (button.Name)
            {
                case ("Addition"):
                    if (calcOps.DigitEntrySet)
                    {
                        calculator.CurrentSubTotal += calculator.CurrentDigit;     
                        calculator.OperationString += calculator.CurrentDigit + " + ";
                        calcOps.DigitEntrySet = false;
                    }
                    else
                    {
                        calculator.CurrentSubTotal += calculator.CurrentSubTotal;
                        calculator.OperationString += calculator.CurrentSubTotal + " + ";
                    }
                    ClearCurrentDigit();
                    calculator.ResultsString = calculator.CurrentSubTotal.ToString();
                    break;
                case ("Subtraction"):
                    //TODO - Implement
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
            newValue = calculator.CurrentDigit.ToString() + numberButton.Tag.ToString();
            int numberButtonDigit;
            calcOps.DigitEntrySet = true;
            int.TryParse(newValue, out numberButtonDigit);
            calculator.CurrentDigit = numberButtonDigit;
            UpdateCurrentOperationString(newValue);
        }
    }
}
