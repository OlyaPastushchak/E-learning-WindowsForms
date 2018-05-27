using Microsoft.VisualStudio.TestTools.UnitTesting;
using E_learning_WinForms;
using System;
using System.Drawing;
using System.Globalization;

namespace E_learning_WinForms_Tests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void RadiusTest1()
        {
            Circle circle = new Circle(new Point(1, 1), new Point(1, 4));
            double expected = 3;

            double actual = circle.Radius();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RadiusTest2()
        {
            Circle circle = new Circle(new Point(1, 1), new Point(2, 2));
            double expected = 1.41421;

            double actual = Math.Round(circle.Radius(),5);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ArgbColorTest()
        {
            Circle circle = new Circle();
            circle.CircleColor = Color.CadetBlue;
            int expected = Int32.Parse("#FF5F9EA0".Replace("#", ""), NumberStyles.HexNumber);

            int actual = circle.ColorArgb;

            Assert.AreEqual(expected, actual);
        }
    }
}
