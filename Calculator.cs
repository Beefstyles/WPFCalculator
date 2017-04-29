using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCalculator
{
    public class Calculator
    {
        private string operationString;

        public string OperationString
        {
            get { return operationString; }
            set { operationString = value; }
        }

        private string resultsString;

        public string ResultsString
        {
            get { return resultsString; }
            set { resultsString = value; }
        }

        public int CurrentDigit
        {
            get {return currentDigit; }

            set { currentDigit = value; }
        }

        private int currentDigit;
    }
}
