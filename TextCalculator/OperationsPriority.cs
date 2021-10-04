using System;
using System.Collections.Generic;
using System.Text;

namespace TextCalculator
{
    public class OperationsPriority
    {
        public List<OperationItem> priorities { get; private set; }

        public OperationsPriority()
        {
            priorities = new List<OperationItem>
            {
                new OperationItem()
                {
                    OperationSign = "*",
                    Operation = (double p1, double p2) =>  p1 * p2
                },
                new OperationItem()
                {
                    OperationSign = "/",
                    Operation = (double p1, double p2) =>  p1 / p2
                },
                new OperationItem()
                {
                    OperationSign = "+",
                    Operation = (double p1, double p2) =>  p1 + p2
                },
                new OperationItem()
                {
                    OperationSign = "-",
                    Operation = (double p1, double p2) =>  p1 - p2
                }
            };
        }
    }
}
