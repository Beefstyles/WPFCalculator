using System;
using System.Collections.Generic;
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
        Calculator calculator = new Calculator { OperationString = "", ResultsString = "" };
        CalculatorOperations calcOps = new CalculatorOperations();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = calculator;
        }

        private void ArithmeticHandler(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            switch (button.Name)
            {
                case ("Addition"):
                    break;
                default:
                    MessageBox.Show("Not implemented");
                   break;
            }

        }
    }
}
