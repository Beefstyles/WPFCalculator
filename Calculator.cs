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

        private int maximumResultsStringLength;


        private string memorySet;
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

        public decimal CurrentDigit
        {
            get {return currentDigit; }

            set
            {
                currentDigit = value;
                NotifyPropertyChanged("CurrentDigit");
            }
        }


        private double memoryValue;

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

        public bool OperationSet
        {
            get
            {
                return operationSet;
            }

            set
            {
                operationSet = value;
            }
        }

        public int MaximumResultsStringLength
        {
            get
            {
                return maximumResultsStringLength;
            }

            set
            {
                maximumResultsStringLength = value;
            }
        }

        public double MemoryValue
        {
            get
            {
                return memoryValue;
            }

            set
            {
                memoryValue = value;
            }
        }

        public string MemorySet
        {
            get
            {
                return memorySet;
            }

            set
            {
                memorySet = value;
                NotifyPropertyChanged("MemorySet");
            }
        }

        private bool operationSet;

        private double currentSubTotal;

        private decimal currentDigit;


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
