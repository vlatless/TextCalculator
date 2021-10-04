using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextCalculator
{
    public class ExpressionParser
    {
        private readonly string operandsPattern = @"\d+(\.\d+)?";
        private readonly string subexpressionsBetweenBracketsInsideBracketsPattern = @"\(([^()]*)\)";

        private MatchCollection ReturnMatchCollection(string pattern, string expression) => new Regex(pattern).Matches(expression);

        public List<string> FindAllSubexpressionsInsideExternalBrackets(string expression)
        {
            var matches = ReturnMatchCollection(subexpressionsBetweenBracketsInsideBracketsPattern, expression);

            var subexpressionsList = new List<string>();

            foreach (Match match in matches)
            {
                subexpressionsList.Add(match.Value);
            }

            return subexpressionsList ?? new List<string>();
        }

        public List<double> FindOperandsByPriority(string expression, string currentByPrioriry)
        {
            var matches = ReturnMatchCollection($"{operandsPattern}\\{currentByPrioriry}{operandsPattern}", expression);

            if (matches.Count == 0)
            {
                return new List<double>();
            }
            else
            {
                var subexpression = matches[0].Value;

                return FindOperands(subexpression);
            }
        }

        public List<double> FindOperands(string expression)
        {
            var matches = ReturnMatchCollection(operandsPattern, expression);
            var operandsList = new List<double>();

            foreach (Match match in matches)
            {
                operandsList.Add(double.Parse(match.Value));
            }

            return operandsList;
        }

        public int CountOperands(string expression)
        {
            return ReturnMatchCollection(operandsPattern, expression).Count;    
        }
    }
}
