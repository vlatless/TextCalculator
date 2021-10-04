using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TextCalculator.Tests
{
    public class ExpressionParserTests
    {
        //[Theory]
        //[InlineData("1+1", new double[] { 1d, 1d })]
        //[InlineData("1-1", new double[] { 1d, 1d })]
        //[InlineData("1*1-1.1", new double[] { 1d, 1d, 1.1d })]
        //[InlineData("1*1+1.111", new double[] { 1d, 1d, 1.111d })]
        //public void Parse_Expression_ReturnsOperandsArray(string input, double[] expectedOperands)
        //{
        //    // Arrange 
        //    var parser = new ExpressionParserTests();

        //    // Act 
        //    var actualOperands = parser.FindOperands(input).ToArray();

        //    // Assert
        //    Assert.Equal(expectedOperands, actualOperands);
        //}

        [Theory]
        [InlineData("((6/3+1.1)*(2+3)*(4-2))", new string[] { "(6/3+1.1)", "(2+3)", "(4-2)"})]
        public void Find_Exression_ReturnSubexpressionsBetweenBrackets(string expression, string[] expectedSubexpressions)
        {
            // Arrange
            var parser = new ExpressionParser();

            // Act
            var actualSubexpressions = parser.FindAllSubexpressionsInsideExternalBrackets(expression).ToArray();

            // Assert
            Assert.Equal(expectedSubexpressions, actualSubexpressions);
        }
    }
}
