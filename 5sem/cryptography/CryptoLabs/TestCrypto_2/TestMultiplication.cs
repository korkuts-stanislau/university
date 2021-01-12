using System;
using CipherLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCrypto_2
{
    [TestClass]
    public class TestMultiplication
    {
        [TestMethod]
        public void TestPunctuation()
        {
            string w = "AB, CDE";
            MultiplicationCipher multiplicationCipher = new MultiplicationCipher("1 3 2 2 1 5 3 2 1");

            string res = multiplicationCipher.Decrypt(multiplicationCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }

        [TestMethod]
        public void TestSentence()
        {
            string w = "APPLE IS A LIE!";
            MultiplicationCipher multiplicationCipher = new MultiplicationCipher("1 3 2 2 1 5 3 2 1");

            string res = multiplicationCipher.Decrypt(multiplicationCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }

        [TestMethod]
        public void TestWord()
        {
            string w = "APPLE";
            MultiplicationCipher multiplicationCipher = new MultiplicationCipher("1 3 2 2 1 5 3 2 1");

            string res = multiplicationCipher.Decrypt(multiplicationCipher.Encrypt(w));
            Assert.AreEqual(w, res);
        }
    }
}
