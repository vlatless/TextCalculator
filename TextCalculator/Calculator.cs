using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextCalculator
{
    public class Calculator
    {
        private readonly string deleleAllBracketsPattern = @"\(|\)";
        private readonly int MIN_NUMBER_OPERANDS = 2;
        private ExpressionParser parser;
        private List<OperationItem> priorities;

        public Calculator()
        {
            parser = new ExpressionParser();
            priorities = OperationsPriority.priorities;
        }

        public double CalculateExpression(string expression)
        {
            //var subexpressions = parser.FindAllSubexpressionsInsideExternalBrackets(expression);

            //foreach (var subexpression in subexpressions)
            //{
                foreach (var priority in priorities)
                {
                    var matchedOperands = parser.FindOperandsByPriority(expression, priority.OperationSign);
                    var operandCount = parser.CountOperands(expression);

                    if (operandCount == MIN_NUMBER_OPERANDS)
                    {
                        var lonelyOperand = Regex.Replace(expression, deleleAllBracketsPattern, string.Empty);
                        expression = expression.Replace(expression, lonelyOperand);
                    }
                    if (!matchedOperands.Any())
                        continue;

                    var subresult = priority.Operation(matchedOperands[0], matchedOperands[1]).ToString();
                    var subresultAsExpression = $"{matchedOperands[0]}{priority.OperationSign}{matchedOperands[1]}";

                    expression = expression.Replace(subresultAsExpression, subresult);
                    break;
                }
            //}

            if (parser.CountOperands(expression) == 1)
            {
                //var result = Regex.Replace(expression, deleleAllBracketsPattern, string.Empty);

                return double.Parse(expression);
            }
            else
            {
                return CalculateExpression(expression);
            }
        }
    }
}
