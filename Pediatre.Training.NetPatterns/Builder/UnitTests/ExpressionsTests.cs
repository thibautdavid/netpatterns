using System;
using System.CodeDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pediatre.Training.NetPatterns.Builder.UnitTests
{

    [TestClass]
    public class SumExpressionTests
    {
        [TestMethod]
        public void Eval_When_Sum_TwoConstants2and3_MustReturn_5()
        {
            // Arrange
            var sut = new SumExpression(new ConstantExpression(2), new ConstantExpression(3));
            // Act
            var actual = sut.Eval();

            // Assert
            Assert.AreEqual(expected: 5, actual: actual);
        }

        [TestMethod]
        public void Eval_When_Sum_OneVariableAndOneConstants5and3_MustReturn_8()
        {
            // Arrange
            var sut = new SumExpression(new AssignmentExpression(
                                                new VariableExpression("P"),
                                                new ConstantExpression(5)), 
                                            new ConstantExpression(3));
            var v = new Visitor.Visitor();
            sut.Accept(v);

            // Act
            var actual = sut.Eval();
            

            // Assert
            Assert.AreEqual(expected: 8, actual: actual);
            Assert.AreEqual("(P = 5) + 3", v.ToString());
        }
    }

    [TestClass]
    public class MultiplyExpressionTests
    {
        [TestMethod]
        public void Eval_When_Multiply_TwoConstants2and3_MustReturn_6()
        {
            // Arrange
            var sut = new MultiplyExpression(new ConstantExpression(2), new ConstantExpression(3));
            
            // Act
            var actual = sut.Eval();

            // Assert
            Assert.AreEqual(expected: 6, actual: actual);
        }

        [TestMethod]
        public void Eval_When_Multiply_OneVariableAndOneConstants5and3_MustReturn_15()
        {
            // Arrange
            var sut = new MultiplyExpression(new AssignmentExpression(
                                                    new VariableExpression("P"),
                                                    new ConstantExpression(5)),
                                            new ConstantExpression(3));

            // Act
            var actual = sut.Eval();

            // Assert
            Assert.AreEqual(expected: 15, actual: actual);
        }
    }

    [TestClass]
    public class AssignmentExpressionTests
    {
        [TestMethod]
        public void Eval_WhenStore_1_In_Variable_AAA_MustReturn_One()
        {
            var sut = new AssignmentExpression(new VariableExpression("AAA"), new ConstantExpression(1));

            Assert.AreEqual(1, sut.Eval());
        }
    }

    [TestClass]
    public class ConstantExpressionTests
    {
        [TestMethod]
        public void AConstant_ShouldReturnTheConstantValue()
        {
            // Arrange
            var expectedValue = 3;
            var sut = new ConstantExpression(expectedValue);

            // Act
            var actual = sut.Eval();

            // Assert
            Assert.AreEqual(expectedValue, actual);
        }
    }
}
