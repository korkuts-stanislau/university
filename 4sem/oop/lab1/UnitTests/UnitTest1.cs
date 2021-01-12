using System;
using VectorLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Got an empty array")]
        public void CheckEmptyArray()
        {
            Vector vector = new Vector(new double[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "It is not a vector")]
        public void CheckZeroArray()
        {
            Vector vector = new Vector(new double[] { 0, 0, 0 });
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "Got an empty array")]
        public void CheckNullException()
        {
            double[] array = null;
            Vector vector = new Vector(array);
        }

        [TestMethod]
        public void CheckValue1()
        {
            Vector vector = new Vector(new double[] { 3, 4 });
            Assert.AreEqual(5, vector.GetVectorLength());
        }

        [TestMethod]
        public void CheckValue2()
        {
            Vector vector = new Vector(new double[] { 3, 4, 10 });
            Assert.AreEqual(11.1803, vector.GetVectorLength(), 0.001);
        }

        [TestMethod]
        public void CheckValue3()
        {
            Vector vector = new Vector(new double[] { -3, -4 });
            Assert.AreEqual(5, vector.GetVectorLength());
        }

        [TestMethod]
        public void CheckValue4()
        {
            Vector vector = new Vector(new double[] { -3, -4, -15, -26 });
            Assert.AreEqual(30.4302, vector.GetVectorLength(), 0.001);
        }

        [TestMethod]
        public void CheckValue5()
        {
            Vector vector = new Vector(new double[] { 3, 4, 5, 6, 7 });
            Assert.AreEqual(11.6189, vector.GetVectorLength(), 0.001);
        }

        [TestMethod]
        public void CheckValue6()
        {
            Vector vector = new Vector(new double[] { 15 });
            Assert.AreEqual(15, vector.GetVectorLength());
        }

        [TestMethod]
        public void CheckValue7()
        {
            Vector vector = new Vector(new double[] { -4 });
            Assert.AreEqual(4, vector.GetVectorLength());
        }
    }
}
