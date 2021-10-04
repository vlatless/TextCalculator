using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextCalculator
{
    public class ExpressionParser
    {
        private readonly string allOperandsPattern = @"\d+(\.\d+)?";
        private readonly string expressionsBetweenExternalBracketsPattern = @"(\(.+\))";
        private readonly string expressionsBetweenBracketsInsideExternalBracketsPattern = @"\(([^()]*)\)";

        private MatchCollection ReturnMatchCollection(string pattern, string expression) => new Regex(pattern).Matches(expression);

        public void ParseExpression(string expression)
        {

        }

        private string FindAllExpressionsInsideExternalBrackets(string expression)
        {
            var matches = ReturnMatchCollection(expressionsBetweenExternalBracketsPattern, expression);

            foreach(Match match in matches)
            {
                FindAllExpressionsInsideExternalBrackets(match.Value);
            }
            return "hah";
        }

        private void FindExpressionsBetweenBrackets(string expression)
        {
            var matches = ReturnMatchCollection(expressionsBetweenBracketsInsideExternalBracketsPattern, expression);
        }

        public List<double> FindOperands(string expression)
        {
            var matches = ReturnMatchCollection(allOperandsPattern, expression);
            var operandsList = new List<double>();

            foreach (Match match in matches)
            {
                operandsList.Add(double.Parse(match.Value));
            }

            return operandsList;
        }
    }
}
