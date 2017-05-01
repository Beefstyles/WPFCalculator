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
            UpdateCurrentOperationString();
        }

        private void UpdateCurrentOperationString()
        {
            calculator.ResultsString = calculator.CurrentDigit.ToString();
        }
        private void ArithmeticHandler(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Name)
            {
                case ("Addition"):
                    if (calcOps.SecondDigitSet)
                    {
                        calculator.ResultsString = (calcOps.Addition(calculator.CurrentDigit, calculator.SecondDigit)).ToString();
                    }
                    else
                    {
                        calcOps.SecondDigitSet = true;
                    }
                    break;
                default:
                    MessageBox.Show("Not implemented");
                   break;
            }

        }

        private void NumberEntryHandler(object sender, RoutedEventArgs e)
        {
            var numberButton = sender as Button;
            int numberButtonDigit;
            int.TryParse(numberButton.Tag.ToString(), out numberButtonDigit);
            calculator.CurrentDigit = numberButtonDigit;
            UpdateCurrentOperationString();
        }
    }
}
