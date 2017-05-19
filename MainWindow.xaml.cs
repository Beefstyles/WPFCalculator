using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
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
        Calculator calculator = new Calculator { OperationString = "", ResultsString = "", CurrentDigit = 0, MaximumResultsStringLength = 13, MemoryValue = 0, MemorySet="M" };
        CalculatorOperations calcOps = new CalculatorOperations();
        CalculatorHandlers calcHandlers = new CalculatorHandlers();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = calculator;
            calcHandlers.UpdateCurrentOperationString("0", calculator);
            calculator.CurrentSubTotal = 0;
            calcOps.DecimalUsed = false;
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
            calcHandlers.NumberEntryHandler(numberButton, calculator, calcOps);
        }
    }
}
