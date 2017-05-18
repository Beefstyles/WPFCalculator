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
        
        Calculator calculator = new Calculator { OperationString = "", ResultsString = "", CurrentDigit = 0 };
        CalculatorOperations calcOps = new CalculatorOperations();
        CalculatorHandlers calcHandlers = new CalculatorHandlers();
        private int numberButtonDigit;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = calculator;
            UpdateCurrentOperationString("0");
            calculator.CurrentSubTotal = 0;
        }

        private void UpdateCurrentOperationString(string currentDigitValue)
        {
            calculator.ResultsString = currentDigitValue.ToString();
        }

        private void ArithmeticHandler(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            calcHandlers.ArithmeticHandler(button, calculator, calcOps);
        }

        private void GeneralButtonHandler(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            calcHandlers.GeneralButtonHandler(button, calculator, calcOps);
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

        
    }
}
