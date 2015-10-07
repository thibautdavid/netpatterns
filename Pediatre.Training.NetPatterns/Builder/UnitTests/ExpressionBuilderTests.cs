using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pediatre.Training.NetPatterns.Builder.UnitTests
{
    [TestClass]
    public class ExpressionBuilderTests
    {
        [TestMethod]
        public void Parse_AStringWithOnlyOneConstant_Should_Return_AConstantExpressionInTheStack()
        {
            // Arrange
            var sut = new ExpressionParser();
            var input = "6";

            // Act
            var actual = sut.Parse(input);

            // Assert
            Assert.IsInstanceOfType(actual, typeof(ConstantExpression));
        }

        [TestMethod]
        public void Parse_AString_Should_Return_Stacked_Parts()
        {
            // Arrange
            var sut = new ExpressionParser();
            var input = "6 5 +";
            
            // Act
            var actual = sut.Parse(input);

            // Assert
            Assert.IsInstanceOfType(actual, typeof(SumExpression));
        }
    }
}
