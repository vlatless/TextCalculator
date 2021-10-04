using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextCalculator
{//\d+(\.\d+)?\*(\d+(\.\d+)?)
    public class ExpressionParser
    {
        private readonly string allOperandsPattern = @"\d+(\.\d+)?";
        private readonly string subexpressionsBetweenExternalBracketsPattern = @"(\(.+\))";
        private readonly string subexpressionsBetweenBracketsInsideExternalBracketsPattern = @"\(([^()]*)\)";

        private MatchCollection ReturnMatchCollection(string pattern, string expression) => new Regex(pattern).Matches(expression);

        public void ParseExpression(string expression)
        {

        }

        public List<string> FindAllSubexpressionsInsideExternalBrackets(string expression)
        {
            var matches = ReturnMatchCollection(subexpressionsBetweenBracketsInsideExternalBracketsPattern, expression);

            var subexpressionsList = new List<string>();

            foreach (Match match in matches)
            {
                subexpressionsList.Add(match.Value);
            }

            return subexpressionsList ?? new List<string>();
        }

        public List<double> FindOperands(string expression)
        {
            var matches = ReturnMatchCollection(allOperandsPattern, expression);
            var operandsList = new List<double>();

            foreach (Match match in matches)
            {
                operandsList.Add(double.Parse(match.Value));
            }

            return operandsList ?? new List<double>();
        }
    }
}
