using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextCalculator
{
    public class Calculator
    {
        public double CalculateExpression(string exression)
        {
            var parser = new ExpressionParser();

            var subexpressions = parser.FindAllSubexpressionsInsideExternalBrackets(exression);
            var priorities = new OperationsPriority().priorities;

            // oh no...
            foreach (var priority in priorities)
            {
                foreach (var subexpression in subexpressions)
                {
                    var operands = parser.FindTwoOperandsByPriority(subexpression, priority.OperationSign);
                    var subresult = priority.Operation(operands.Item1, operands.Item2).ToString();
                    exression.Replace(exression, subresult);
                }
            }

            return CalculateExpression(exression);
        }
    }
}
