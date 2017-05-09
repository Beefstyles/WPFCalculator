using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator
{
    public class Calculator : INotifyPropertyChanged
    {

        private bool isNegated;

        private string operationString;


        public string OperationString
        {
            get { return operationString; }
            set
            {
                operationString = value;
                NotifyPropertyChanged("OperationString");
            }
        }

        private string resultsString;

        public string ResultsString
        {
            get { return resultsString; }
            set
            {
                resultsString = value;
                NotifyPropertyChanged("ResultsString");
            }
        }

        public double CurrentDigit
        {
            get {return currentDigit; }

            set
            {
                currentDigit = value;
                NotifyPropertyChanged("CurrentDigit");
            }
        }

        public int SecondDigit
        {
            get
            {
                return secondDigit;
            }

            set
            {
                secondDigit = value;
                NotifyPropertyChanged("SecondDigit");
            }
        }

        public double CurrentSubTotal
        {
            get
            {
                return currentSubTotal;
            }
            set
            {
                currentSubTotal = value;
            }
        }

        public bool IsNegated
        {
            get
            {
                return isNegated;
            }

            set
            {
                isNegated = value;
            }
        }

        private double currentSubTotal;

        private double currentDigit;

        private int secondDigit;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
