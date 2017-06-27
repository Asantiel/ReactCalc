using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReactCalc;

namespace TestCalc
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            var calc = new Calc();
            var x = calc.Sum(1, 2);

            Assert.AreEqual(x, 3);
            Assert.AreEqual(calc.Sum(0, 0), 0);
            Assert.AreEqual(calc.Sum(-1, 2), 1);
            Assert.AreEqual(calc.Sum(3, 3), 6);
        }

        [TestMethod]
        public void TestDiv()
        {
            var calc = new Calc();
            var x = calc.Div(4, 2);
            var y = calc.Div(2, 0);

            Assert.AreEqual(x, 2);
            Assert.AreEqual(y, double.PositiveInfinity);
        }

        [TestMethod]
        public void TestSqrt()
        {
            var calc = new Calc();
            var x = calc.Sqrt(4);

            Assert.AreEqual(x, 2);
        }

        [TestMethod]
        public void TestMpl()
        {
            var calc = new Calc();
            var x = calc.Mpl(2,0);

            Assert.AreEqual(x, 0);
        }
        
        [TestMethod]
        public void TestPow()
        {
            var calc = new Calc();
            var x = calc.Pow(2, 0);
            var y = calc.Pow(2, 2);

            Assert.AreEqual(x, 1);
            Assert.AreEqual(y, 4);


        }
    }
}
