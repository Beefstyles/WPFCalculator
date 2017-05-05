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
            if (!calcOps.ArithemticDone)
            {
                switch (button.Name)
                {
                    case ("Addition"):
                         calculator.CurrentSubTotal = calcOps.Addition(calculator.CurrentSubTotal,calculator.CurrentDigit);
                         calculator.OperationString += calculator.CurrentDigit + " + ";
                         calcOps.DigitEntrySet = false;
                          ClearCurrentDigit();
                          calculator.ResultsString = calculator.CurrentSubTotal.ToString();
                        break;
                    case ("Subtraction"):
                        calculator.CurrentSubTotal -= calculator.CurrentDigit;
                        calculator.OperationString += calculator.CurrentDigit + " - ";
                        calcOps.DigitEntrySet = false;
                        ClearCurrentDigit();
                        calculator.ResultsString = calculator.CurrentSubTotal.ToString();
                        break;
                    case ("Equals"):
                        calculator.OperationString = "";
                        ClearCurrentDigit();
                        calcOps.DigitEntrySet = false;
                        calculator.ResultsString = calculator.CurrentSubTotal.ToString();
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
            if(calculator.CurrentDigit == 0)
            {
                newValue = calculator.CurrentDigit.ToString();
            }
            else
            {
                newValue = calculator.CurrentDigit.ToString() + numberButton.Tag.ToString();
            }
            newValue = calculator.CurrentDigit.ToString() + numberButton.Tag.ToString();
            int numberButtonDigit;
            calcOps.DigitEntrySet = true;
            int.TryParse(newValue, out numberButtonDigit);
            calculator.CurrentDigit = numberButtonDigit;
            UpdateCurrentOperationString(newValue);
            calcOps.ArithemticDone = false;
        }
    }
}
