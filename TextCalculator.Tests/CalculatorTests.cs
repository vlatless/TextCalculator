using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TextCalculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("(1+2-3)", 0d)]
        [InlineData("(1+(2+3)*(4+5))", 46d)]
        [InlineData("(13.2+(6/3)*(4.4+5.1))", 32.2d)]
        public void Calculate_Expression_ReturnTrue(string expression, double expectedResult)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actualResult = calculator.CalculateExpression(expression);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("1+2+3", 6d)]
        public void Calculate_ExpressionWithNoBrackets_ReturnTrue(string expression, double expectedResult)
        { 
        }

        [Theory]
        [InlineData("1+(2-3)", 0d)]
        public void Calculate_ExpressionWithBrackets_ReturnTrue(string expression, double expectedResult)
        {
        }

        [Theory]
        [InlineData("1+2+3+4", 10d)]
        public void Calculate_ExpressionWithOnlySum_ReturnTrue(string expression, double expectedResult)
        {
        }

        [Theory]
        [InlineData("1-2-3-4", -10d)]
        public void Calculate_ExpressionWithOnlySub_ReturnTrue(string expression, double expectedResult)
        {
        }

        [Theory]
        [InlineData("((3-1) + (2-1)*(4-1))", 5d)]
        public void Calculate_ExpressionWithOnlyBrackets_ReturnTrue(string expression, double expectedResult)
        {
        }
    }
}
