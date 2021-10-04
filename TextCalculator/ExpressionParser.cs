using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TextCalculator
{//@"\d+(\.\d+)?\*\d+(\.\d+)?"
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

        public (double, double) FindTwoOperandsByPriority(string expression, string currentByPrioriry)
        {
            var matches = ReturnMatchCollection($"{operandsPattern}\\{currentByPrioriry}{operandsPattern}", expression);

            return (
                double.Parse(matches[0].Value),
                double.Parse(matches[1].Value)
                );
        }
    }
}
