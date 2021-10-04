using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TextCalculator.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData("1+(2+3)*(4*5)", 101)]
        public void Calculate_Expression_ReturnTrue(string expression, int result)
        { 
            // Arrange

            // Act

            // Assert
        }
    }
}
