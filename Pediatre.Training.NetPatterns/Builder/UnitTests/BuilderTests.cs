using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pediatre.Training.NetPatterns.Builder.UnitTests
{
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void Enter_ConstantWithValue3_MustReturn3()
        {
            // Arrange
            var input = "3";
            var sut = new ExpressionParser();

            // Act
            IExpression actual = sut.Parse(input);

            // Assert
            Assert.AreEqual(3, actual.Eval());
        }

        [TestMethod]
        public void Input_Sum()
        {
            // Arrange
            var input = "6 5 +";
            var sut = new ExpressionParser();

            // Act
            IExpression actual = sut.Parse(input);

            // Assert
            Assert.AreEqual(11, actual.Eval());
        }

        [TestMethod]
        public void Input_Mul()
        {
            // Arrange
            var input = "6 5 *";
            var sut = new ExpressionParser();

            // Act
            IExpression actual = sut.Parse(input);

            // Assert
            Assert.AreEqual(30, actual.Eval());
        }

        [TestMethod]
        public void Input_MulAndSum()
        {
            // Arrange
            var input = "1 2 + 3 *";
            var sut = new ExpressionParser();

            // Act
            IExpression actual = sut.Parse(input);

            // Assert
            Assert.AreEqual(9, actual.Eval());
        }

        [TestMethod]
        public void Input_SumAndThenSum()
        {
            // Arrange
            var input = "1 2 3 * + ";
            var sut = new ExpressionParser();
            
            // Act
            IExpression actual = sut.Parse(input);
            
            var v = new Visitor.Visitor();
            ((BinaryExpression)actual).Accept(v);

            // Assert
            Assert.AreEqual(7, actual.Eval());
            Assert.AreEqual("1 + 2 * 3", v.ToString());
        }
    }
}
