using System;
using System.Collections.Generic;
using System.Text;

namespace TextCalculator
{
    public class OperationItem
    {
        public string OperationSign;
        public Func<double, double, double> Operation;
    }
}
