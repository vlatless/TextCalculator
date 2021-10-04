using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TextCalculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("1+(2+3)*(4+5)", 101d)]
        public void Calculate_Expression_ReturnTrue(string expression, double expectedResult)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var actualResult = calculator.CalculateExpression();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
