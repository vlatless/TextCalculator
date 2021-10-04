using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextCalculator
{
    public class Calculator
    {
        private readonly string deleleAllBracketsPattern = @"\(|\)";
        private readonly int MIN_NUMBER_OPERANDS = 1;
        private ExpressionParser parser;
        private List<OperationItem> priorities;

        public Calculator()
        {
            parser = new ExpressionParser();
            priorities = OperationsPriority.priorities;
        }

        public double CalculateExpression(string expression)
        {
            var subexpressions = parser.FindAllSubexpressionsInsideExternalBrackets(expression);

            foreach (var subexpression in subexpressions)
            {
                foreach (var priority in priorities)
                {
                    var matchedOperands = parser.FindOperandsByPriority(subexpression, priority.OperationSign);
                    var operandCount = parser.CountOperands(subexpression);

                    if (operandCount == MIN_NUMBER_OPERANDS)
                    {
                        var lonelyOperand = Regex.Replace(subexpression, deleleAllBracketsPattern, string.Empty);
                        expression = expression.Replace(subexpression, lonelyOperand);
                    }
                    if (!matchedOperands.Any())
                        continue;

                    var subresult = priority.Operation(matchedOperands[0], matchedOperands[1]).ToString();
                    var subresultAsExpression = $"{matchedOperands[0]}{priority.OperationSign}{matchedOperands[1]}";

                    expression = expression.Replace(subresultAsExpression, subresult);
                }
            }

            if (parser.CountOperands(expression) == MIN_NUMBER_OPERANDS)
            {
                var result = Regex.Replace(expression, deleleAllBracketsPattern, string.Empty);

                return double.Parse(result);
            }
            else
            {
                return CalculateExpression(expression);
            }
        }
    }
}
