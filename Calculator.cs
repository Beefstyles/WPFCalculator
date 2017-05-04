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

        public int CurrentDigit
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

        public int CurrentSubTotal
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

        private int currentTotal;
        public int CurrentTotal
        {
            get 
            {
                return currentTotal;
            }
            set
            {
                currentTotal = value;
            }
        }

        private int currentSubTotal;

        private int currentDigit;

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
