using System;
using PolynomLib;
using ExceptionLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PolynomTests
{
    [TestClass]
    public class UnitTest1
    {
        Polinomial polinom1;
        Polinomial polinom2;
        double number;

        [TestInitialize]
        public void TestInitialize()
        {
            polinom1 = new Polinomial("-12x^5 +16x -12");
            polinom2 = new Polinomial("13x^6 -12,3x^2 +14,8");
            number = 13.49;
        }

        [TestMethod]
        public void TestEqualsOfPolynoms()
        {
            Assert.AreEqual("-156x^11 +354,6x^7 -177,6x^5 -196,8x^3 +236,8x -156x^6 +147,6x^2 -177,6", (polinom1 * polinom2).ToString());
        }
        [TestMethod]
        public void TestEqualsOfPolynomAndNumber()
        {
            Assert.AreEqual("-161,88x^5 +215,84x -161,88", (polinom1 * number).ToString());
        }
        [TestMethod]
        public void TestCheckTypePolPol()
        {
            Assert.IsInstanceOfType(polinom1 * polinom2, typeof(Polinomial));
        }
        [TestMethod]
        public void TestCheckTypePolNum()
        {
            Assert.IsInstanceOfType(polinom1 * number, typeof(Polinomial));
        }
        [TestMethod]
        public void TestIsMyException()
        {
            Exception exception = null;
            try
            {
                Polinomial polynom = new Polinomial("lalala");
            }
            catch (PolynomException ex)
            {
                exception = ex;
            }

            Assert.IsInstanceOfType(exception, typeof(PolynomException));
        }
    }
}
