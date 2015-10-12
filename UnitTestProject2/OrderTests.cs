using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestableModel;

namespace UnitTestProject2
{
    [TestClass]
    public class OrderTests
    {
        decimal _nothingSelectedPrice = 0;
        decimal _price1 = 1;

        [TestMethod]
        public void Order_OneOrderLine_TotalPrice1()
        {
            // Arrange
            var order = new Order();
            var line1 = new OrderLine
            {
                Price = _price1,
                ProductName = "Ms",
                Selected = true
            };

            // Act
            order.OrderLines.Add(line1);

            // Assert
            Assert.AreEqual(_price1, order.TotalPrice);
            Assert.AreEqual(order.TotalPrice, order.TotalSelectdPrice);
        }

        [TestMethod]
        public void Order_OneUnselectedOrderLine_TotalPrice1()
        {
            // Arrange
            var order = new Order();
            var line1 = new OrderLine
            {
                Price = _price1,
                ProductName = "Ms",
                Selected = false
            };

            // Act
            order.OrderLines.Add(line1);

            // Assert
            Assert.AreEqual(_price1, order.TotalPrice);
            Assert.AreEqual(_nothingSelectedPrice, order.TotalSelectdPrice);
        }

        [TestMethod]
        public void Order_TwoOrderLinesChangeSelection_TotalPrice1()
        {
            // Arrange
            var order = new Order();
            var line1 = new OrderLine
            {
                Price = _price1,
                ProductName = "Ms",
                Selected = false
            };
            var line2 = new OrderLine
            {
                Price = _price1,
                ProductName = "Apple",
                Selected = false
            };
            order.OrderLines.Add(line1);
            order.OrderLines.Add(line2);

            // Act
            line2.Selected = true;

            // Assert
            Assert.AreEqual(_price1 + _price1, order.TotalPrice);
            Assert.AreEqual(_price1, order.TotalSelectdPrice);
        }
    }
}
